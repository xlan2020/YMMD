using UnityEngine;
using System;
using System.Collections.Generic;
using ExtMethods;

namespace MH.Mumbler
{
    [CreateAssetMenu(menuName = "Skele_Mumbler/SpeakerData")]
    public class SpeakerData : ScriptableObject
    {
        #region "data"
        [SerializeField]
        [Tooltip("the prefab used to play the audio, required.")]
        protected AudioSource _pfAudioSource;
        [SerializeField]
        [Tooltip("the prefab used to play noise between audios to fill 'gaps', optional if not selected 'use Noise' in MumbleSpeak.cs ")]
        protected AudioSource _pfNoise;
        [SerializeField]
        [Tooltip("the mumble audio clips for this speaker")]
        protected List<SoundData> _soundDatas = new List<SoundData>();
        [SerializeField]
        [Tooltip("noise audio clips, optional if you don't use noise")]
        protected List<AudioClip> _noiseClips = new List<AudioClip>();
        [SerializeField]
        [Tooltip("make it speak specific audio")]
        protected List<SpecAudioStruct> _specificAudios = new List<SpecAudioStruct>();
        private Dictionary<string, SoundData> _dictSpecAudios = new Dictionary<string, SoundData>();

        ///------------------pause--------------------///
        [SerializeField]
        [Tooltip("at the end of each clip, a low chance we added a short pause")]
        protected Vector2 _shortPauseRange = new Vector2(0.05f, 0.15f);
        [SerializeField]
        [Tooltip("at the end of a sentence, we will add a pause")]
        protected Vector2 _longPauseRange = new Vector2(0.2f, 0.3f);
        [SerializeField]
        [Tooltip("add a small randomness to the fadeout duration for each clip")]
        protected Vector2 _randomPauseRange = new Vector2(0, 0.2f);
        ///------------------arrange group param--------------------///
        [SerializeField]
        [Tooltip("for a sentence, the average sound clip count")]
        protected double _avgSoundGroupSize = 6;
        [SerializeField]
        [Tooltip("the chance to raise pitch at the start of the sentence")]
        protected float _chanceStartToneUp = 0.3f;
        [SerializeField]
        [Tooltip("the chance to lower pitch at the start of the sentence")]
        protected float _chanceStartToneDown = 0.3f;
        [SerializeField]
        [Tooltip("the chance to change pitch at the mid of the sentence (in a sentence, there are only one raise and one lower allowed)")]
        protected float _chanceMidToneChange = 0.035f;
        [SerializeField]
        [Tooltip("the chance to change pitch at the last clip of the sentence")]
        protected float _chanceEndToneChange = 0.4f;

        ///------------------fade--------------------///
        [SerializeField][Tooltip("")]
        protected bool _doVolumeFade = true;
        [SerializeField][Tooltip("")]
        protected bool _doPitchFade = true;

        ///------------------properties------------------///
        //public List<SoundData> audios { get { return _audios; } }
        public AudioSource pfAudioSource { get { return _pfAudioSource; } }
        public AudioSource pfNoise { get { return _pfNoise; } }
        public List<SoundData> soundDatas { get { return _soundDatas; } }
        public List<AudioClip> noiseClips { get { return _noiseClips; } }
        public Vector2 shortPauseRange { get { return _shortPauseRange; } }
        public Vector2 longPauseRange { get { return _longPauseRange; } }
        public Vector2 randomPauseRange { get { return _randomPauseRange; } }
        public double avgSoundGroupSize { get { return _avgSoundGroupSize; } }
        public float chanceStartToneUp { get { return _chanceStartToneUp; } }
        public float chanceStartToneDown { get { return _chanceStartToneDown; } }
        public float chanceMidToneChange { get { return _chanceMidToneChange; } }
        public float chanceEndToneChange { get { return _chanceEndToneChange; } }
        public bool doVolumeFade { get { return _doVolumeFade; } set { _doVolumeFade = value; } }
        public bool doPitchFade { get { return _doPitchFade; } set { _doPitchFade = value; } }

