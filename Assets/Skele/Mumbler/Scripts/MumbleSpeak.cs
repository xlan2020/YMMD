using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using ExtMethods;

using Random = UnityEngine.Random;
using Mono.Xml;
using System.IO;
using UnityEngine.Audio;
using System.Text;

namespace MH.Mumbler
{
    using DictSpeaking = Dictionary<Coroutine, SpeakContext>;

    [AutoCreateInstance]
    public class MumbleSpeak : Singleton<MumbleSpeak>
    {
        #region "conf data"

        [SerializeField]
        [Tooltip("the default speaker")]
        protected string _defSpeaker = DefaultVoice;

        [SerializeField]
        [Tooltip("the default context")]
        protected SpeakContext _defContext = new SpeakContext();

        [SerializeField]
        [Tooltip("")]
        protected bool _useNoise = false;

        #endregion "conf data"

        #region "data"

        protected SoundLib _activeSoundLib = new SoundLib();
        private StringBuilder _textBld = new StringBuilder();
        private DictSpeaking _dictSpeaking = new DictSpeaking();


        public string defSpeaker { get { return _defSpeaker; } set { _defSpeaker = value; } }
        public SoundLib activeSoundLib { get { return _activeSoundLib; } set { _activeSoundLib = value; } }

        #endregion "data"

        #region "unity methods"

        public override void Init()
        {
            base.Init();

            if (!PoolMgr.HasInst)
                PoolMgr.Create();
        }

        public override void Fini()
        {
            if (PoolMgr.HasInst)
                PoolMgr.Destroy();

            base.Fini();
        }

        #endregion "unity methods"

        #region "public methods"
        /// <summary>
        /// make to speak the given text
        /// </summary>
        /// <param name="decoratedText">the text that might contain format info</param>
        public Coroutine Speak(string decoratedText, string voiceName = null, Transform attachTr = null)
        {
            SpeakContext ctx = Mem.New<SpeakContext>();
            var co = StartCoroutine(_CoSpeak(ctx, decoratedText, voiceName, attachTr));
            _dictSpeaking.Add(co, ctx);

            return co;
        }
        public Coroutine Speak(float time, string voiceName = null, Transform attachTr = null)
        {
            _textBld.Remove(0, _textBld.Length);
            _textBld.Append('x', (int)(time * _defContext.charPerSec));
            string decorText = _textBld.ToString();
            return Speak(decorText, voiceName, attachTr);
        }

        public void StopSpeak(Coroutine coSpeak)
        {
            if (!_dictSpeaking.ContainsKey(coSpeak)) return;

            SpeakContext ctx = _dictSpeaking[coSpeak];
            _dictSpeaking.Remove(coSpeak);
            ctx.RequestStop();

        }

        #endregion "public methods"

        #region "private methods"

        private IEnumerator _CoSpeak(SpeakContext ctx, string decoratedText, string voiceName = null, Transform attachTr = null)
        {
            ctx.Copy(_defContext);
            ctx.runningSources.Clear();
            ctx.requestInterruptSpeak = false;
            ctx.soundAttachTransform = attachTr;
            ctx.speaker = _activeSoundLib.GetSpeaker(string.IsNullOrEmpty(voiceName) ? _defSpeaker : voiceName);
            if( ctx.speaker == null )
                ctx.speaker = _activeSoundLib.GetSpeaker(_defSpeaker);

            //Dbg.Log("{0}: _CoSpeak: start voice: {1}", Time.frameCount, ctx.speaker);

            List<SpeakSeg> segs = Mem.New< List<SpeakSeg> >();
            _ParseText(decoratedText, ctx, segs);

            // run each seg and play audios
            for (int i = 0; i < segs.Count && !ctx.requestInterruptSpeak; ++i)
            {
                var oneSeg = segs[i];
                switch( oneSeg.eType )
                {
                    case SpeakSeg.EType.Text: yield return _CoSpeakSeg_Text(ctx, segs[i]); break;
                    case SpeakSeg.EType.SoundName: yield return _CoSpeakSeg_SoundName(ctx, segs[i]); break;
                    case SpeakSeg.EType.Empty: yield return _CoSpeakSeg_Empty(ctx, segs[i]); break;
                }
            }

            ///------------------clean up--------------------///
            segs.ForEach(x => x.Release()); segs.Clear(); //clear segs data
            Mem.Del(segs); //release list itself
            Mem.Del(ctx); //release context

            //Dbg.Log("{0}: _CoSpeak: end voice: {1}", Time.frameCount, ctx.speaker);
        }

