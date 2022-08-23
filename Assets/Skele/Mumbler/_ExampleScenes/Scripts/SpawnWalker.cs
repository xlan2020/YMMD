using System;
using System.Collections.Generic;
using UnityEngine;
using ExtMethods;
using Random = UnityEngine.Random;

namespace MH.Mumbler
{
    public class SpawnWalker : MonoBehaviour
    {
        #region "conf data"

        public GameObject _pfChara;
        public int _maxCnt = 20;

        #endregion "conf data"

        #region "data"

        #endregion "data"
                
        #region "unity methods"

        void Awake()
        {
            Dbg.CAssert(this, _pfChara != null, "SpawnWalker.Awake : _pfChara is null");
        }

#if ! ( UNITY_IOS || UNITY_ANDROID )
        void OnGUI()
        {
            GUILayout.Label("W/S/A/D to orbit camera\n");

            GUIUtil.PushGUIEnable(transform.childCount < _maxCnt);
            if(GUILayout.Button("Spawn New", GUILayout.Height(60f)))
            {
                Vector2 p = Random.insideUnitCircle;
                Vector3 pos = new Vector3(p.x, Y_POS, p.y);
                Spawn(pos);
            }
            GUIUtil.PopGUIEnable();
        }

#else
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 p = Random.insideUnitCircle;
                Vector3 pos = new Vector3(p.x, Y_POS, p.y);
                Spawn(pos);
            }
        }
#endif

        #endregion "unity methods"
                
        #region "public methods"

        public void Spawn(Vector3 pos)
        {
            GameObject go = PrefabPool.SpawnPrefab(_pfChara);
            Transform tr = go.transform;
            tr.position = pos;
            tr.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Misc.AddChild(transform, tr);

            RandomWalk walk = tr.AssertGetComponentInChildren<RandomWalk>();
            walk.Init();
        }

        #endregion "public methods"

        #region "private methods"
        #endregion "private methods"

        #region "constants"
        private const float Y_POS = 1f;
        #endregion "constants"

    }

}
