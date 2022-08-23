using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;

namespace MH.Mumbler
{
    public class SoundFadeMfx : BaseMfx
    {
        #region "conf data"
        

        #endregion "conf data"

        #region "data"
        protected AudioSource _as;

        protected float _totalLen = 0;
        protected float _time = 0f;

        protected float _fadeInSpeed = 0;
        protected float _fadeOutSpeed = 0;

        protected float _fadeInTime = -1f;
        protected float _fadeOutTime = -1f;

        #endregion "data"

        #region "unity methods"

        void Awake()
        {
            _as = this.AssertGetComponentInParent<AudioSource>();
        }

        void Update()
        {
            bool inFadeOut = false;
            if (_time > _totalLen - _fadeOutTime)
            {
                _as.volume -= Time.deltaTime * _fadeOutSpeed;
                inFadeOut = true;
            }
            
            if( !inFadeOut )
            {
                if (_time < _fadeInTime)
                {
                    _as.volume += Time.deltaTime * _fadeInSpeed;
                }
            }

            _time += Time.deltaTime;
        }

        protected override void _OnSpawn()
        {
            base._OnSpawn();
        }

        protected override void _OnDespawn()
        {
            base._OnDespawn();
            _time = 0;
        }

        #endregion "unity methods"

        #region "public methods"

        public void Prepare(SpeakContext ctx, SoundData soundData)
        {
            float low = soundData.lowVolume + ctx.curModVolume;
            float high = soundData.highVolume + ctx.curModVolume;
            _fadeInTime = soundData.volumeFadeInTime;
            _fadeOutTime = soundData.volumeFadeOutTime;
            _totalLen = _as.clip.length; //* (1f / _as.pitch);

            if (_fadeInTime > 0)
            {
                _fadeInSpeed = (high-low) / _fadeInTime;
            }
            if (_fadeOutTime > 0)
            {
                _fadeOutSpeed = (high-low) / _fadeOutTime;
            }
            _as.volume = low;
        }
        
        #endregion "public methods"

        #region "private methods"
        #endregion "private methods"
    }
}