        /// <summary>
        /// silent for specific time
        /// </summary>
        private IEnumerator _CoSpeakSeg_Empty(SpeakContext ctx, SpeakSeg seg)
        {
            float t = DataUtil.ParseAsFloat(seg.text);
            if (t > 0)
                yield return new WaitForSeconds(t);
        }

        /// <summary>
        /// play specific sound
        /// </summary>
        private IEnumerator _CoSpeakSeg_SoundName(SpeakContext ctx, SpeakSeg seg)
        {
            string soundName = seg.text;
            var soundData = ctx.speaker.TryGetSoundBySpecificText(soundName);
            if (soundData == null)
                yield break;

            float pitch = ctx.curModPitch;
            float volume = ctx.curModVolume;
            float soloTime = soundData.clip.length;

            GameObject asGO = ctx.speaker.SpawnAS(); //audio-source GO
            _AttachAudioSourceToParent(asGO.transform, ctx);
            //Misc.AddChild(this.transform, asGO); //add to this

            AudioSource audioSource = asGO.AssertGetComponent<AudioSource>();
            audioSource.clip = soundData.clip;
            audioSource.pitch = pitch;
            audioSource.volume = volume;

            // play audio
            _PlaySource(audioSource, ctx);

            yield return new WaitForSeconds(soloTime);
        }

        /// <summary>
        /// 1. use time as loop-counter;
        /// 2. spawn AudioSource prefab and apply pitch/volume;
        /// 3. play and wait the clip on AS;
        /// </summary>
        private IEnumerator _CoSpeakSeg_Text(SpeakContext ctx, SpeakSeg seg)
        {
            ctx.curModPitch = seg.basePitch;
            ctx.curModVolume = seg.baseVolume;

            string text = seg.text;

            // 1
            float time = ((float)text.Length) / ctx.charPerSec;
            float leftTime = time;

            IntonCtrl inton = ctx.intonCtrl;
            float basePitch = 1f + ctx.curModPitch;
            EIntonFlag intonFlag = EIntonFlag.None;

            // 2, 3
            for(int soundIdx = 0, sndCnt = 0; leftTime > 0 && !ctx.requestInterruptSpeak; ++soundIdx)
            {
                // decide sound group clip cnt
                if( soundIdx == 0 )
                {
                    double rnd = 0;
                    do{
                        rnd = CoreRNG.Instance.GetNormal(1, 0.7);
                    } while (rnd < 0 || rnd > 2);
                    sndCnt = 1 + (int)(rnd * ctx.speaker.avgSoundGroupSize); //make into [1,2*meanGroupSoundCnt]
                }

                ///------------------prepare SoundData----------------------///
                SoundData soundData = ctx.speaker.soundDatas.RandomGetElem();
                inton.Calc(soundIdx, ctx, out intonFlag);

                ///------------------play audio--------------------///

                GameObject asGO = ctx.speaker.SpawnAS(); //audio-source GO
                _AttachAudioSourceToParent(asGO.transform, ctx);

                AudioSource audioSource = asGO.AssertGetComponent<AudioSource>();
                audioSource.clip = soundData.clip;
                audioSource.pitch = basePitch;
                audioSource.volume = soundData.lowVolume + ctx.curModVolume;

                // notify Mfx to work
                if( ctx.speaker.doVolumeFade )
                {
                    SoundFadeMfx volumeMfx = audioSource.AssertGetComponentInChildren<SoundFadeMfx>();
                    volumeMfx.Prepare(ctx, soundData);
                }
                
                if( ctx.speaker.doPitchFade )
                {
                    if (intonFlag.HasAnyFlag(EIntonFlag.Down | EIntonFlag.Up))
                    {
                        IntonationMfx pitchMfx = audioSource.AssertGetComponentInChildren<IntonationMfx>();
                        pitchMfx.Prepare(ctx, soundData, intonFlag, basePitch);
                    }
                }                

                //OnRelease.ForceAdd(asGO, soundData);

                // play audio
                _PlaySource(audioSource, ctx);

                // wait for a while (not necessarily same as clip length )
                float rndPause = Random.Range(ctx.speaker.randomPauseRange.x, ctx.speaker.randomPauseRange.y);
                float waitTime = soundData.clip.length - soundData.volumeFadeOutTime + rndPause;
                yield return new WaitForSeconds(waitTime);
                leftTime -= waitTime;

                if( !ctx.requestInterruptSpeak )
                {
                    // play nose-noise ( not last, and not immediately after a pause )
                    if (_useNoise && leftTime > 0)
                    {
                        _PlayNoseNoise(ctx);
                    }

                    // long pause(end of soundGroup)
                    if (soundIdx + 1 >= sndCnt)
                    {
                        yield return new WaitForSeconds(Random.Range(ctx.speaker.longPauseRange.x, ctx.speaker.longPauseRange.y));
                        soundIdx = -1;
                        inton.Reset();
                    }
                    else // short pause
                    {
                        if (Random.value < 0.09f)
                            yield return new WaitForSeconds(Random.Range(ctx.speaker.shortPauseRange.x, ctx.speaker.shortPauseRange.y));
                    }
                }               
                
            }

        }

