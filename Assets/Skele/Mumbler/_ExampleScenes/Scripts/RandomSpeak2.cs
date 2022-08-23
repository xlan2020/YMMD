using UnityEngine;
using System;
using System.Collections.Generic;
using ExtMethods;

using Random = UnityEngine.Random;
using System.Collections;

namespace MH.Mumbler
{
    public class RandomSpeak2 : MonoBehaviour
    {
        #region "conf data"
        [SerializeField]
        [Tooltip("")]
        protected string _speaker = MumbleSpeak.DefaultVoice;
        [SerializeField]
        [Tooltip("the talk duration")]
        protected Vector2 _timeRange = new Vector2(0.5f, 5f);

        #endregion "conf data"

        #region "data"

        private Transform _tr;
        private Coroutine _coSpeak;

        public string speakerName { get { return _speaker; } set { _speaker = value; } }
        public bool isTalking { get { return _coSpeak != null; } }

        #endregion "data"

        #region "unity methods"

        void Awake()
        {
            _tr = transform;
        }

        void OnDisable()
        {
            _coSpeak = null;
        }

        void Trigger()
        {
            Speak();
        }

        #endregion "unity methods"

        #region "public methods"

        public void Speak()
        {
            if (_coSpeak == null)
                StartCoroutine(_CoSpeak());
        }

        private bool _reqStop = false;
        public void Stop()
        {
            if (_coSpeak != null && !_reqStop)
            {
                MumbleSpeak.Instance.StopSpeak(_coSpeak);
                _reqStop = true;
            }
        }

        #endregion "public methods"

        #region "private methods"

        private IEnumerator _CoSpeak()
        {
            _coSpeak = MumbleSpeak.Instance.Speak(Random.Range(_timeRange.x, _timeRange.y), _speaker, _tr);
            yield return _coSpeak;
            _coSpeak = null;
            _reqStop = false;
        }
        #endregion "private methods"
    }

}
