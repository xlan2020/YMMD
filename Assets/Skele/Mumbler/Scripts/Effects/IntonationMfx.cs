using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;

using Random = UnityEngine.Random;

namespace MH.Mumbler
{
    /// <summary>
    /// this fx is used to change the intonation of the audiosource by modify the pitch 
    /// </summary>
    public class IntonationMfx : BaseMfx
    {
        #region "conf data"

        #endregion "conf data"

        #region "data"
        protected AudioSource _as;

        protected float _time = 0f;
        protected float _modSpeed = 0;

        protected EIntonFlag _eInton = EIntonFlag.None;
        protected float _pitchChange = 0.3f;
        protected float _toneChangeDuration = 0.2f;

        ///-----------------------------------------------///

        public float pitchModMag { get { return _pitchChange; } set { _pitchChange = value; } }

        #endregion "data"

        #region "unity methods"

        void Awake()
        {
            _as = this.AssertGetComponentInParent<AudioSource>();
        }

        void Update()
        {
            if( _time < _toneChangeDuration )
            {
                switch (_eInton)
                {
                    case EIntonFlag.Up: _as.pitch += Time.deltaTime * _modSpeed; break;
                    case EIntonFlag.Down: _as.pitch -= Time.deltaTime * _modSpeed; break;
                }
                _time += Time.deltaTime;
            }

        }

        protected override void _OnSpawn()
        {
            base._OnSpawn();
        }

        protected override void _OnDespawn()
        {
            base._OnDespawn();
        }

        #endregion "unity methods"

        #region "public methods"

        public void Prepare(SpeakContext ctx, SoundData soundData, EIntonFlag intonFlag, float basePitch)
        {
            _eInton = intonFlag;
            _as.pitch = basePitch;
            _pitchChange = Random.Range(soundData.pitchChangeRange.x, soundData.pitchChangeRange.y); //abs value
            _toneChangeDuration = soundData.pitchChangeTime;
            _modSpeed = _pitchChange / _toneChangeDuration;
            _time = 0;
        }

        #endregion "public methods"

        #region "private methods"
        #endregion "private methods"

        
    }

}
