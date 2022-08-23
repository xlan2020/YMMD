using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;

using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.UI;

namespace MH.Mumbler
{
    public class RandomWalk : MonoBehaviour
    {
        #region "conf data"

        public float _speed = 4f;
        public int _hp = 3;

        #endregion "conf data"

        #region "data"

        private int _startHP = 0;

        private Rigidbody _rb;
        private Transform _tr;

        private RandomSpeak _speak;

        private Text _lblName;
        private MPB_SetColor _mpbColor;

        //private List<GameObject> _inCollisionGO = new List<GameObject>();

        //private bool _doAddForce = true;

        #endregion "data"
        		
        #region "unity methods"

        void Awake()
        {
            _startHP = _hp;
            _rb = this.AssertGetComponent<Rigidbody>();
            _tr = transform;
            _speak = this.GetComponentInChildren<RandomSpeak>();

            _lblName = this.AssertGetComponentInChildren<Text>();
            _mpbColor = this.AssertGetComponentInChildren<MPB_SetColor>();
        }

        void FixedUpdate()
        {
            Vector3 expVel = _speed * (_rb.rotation * Vector3.forward);
            Vector3 curVel = _rb.velocity;
            Vector3 f = expVel - curVel; f.y = 0;
            _rb.AddForce(f, ForceMode.VelocityChange);
        }

        void Update()
        {
            if( _speak )
                _lblName.color = _speak.isTalking ? Color.green : Color.white;
        }

        void OnCollisionEnter(Collision c)
        {
            if (c.gameObject.name == "Ground")
                return;

            Vector3 dir = _rb.velocity.normalized; dir.y = 0;
            _rb.rotation = Quaternion.LookRotation(dir);
            _tr.rotation = _rb.rotation;
            _rb.angularVelocity = Vector3.zero;

            _hp--;
            if( _hp == 0 )
            {
                StartCoroutine(_DoDespawn());
            }
            else if(_hp > 0)
            {
                if( _speak != null )
                    _speak.Speak();
            }

        }

        private IEnumerator _DoDespawn()
        {
            Vector3 ls = _tr.localScale;
            for(int i=0; i<10; ++i)
            {
                _tr.localScale -= 0.1f * Vector3.one;
                yield return new WaitForSeconds(0.03f);
            }
            PrefabPool.DespawnPrefab(gameObject, true);
            _tr.localScale = ls;
        }

        #endregion "unity methods"

        #region "public methods"

        public void Init()
        {
            _hp = _startHP;
            _mpbColor.Color = Random.ColorHSV();
            if( _speak != null )
                _lblName.text = _speak.speakerName;
        }

        #endregion "public methods"

        #region "private methods"

        #endregion "private methods"
    }
}
