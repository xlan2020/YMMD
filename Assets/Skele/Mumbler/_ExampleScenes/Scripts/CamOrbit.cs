using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH.Mumbler
{
    public class CamOrbit : MonoBehaviour
    {
        #region "conf data"

        public Transform _pivot;

        public float _horzRotateSpeed = 180f;
        [Tooltip("if true, will ignore horzRotateRange")]
        public bool _allowHorzInfiniteRotate = true;
        public Vector2 _horzRotateRange = new Vector2(-180f, 180f);

        public float _vertRotateSpeed = 60f;
        public Vector2 _vertRotateRange = new Vector2(15f, 70f);

        public float _distSpeed = 7f;
        public Vector2 _distRange = new Vector2(3f, 10f);

        public string _horzAxis = "Mouse X";
        public string _vertAxis = "Mouse Y";

        #endregion "conf data"

        #region "data"

        private Transform _tr;
        private float _horzAngle;
        private float _vertAngle;
        private float _dist;

        #endregion "data"
        		
        #region "unity methods"

        void Awake()
        {
            _tr = transform;

            Dbg.CAssert(this, _pivot != null, "CamOrbit.Awake : _pivot is null");

            ///------------------init--------------------///
            Vector3 diff = _tr.position - _pivot.position;
            Vector3 diffPY = Vector3.ProjectOnPlane(diff, Vector3.up);
            float oriDist = diff.magnitude;
            float pyDist = diffPY.magnitude;

            _dist = Mathf.Clamp(oriDist, _distRange.x, _distRange.y);
            _tr.position = (diff).normalized * _dist + _pivot.position;

            ///------------------vert--------------------///
            diff = _tr.position - _pivot.position;
            diffPY = Vector3.ProjectOnPlane(diff, Vector3.up);
            pyDist = diffPY.magnitude;
            _vertAngle = Mathf.Acos(pyDist / _dist);

            if( _vertAngle < _vertRotateRange.x || _vertAngle > _vertRotateRange.y)
            {
                float clampedAngle = Mathf.Clamp(_vertAngle, _vertRotateRange.x, _vertRotateRange.y);
                Vector3 rotAxis = Vector3.Cross(diff, Vector3.up);
                Quaternion q = Quaternion.AngleAxis(clampedAngle - _vertAngle, rotAxis);
                diff = q * diff;
                _tr.position = _pivot.position + diff;
                _vertAngle = clampedAngle;
            }

            ///------------------horz--------------------///
            _horzAngle = 0;

            ///------------------lookAt--------------------///
            _tr.LookAt(_pivot);
        }

        void Update()
        {
            float horzRot = Input.GetAxis(_horzAxis);
            float vertRot = Input.GetAxis(_vertAxis);
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            ///------------------horz--------------------///
            {
                float horzRotAngle = _horzRotateSpeed * Time.deltaTime * -horzRot;
                // limit by range
                if( ! _allowHorzInfiniteRotate )
                {
                    var newHorzAngle = Mathf.Clamp(_horzAngle + horzRotAngle, _horzRotateRange.x, _horzRotateRange.y);
                    horzRotAngle = newHorzAngle - _horzAngle;
                }
                _horzAngle += horzRotAngle;

                Vector3 diff = _tr.position - _pivot.position;
                Quaternion q = Quaternion.AngleAxis(horzRotAngle, Vector3.up);
                diff = q * diff;
                _tr.position = _pivot.position + diff;
            }

            ///------------------vert--------------------///
            {
                float vertRotAngle = _vertRotateSpeed * Time.deltaTime * vertRot;
                float newAngle = Mathf.Clamp(_vertAngle + vertRotAngle, _vertRotateRange.x, _vertRotateRange.y);
                float angleDiff = newAngle - _vertAngle;
                _vertAngle = newAngle;

                Vector3 diff = _tr.position - _pivot.position;
                Vector3 rotAxis = Vector3.Cross(diff, Vector3.up);
                Quaternion q = Quaternion.AngleAxis(angleDiff, rotAxis);
                diff = q * diff;
                _tr.position = _pivot.position + diff;
            }

            ///------------------scroll--------------------///
            {
                float scrollDist = _distSpeed * Time.deltaTime * -scroll;
                _dist = Mathf.Clamp(scrollDist + _dist, _distRange.x, _distRange.y);
                _tr.position = _pivot.position + (_tr.position - _pivot.position).normalized * _dist;
            }

            _tr.LookAt(_pivot);
        }

        #endregion "unity methods"
        		
        #region "public methods"
        #endregion "public methods"
        		
        #region "private methods"
        #endregion "private methods"

    }
}
