using ExtMethods;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH.Mumbler
{
    public class AutoRelease_AudioSource : MonoBehaviour
    {
        protected AudioSource _as;
        protected SpeakContext _ctx;

        public SpeakContext ctx { get { return _ctx; } set { _ctx = value; } }

        void Awake()
        {
            _as = this.AssertGetComponent<AudioSource>();
        }


        void Update()
        {
            if( !_as.isPlaying )
            {
                _ctx.runningSources.Remove(_as);
                PrefabPool.DespawnPrefab(gameObject, true);
            }
        }
    }
}
