using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MH
{
    [System.Serializable]
    public class Counter
    {
        [SerializeField]
        private float m_Thres = 0;
        [SerializeField]
        private float m_val = 0;
        private bool m_bRunning;
        private bool m_bAutoRewind;
        private bool m_bAutoStop;

        public Counter() : this(0, 0)
        { }

        public Counter(float thres, float curVal = 0)
        {
            m_Thres = thres;
            m_val = curVal;
            m_bRunning = true;
            m_bAutoRewind = true;
            m_bAutoStop = false;
        }

        public float Threshold
        {
            get { return m_Thres; }
            set { m_Thres = value; }
        }

        public float CurVal
        {
            get { return m_val; }
            set { m_val = value; }
        }

        /**
         * return true iff time up
         */
        public bool Update(float v)
        {
            if (!m_bRunning)
                return false;

            m_val += v;
            if (m_val > m_Thres)
            {
                if (m_bAutoRewind)
                    m_val = 0;
                if (m_bAutoStop)
                    m_bRunning = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetRunning(bool bRun)
        {
            bool bPrev = m_bRunning;
            m_bRunning = bRun;
            return bPrev;
        }

        public void Stop()
        {
            SetRunning(true);
            Rewind();
        }

        public void Rewind()
        {
            m_val = 0;
        }

        /// <summary>
        /// set val to thres, so next update will return true
        /// </summary>
        public void SetToMax()
        {
            m_val = m_Thres;
        }

        public void SetAutoRewind(bool bVal)
        {
            m_bAutoRewind = bVal;
        }

        /// <summary>
        /// if true, when reach threshold, bRunning will be set to false
        /// you need to manually set running again
        /// </summary>
        public void SetAutoStop(bool bVal)
        {
            m_bAutoStop = bVal;
        }

        public float GetLeftTime()
        {
            return m_Thres - m_val;
        }
    }


#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(Counter))]
    public class CounterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Rect tmp = position;
            tmp.width = position.width * 0.3f;
            Rect rcLabel = tmp;

            tmp.x = tmp.xMax + position.width * 0.05f;
            tmp.width = position.width * 0.3f;
            Rect rcVal = tmp;

            tmp.x = tmp.xMax;
            tmp.width = position.width * 0.05f;
            Rect rcSlash = tmp;

            tmp.x = tmp.xMax;
            tmp.width = position.width * 0.3f;
            Rect rcThres = tmp;

            var propThres = property.FindPropertyRelative("m_Thres");
            var propVal = property.FindPropertyRelative("m_val");

            EditorGUI.LabelField(rcLabel, label);
            propVal.floatValue = EditorGUI.FloatField(rcVal, propVal.floatValue);
            EditorGUI.LabelField(rcSlash, "/");
            propThres.floatValue = EditorGUI.FloatField(rcThres, propThres.floatValue);

            EditorGUI.EndProperty();
        }
    }

#endif
}

