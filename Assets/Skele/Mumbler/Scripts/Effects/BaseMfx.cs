using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;

namespace MH.Mumbler
{
    public class BaseMfx : SpawnableMonoBehaviour
    {
        #region "conf data"

        [SerializeField][Tooltip("if false, this fx instance will be removed when AS is despawned")]
        protected bool _keepOnFinish = false;

        #endregion "conf data"

        #region "data"

        public bool keepOnFinish { get { return _keepOnFinish; } set { _keepOnFinish = value; } }

        #endregion "data"

        #region "unity methods"

        protected override void _OnStart()
        {
            base._OnStart();
        }

        #endregion "unity methods"

        #region "public methods"

        #endregion "public methods"
        		
        #region "private methods"
        #endregion "private methods"
    }
}