        private void _PlayNoseNoise(SpeakContext ctx)
        {
            if( ctx.speaker.noiseClips.Count > 0 )
            {
                var noise = ctx.speaker.SpawnNoseNoiseAS();

                _AttachAudioSourceToParent(noise.transform, ctx);
                //Misc.AddChild(gameObject, noise.gameObject);

                //noise.Play();
                _PlaySource(noise, ctx);
            }            
        }

        private void _PlaySource(AudioSource src, SpeakContext ctx)
        {
            //Dbg.Log("MumbleSpeak._PlaySource: {0}", src.clip.name);
            AutoRelease_AudioSource rel = src.AssertGetComponent<AutoRelease_AudioSource>();
            rel.ctx = ctx;
            ctx.runningSources.Add(src);
            src.Play();
        }

        /// <summary>
        /// remove the formatting info from given text, 
        /// only leave the raw text
        /// </summary>
        private SmallXmlParser _xmlparser = new SmallXmlParser();
        private TextParseHandler _parserHandler = new TextParseHandler();
        private void _ParseText(string decoratedText, SpeakContext ctx, List<SpeakSeg> segs)
        {
            _parserHandler.ctx = ctx;
            _parserHandler.segs = segs;
            _xmlparser.Parse(new StringReader(decoratedText), _parserHandler);

            ctx.curModPitch = ctx.baseModPitch;
            ctx.curModVolume = ctx.baseModVolume;

        }


        /// <summary>
        /// attach the audio source to appropriate parent transform
        /// </summary>
        private void _AttachAudioSourceToParent(Transform source, SpeakContext ctx)
        {
            if(ctx.soundAttachTransform)
            {
                Misc.AddChild(this.transform, source);
                var follow = source.ForceGetComponent<FollowTransMfx>();
                follow.followTarget = ctx.soundAttachTransform;
            }
            else
            {
                Misc.AddChild(this.transform, source);
            }
        }

        #endregion "private methods"

        #region "constant"

        public const string DefaultVoice = "_defaultVoice";

        #endregion "constant"
    }

    /// <summary>
    /// used to handle text
    /// </summary>
    public class TextParseHandler : SmallXmlParser.IContentHandler
    {
        #region "data"
        protected SpeakContext _ctx;
        protected List<SpeakSeg> _segs;

        private Stack<IMemento> _stackMem = new Stack<IMemento>();

        ///-----------------------------------------------///

        public SpeakContext ctx { get { return _ctx; } set { _ctx = value; } }
        public List<SpeakSeg> segs { get { return _segs; } set { _segs = value; } }

        #endregion "data"

        #region "IContentHandler"

        public void OnStartParsing(SmallXmlParser parser)
        {
        }

