using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;

namespace MH.Mumbler
{
    /// <summary>
    /// make owner to follow specified transform
    /// </summary>
    public class FollowTransMfx : BaseMfx
    {
        #region "conf data"

        [SerializeField][Tooltip("")]
        protected Transform _followTarget;

        #endregion "conf data"

        #region "data"

        public Transform followTarget
        {
            get { return _followTarget; }
            set { _followTarget = value; }
        }

        private Transform _tr;
        
        #endregion "data"

        #region "unity methods"
        
        void Awake()
        {
            _tr = transform;
        }

        void LateUpdate()
        {
            if( _followTarget )
                _tr.position = _followTarget.position;
        }

        protected override void _OnSpawn()
        {
            base._OnSpawn();
        }

        protected override void _OnDespawn()
        {
            base._OnDespawn();
            _followTarget = null;
        }

        #endregion "unity methods"

        #region "public methods"

        #endregion "public methods"

        #region "private methods"
        #endregion "private methods"
    }
}
