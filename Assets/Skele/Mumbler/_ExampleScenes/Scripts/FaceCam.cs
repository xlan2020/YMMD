using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH.Mumbler
{
    public class FaceCam : SpawnableMonoBehaviour
    {
        public EFace _eFace;

        private Transform _tr;
        private Transform _camTr;

        protected override void _OnStart()
        {
            base._OnStart();
            _tr = transform;
        }

        protected override void _OnSpawn()
        {
            base._OnSpawn();
            _camTr = Camera.main.transform;
        }

        void LateUpdate()
        {
            switch( _eFace )
            {
                case EFace.Z: _tr.rotation = Quaternion.LookRotation(-_camTr.forward); break;
                case EFace.Z_Neg: _tr.rotation = Quaternion.LookRotation(_camTr.forward); break;
            }
            
        }


        public enum EFace
        {
            Z,
            Z_Neg,
        }
    }
}