        /// <summary>
        /// change the ctx
        /// </summary>
        public void OnStartElement(string name, SmallXmlParser.IAttrList attrs)
        {
            #region "BASEPROP"
            if (name == BASEPROP)
            {
                if (attrs.IsEmpty)
                {
                    Dbg.LogWarn("TextParseHandler.OnStartElement: attrs should not be empty: name = {0}", name);
                }
                else
                {
                    PropMem mem = PropMem.Alloc(_ctx);

                    for (int i = 0; i < attrs.Length; ++i)
                    {
                        string attrName = attrs.GetName(i);
                        string attrVal = attrs.GetValue(i);
                        float v = 0;

                        switch (attrName)
                        {
                            case ATTR_PITCH:
                                {
                                    if (Single.TryParse(attrVal, out v))
                                    {
                                        mem.pitch = _ctx.curModPitch;
                                        _ctx.curModPitch = v;
                                    }
                                }
                                break;
                            case ATTR_VOLUME:
                                {
                                    if (Single.TryParse(attrVal, out v))
                                    {
                                        mem.volume = _ctx.curModVolume;
                                        _ctx.curModVolume = v;
                                    }
                                }
                                break;
                            default:
                                Dbg.LogWarn("TextParseHandler.OnStartElement: unrecognized attr: {0}", attrName);
                                break;
                        }
                    } // for(int i=0; i<attrs.Length...

                    _stackMem.Push(mem);
                }
            } // if (name == BASEPROP )
            #endregion "BASEPROP"

            #region "specSound"
            else if (name == SPECSOUND)
            {
                if( attrs.GetName(0) == ATTR_SOUND_NAME )
                {
                    string soundName = attrs.GetValue(0);
                    SpeakSeg seg = SpeakSeg.Alloc(ctx, SpeakSeg.EType.SoundName);
                    seg.text = soundName;
                    _segs.Add(seg);
                }
            } // else if (name == SPECSOUND)
            #endregion "specSound"

            #region "empty time"
            else if (name == PAUSE)
            {
                if( attrs.GetName(0) == ATTR_TIME )
                {
                    string time = attrs.GetValue(0);
                    SpeakSeg seg = SpeakSeg.Alloc(ctx, SpeakSeg.EType.Empty);
                    seg.text = time;
                    _segs.Add(seg);
                }
            }
            #endregion "empty time"

        }

        /// <summary>
        /// create a new seg
        /// </summary>
        public void OnChars(string text)
        {
            SpeakSeg seg = SpeakSeg.Alloc(ctx, SpeakSeg.EType.Text);
            seg.text = text;            
            _segs.Add(seg);
        }

        /// <summary>
        /// revert the ctx
        /// </summary>
        public void OnEndElement(string name)
        {
            if( name == BASEPROP )
            {
                var mem = _stackMem.Pop();
                mem.Undo();
            }            
        }

        public void OnEndParsing(SmallXmlParser parser)
        {
            _ctx = null;
            _segs = null;

            Dbg.Assert(_stackMem.Count == 0, "TextParseHandler.OnEndParsing: stackMem not empty! check if the tags are all matched");
            _stackMem.Clear(); //ensure empty
        }

        public void OnIgnorableWhitespace(string text) { }
        public void OnProcessingInstruction(string name, string text) { }
        #endregion "IContentHandler"



        private const string BASEPROP = "prop";
        private const string SPECSOUND = "specSound";
        private const string PAUSE = "pause";

        private const string ATTR_PITCH = "pitch";
        private const string ATTR_VOLUME = "volume";

        private const string ATTR_SOUND_NAME = "soundName";

        private const string ATTR_TIME = "time";
    }

    /// <summary>
    /// used in parsing xml text, could undo previous tags' modification
    /// </summary>
    public interface IMemento
    { void Undo(); }
    public class PropMem : IMemento
    {
        private enum EAffect { NONE = 0, PITCH = 0x1, VOLUME = 0x2 };
        private SpeakContext ctx;
        private EAffect _eAffect = EAffect.NONE;
        private float _pitch = 0;
        private float _volume = 0;

        ///-----------------------------------------------///

        public float pitch { get { return _pitch; } set { _pitch = value; _eAffect |= EAffect.PITCH; } }
        public float volume { get { return _volume; } set { _volume = value; _eAffect |= EAffect.VOLUME; } }

        public static PropMem Alloc(SpeakContext ctx)
        {
            PropMem m = Mem.New<PropMem>();
            m.ctx = ctx;
            return m;
        }

        public void Release()
        {
            _eAffect = EAffect.NONE;
        }

        public void Undo()
        {
            if ((_eAffect & EAffect.PITCH) != 0) { ctx.curModPitch = _pitch; }
            if ((_eAffect & EAffect.VOLUME) != 0) { ctx.curModVolume = _volume; }

            Release();
        }
    }

    /// <summary>
    /// used by Speak() to actually execute audio play actions
    /// </summary>
    public class SpeakSeg
    {
        #region "data"
        public EType eType = EType.Text;
        public string text;
        public float basePitch;
        public float baseVolume;

        #endregion "data"

        #region "public methods"
        public static SpeakSeg Alloc(SpeakContext ctx, EType tp)
        {
            var seg = Mem.New<SpeakSeg>();
            seg.eType = tp;
            seg.basePitch = ctx.curModPitch;
            seg.baseVolume = ctx.curModVolume;
            return seg;
        }