        #endregion "data"

        #region "public methods"

        void OnEnable()
        {
            _dictSpecAudios.Clear();
            for(int i=0; i<_specificAudios.Count; ++i)
            {
                var st = _specificAudios[i];
                _dictSpecAudios[st.name] = st.data;
            }
        }

        /// <summary>
        /// spawn from the audioSource prefab
        /// </summary>
        public GameObject SpawnAS()
        {
            return PrefabPool.SpawnPrefab(_pfAudioSource.gameObject);
        }

        public AudioSource SpawnNoseNoiseAS()
        {
            var newGO = PrefabPool.SpawnPrefab(_pfNoise.gameObject);
            var source = newGO.AssertGetComponent<AudioSource>();
            source.clip = _noiseClips.RandomGetElem();
            return source;
        }

        public SoundData TryGetSoundBySpecificText(string text)
        {
            SoundData sd;
            _dictSpecAudios.TryGetValue(text, out sd);
            return sd;
        }

        #endregion "public methods"

        #region "private methods"

        //private SoundData _GetSound(float leftTime)
        //{
        //    SoundData data = SoundData.InstAlloc(_audios.RandomGetElem());
        //    return data;
        //}

        #endregion "private methods"
    }

    [Serializable]
    public class SoundData : IRelease
    {
        [SerializeField]
        [Tooltip("the clip to use")]
        protected AudioClip _clip;

        ///------------------volume--------------------///
        [SerializeField]
        [Tooltip("during fade-in/out, the low volume")]
        protected float _lowVolume = 0.3f;
        [SerializeField]
        [Tooltip("during fade-in/out, the high volume")]
        protected float _highVolume = 1f;
        [SerializeField]
        [Tooltip("fade in duration")]
        protected float _volumeFadeInTime = 0.1f;
        [SerializeField]
        [Tooltip("fade out duration")]
        protected float _volumeFadeOutTime = 0.1f;

        ///------------------pitch--------------------///
        [SerializeField]
        [Tooltip("This is ABSOLUTE value, positive only")]
        protected Vector2 _pitchChangeRange = new Vector2(0.1f, 0.2f);
        [SerializeField]
        [Tooltip("time used to change pitch")]
        protected float _pitchChangeTime = 0.1f;

        ///------------------properties--------------------///
        public AudioClip clip { get { return _clip; } }

        public float lowVolume { get { return _lowVolume; } set { _lowVolume = value; } }
        public float highVolume { get { return _highVolume; } set { _highVolume = value; } }
        public float volumeFadeInTime { get { return _volumeFadeInTime; } set { _volumeFadeInTime = value; } }
        public float volumeFadeOutTime { get { return _volumeFadeOutTime; } set { _volumeFadeOutTime = value; } }

        public Vector2 pitchChangeRange { get { return _pitchChangeRange; } set { _pitchChangeRange = value; } }
        public float pitchChangeTime { get { return _pitchChangeTime; } set { _pitchChangeTime = value; } }

        public static SoundData InstAlloc(SoundData d)
        {
            var sd = Mem.New<SoundData>();
            sd._clip = d.clip;
            sd._lowVolume = d._lowVolume;
            sd._highVolume = d._highVolume;
            sd._volumeFadeInTime = d._volumeFadeInTime;
            sd._volumeFadeOutTime = d._volumeFadeOutTime;
            sd._pitchChangeRange = d._pitchChangeRange;
            sd._pitchChangeTime = d._pitchChangeTime;

            return sd;
        }

        public void Release()
        {
            Mem.Del(this);
        }
    }

    [Serializable]
    public class SpecSoundDict : BDict<string, SoundData> { }

    [Serializable]
    public class SpecAudioStruct
    {
        public string name;
        public SoundData data;
    }

}