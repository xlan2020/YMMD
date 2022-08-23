using UnityEngine;
using System;
using System.Collections.Generic;
using ExtMethods;

using Random = UnityEngine.Random;
using System.Collections;

namespace MH.Mumbler
{
    public class RandomSpeak : SpawnableMonoBehaviour
    {
        #region "conf data"
        [SerializeField]
        [Tooltip("will choose one from the list when spawned")]
        protected List<SpeakerData> _speakers = new List<SpeakerData>();

        [SerializeField]
        [Tooltip("the current chosen speaker")]
        private SpeakerData _curSpeaker = null;

        [SerializeField]
        [Tooltip("the control mode for speaker\nmanual means trigger by script\nautomatic means it will automatically speak as long as the behaviour is enabled")]
        protected ESpeakMode _eMode = ESpeakMode.Automatic;

        [SerializeField]
        [Tooltip("randomly decide the speak session duration")]
        protected Vector2 _speakDurationRange = new Vector2(0.5f, 4f);

        [SerializeField]
        [Tooltip("only take effect under Automatic mode, decide the pause interval between session")]
        protected Vector2 _intervalBetweenSession = new Vector2(2f, 4f);

        #endregion "conf data"

        #region "data"

        private Transform _tr;
        private Coroutine _coSpeak;
        private float _restTimeTarget = 0;
        private float _restTime = 0;

        public ESpeakMode speakMode { get { return _eMode; } set { _eMode = value; } }
        public SpeakerData curSpeaker { get { return _curSpeaker; } set { _curSpeaker = value; } }
        public string speakerName
        {
            get { return _curSpeaker.name; }
            set
            {
                SpeakerData sd = MumbleSpeak.Instance.activeSoundLib.GetSpeaker(value);
                if (sd == null)
                {
                    Dbg.LogWarn("RandomSpeak.speakerName.set: unexpected speakerName: {0}", value);
                }
                else
                {
                    curSpeaker = sd;
                }
            }
        }
        public bool isTalking { get { return _coSpeak != null; } }

        #endregion "data"

        #region "unity methods"

        void Awake()
        {
            _tr = transform;
            Dbg.CAssert(this, _speakers.Count > 0, "RandomSpeak.Awake: speakers array is empty");
        }

        protected override void _OnSpawn()
        {
            base._OnSpawn();
            _DecideCurrentSpeaker();
        }

        protected override void _OnDespawn()
        {
            base._OnDespawn();
            Stop();
        }

        void Update()
        {
            if (_eMode == ESpeakMode.Automatic)
            {
                if (isTalking)
                {
                    _restTime = 0;
                }
                else
                {
                    _restTime += Time.deltaTime;
                    if (_restTime > _restTimeTarget)
                    {
                        Speak();
                    }
                }
            }
        }

        #endregion "unity methods"

        #region "public methods"



        public void Speak()
        {
            if (!isTalking)
                StartCoroutine(_CoSpeak());
        }

        public void Stop()
        {
            if (isTalking)
            {
                MumbleSpeak.Instance.StopSpeak(_coSpeak);
                _coSpeak = null;
            }
        }

        #endregion "public methods"

        #region "private methods"

        private IEnumerator _CoSpeak()
        {
            float time = Random.Range(_speakDurationRange.x, _speakDurationRange.y);
            _coSpeak = MumbleSpeak.Instance.Speak(time, speakerName, _tr);
            yield return _coSpeak;
            _coSpeak = null;

            if (_eMode == ESpeakMode.Automatic)
                _restTimeTarget = Random.Range(_intervalBetweenSession.x, _intervalBetweenSession.y);
        }

        private void _DecideCurrentSpeaker()
        {
            _curSpeaker = _speakers.RandomGetElem();
        }
        #endregion "private methods"
    }

    public enum ESpeakMode
    {
        Manual,
        Automatic,
    }

}
