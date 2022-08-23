using UnityEngine;
using System.Collections.Generic;
using ExtMethods;
using UnityEngine.UI;
using System.Collections;
using System;

using Random = UnityEngine.Random;

namespace MH.Mumbler
{
    public class AuditionRoomCtrl : MonoBehaviour
    {
        public MumbleSpeak _mumbleSpeak;
        public Animator _actorAnimator;
        public Texture2D _guiback = null;

        private MPB_SetColor _color;
        private Text _actorName;
        private RandomSpeak2 _rndSpeak = null;

        private Vector2 _scrollPos;

        void Start()
        {
            Dbg.CAssert(this, _mumbleSpeak != null, "AuditionRoomCtrl.Start : _mumbleSpeak is null");
            Dbg.CAssert(this, _actorAnimator != null, "AuditionRoomCtrl.Start : _actorAnimator is null");
            _color = this.AssertGetComponentInChildren<MPB_SetColor>();
            _actorName = this.AssertGetComponentInChildren<Text>();
            _rndSpeak = this.AssertGetComponent<RandomSpeak2>();
            _mumbleSpeak.activeSoundLib.CollectAllSpeaker();
            _color.Color = Random.ColorHSV();
            _actorName.text = _rndSpeak.speakerName;
            _Start();
        }

        void OnGUI()
        {
            float HEIGHT = 60f;
            float BTNW = 120f;
            float BTNH = 36f;
            Rect rc = new Rect(0, Screen.height - HEIGHT, Screen.width, HEIGHT);
            //Rect rc2 = new Rect(0, Screen.height - HEIGHT, Screen.width - 100f, HEIGHT);
            GUI.DrawTexture(rc, _guiback, ScaleMode.StretchToFill, true);
            GUILayout.BeginArea(rc);
            GUILayout.BeginHorizontal();
            {
                _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.Height(HEIGHT), GUILayout.Width(Screen.width - 100f));
                {
                    GUILayout.BeginHorizontal();
                    var names = _mumbleSpeak.activeSoundLib.speakerNames;
                    for (int i = 0; i < names.Count; ++i)
                    {
                        string oneName = names[i];
                        if (GUILayout.Button(oneName, GUILayout.Width(BTNW), GUILayout.Height(BTNH)))
                        {
                            _ChangeSpeaker(oneName);
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndScrollView();

                //GUIUtil.PushGUIColor(_rndSpeak.isTalking ? Color.red : Color.green);
                if (GUILayout.Button(_rndSpeak.isTalking ? "STOP" : "GO", GUILayout.Height(HEIGHT - 4f), GUILayout.Width(95f)))
                {
                    if (_rndSpeak.isTalking)
                        _Stop();
                    else
                        _Start();
                }
                //GUIUtil.PopGUIColor();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void _Start()
        {
            _rndSpeak.Speak();
        }

        private bool _isChangingSpeaker = false;
        private void _ChangeSpeaker(string spName)
        {
            StartCoroutine(_CoChangeSpeaker(spName));
        }

        private IEnumerator _CoChangeSpeaker(string oneName)
        {
            if (_isChangingSpeaker)
                yield break;

            if (_rndSpeak.speakerName != oneName ||
                !_rndSpeak.isTalking)
            {
                _isChangingSpeaker = true;

                _Stop();

                while (_rndSpeak.isTalking)
                { //wait for talking end
                    yield return null;
                }

                if (_rndSpeak.speakerName != oneName)
                    _color.Color = Random.ColorHSV();

                _rndSpeak.speakerName = oneName;
                _Start();
                _actorName.text = oneName;

                _isChangingSpeaker = false;
            }
        }

        private void _Stop()
        {
            _rndSpeak.Stop();
        }

        void Update()
        {
            if( _rndSpeak.isTalking )
            {
                if(!_actorAnimator.IsInTransition(0) && 
                    _actorAnimator.GetCurrentAnimatorStateInfo(0).IsName("empty"))
                {
                    _actorAnimator.CrossFade("clip" + Random.Range(1, 8), 0.1f);
                }
            }

            _actorName.color = _rndSpeak.isTalking ? Color.green : Color.white;
        }
    }

}