        public void Release()
        {
            Mem.Del(this);
            text = string.Empty;
            basePitch = 0;
            baseVolume = 0;
            eType = EType.Text;
        }

        public enum EType {
            Text,
            SoundName,
            Empty,
        }

        #endregion "public methods"
    }

    /// <summary>
    /// context data for a speak session
    /// </summary>
    [Serializable]
    public class SpeakContext
    {
        public float charPerSec = 12f;
        [SerializeField][Tooltip("")]
        protected float _baseModPitch = 0f;
        [SerializeField][Tooltip("")]
        protected float _baseModVolume = 0f;
        ///--------------------------------------///

        protected SpeakerData _speaker;
        protected float _curModPitch = 1f;
        protected float _curModVolume = 1f;
        protected Transform _soundAttachTransform;

        protected IntonCtrl _intonCtrl = new IntonCtrl();

        private bool _requestInterruptSpeak = false;
        private List<AudioSource> _runningSrcs = new List<AudioSource>();

        ///--------------------------------------///

        public SpeakerData speaker { get { return _speaker; } set { _speaker = value; } }

        public float baseModPitch { get { return _baseModPitch; } set { _baseModPitch = value; } }
        public float baseModVolume { get { return _baseModVolume; } set { _baseModVolume = value; } }
        public float curModPitch { get { return _curModPitch; } set { _curModPitch = value; } }
        public float curModVolume { get { return _curModVolume; } set { _curModVolume = value; } }
        public Transform soundAttachTransform { get { return _soundAttachTransform; } set { _soundAttachTransform = value; } }
        public IntonCtrl intonCtrl { get { return _intonCtrl; } }
        public bool requestInterruptSpeak { get { return _requestInterruptSpeak; } set { _requestInterruptSpeak = value; } }
        public List<AudioSource> runningSources { get { return _runningSrcs; } }

        /// <summary>
        /// copy from another SpeakContext instance,
        /// NOTE: the modBase*** will directly copy 'ctx.base***', won't copy from the 'ctx.modBase***'
        /// </summary>
        public void Copy(SpeakContext ctx)
        {
            speaker = ctx.speaker;

            charPerSec = ctx.charPerSec;
            curModPitch = baseModPitch = ctx.baseModPitch;
            curModVolume = baseModVolume = ctx.baseModVolume;

            soundAttachTransform = ctx.soundAttachTransform;
        }

        public void RequestStop()
        {
            _requestInterruptSpeak = true;
            for(int i=0; i<_runningSrcs.Count; ++i)
            {
                _runningSrcs[i].Stop();
            }
        }
    }

    /// <summary>
    /// used for controling intonation
    /// </summary>
    public class IntonCtrl
    {
        public EIntonFlag eFlag = EIntonFlag.None;
        

        public void Calc(int idx, SpeakContext ctx, out EIntonFlag eThisFlag)
        {
            SpeakerData speaker = ctx.speaker;
            eThisFlag = EIntonFlag.None;
            if (idx == 0)
            {
                float r = Random.value;
                if (r < speaker.chanceStartToneUp)
                {
                    eFlag |= EIntonFlag.Up;
                    eThisFlag = EIntonFlag.Up;
                }
                else if (r < speaker.chanceStartToneUp + speaker.chanceStartToneDown)
                {
                    eFlag |= EIntonFlag.Down;
                    eThisFlag = EIntonFlag.Down;
                }
            }
            else
            {
                if (!eFlag.HasFlag(EIntonFlag.Up | EIntonFlag.Down))
                {
                    float r = Random.value;
                    if( r < speaker.chanceMidToneChange )
                    {
                        if (!eFlag.HasFlag(EIntonFlag.Up))
                        {
                            eFlag |= EIntonFlag.Up;
                            eThisFlag = EIntonFlag.Up;
                        }
                        else if (!eFlag.HasFlag(EIntonFlag.Down) )
                        {
                            eFlag |= EIntonFlag.Down;
                            eThisFlag = EIntonFlag.Down;
                        }
                    }
                    
                }
            }
        }

        public void Reset()
        {
            eFlag = EIntonFlag.None;
        }

    }

    public enum EIntonFlag
    {
        None,
        Up = 1,
        Down = 2,
    }

    public enum ESpeakEffect
    {
        None,
        IntonationUp,
        IntonationDown,
    }

    public enum EDelimiter
    {
        CharBound,
        Space,
    }
}

