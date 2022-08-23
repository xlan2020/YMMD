using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ExtMethods;

namespace MH.Mumbler
{
    [CustomEditor(typeof(RandomSpeak))]
    public class RandomSpeakEditor : Editor
    {
        #region "data"

        private SerializedProperty _curSpeaker;
        private SerializedProperty _speakers;
        private SerializedProperty _eMode;
        private SerializedProperty _speakDurationRange;
        private SerializedProperty _intervalBetweenSession;

        #endregion "data"

        #region "unity methods"

        void OnEnable()
        {
            _curSpeaker = serializedObject.FindProperty("_curSpeaker");
            _speakers = serializedObject.FindProperty("_speakers");
            _eMode = serializedObject.FindProperty("_eMode");
            _speakDurationRange = serializedObject.FindProperty("_speakDurationRange");
            _intervalBetweenSession = serializedObject.FindProperty("_intervalBetweenSession");

            Dbg.CAssert(this, _curSpeaker != null, "RandomSpeakEditor.OnEnable : _curSpeaker is null");
            Dbg.CAssert(this, _speakers != null, "RandomSpeakEditor.OnEnable : _speakers is null");
            Dbg.CAssert(this, _eMode != null, "RandomSpeakEditor.OnEnable : _eMode is null");
            Dbg.CAssert(this, _speakDurationRange != null, "RandomSpeakEditor.OnEnable : _speakDurationRange is null");
            Dbg.CAssert(this, _intervalBetweenSession != null, "RandomSpeakEditor.OnEnable : _intervalBetweenSession is null");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if(Application.isPlaying)
                EditorGUILayout.PropertyField(_curSpeaker);

            EditorGUILayout.PropertyField(_speakers, true);
            EditorGUILayout.PropertyField(_eMode);
            EditorGUILayout.PropertyField(_speakDurationRange);
            if ( _eMode.enumValueIndex == (int)ESpeakMode.Automatic )
            {
                EditorGUILayout.PropertyField(_intervalBetweenSession);
            }

            serializedObject.ApplyModifiedProperties();
        }

        #endregion "unity methods"

        #region "public methods"
        #endregion "public methods"

        #region "private methods"
        #endregion "private methods"
    }
}
