using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MH
{
    [Serializable]
    public class IntervalTimer
    {
        private float m_prevTime = float.MinValue * 0.1f;
        [SerializeField]
        private float m_interval = 1f;

        public IntervalTimer(float interval)
        {
            m_interval = interval;
        }

        public float interval
        {
            get { return m_interval; }
            set { m_interval = value; }
        }

        public float prevTime
        {
            get { return m_prevTime; }
            set { m_prevTime = value; }
        }

        public void Reset(float newInterval)
        {
            m_interval = newInterval;
            m_prevTime = float.MinValue * 0.1f;
        }

        public void SetPrevTimeToNow()
        {
            m_prevTime = Time.time;
        }

        public bool Peek()
        {
            float curTime = Time.time;
            return curTime - m_prevTime > m_interval;
        }

        public bool Check()
        {
            float curTime = Time.time;
            if( curTime - m_prevTime > m_interval )
            {
                m_prevTime = curTime;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(IntervalTimer))]
    public class IntervalTimerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Rect tmp = position;
            tmp.width = position.width * 0.3f;
            Rect rcLabel = tmp;

            tmp.x = tmp.xMax;
            tmp.width = position.width * 0.2f;
            Rect rcLabel2 = tmp;

            tmp.x = tmp.xMax;
            tmp.width = position.width * 0.5f;
            Rect rcVal = tmp;
            
            var propVal = property.FindPropertyRelative("m_interval");

            EditorGUI.LabelField(rcLabel, label);
            EditorGUI.LabelField(rcLabel2, "Interval");
            propVal.floatValue = EditorGUI.FloatField(rcVal, propVal.floatValue);

            EditorGUI.EndProperty();
        }
    }

#endif
}
