//#define PREFABPOOL_LOG

using UnityEngine;
using System.Collections.Generic;
using System;
using ExtMethods;

namespace MH
{
    using REGCONT = System.Collections.Generic.Dictionary<UnityEngine.GameObject, MH.PrefabPool>;
    
    /// <summary>
    /// this pool is used in inspector, only handle prefab
    ///
    /// NOTE: By default, the spawn & despawn will maintain the local PRS
    /// </summary>
    [AddTag(TAG_PREFABPOOLS)]
    public class PrefabPool : MonoBehaviour, IPool
    {

        #region "configurable data"
        // configurable data
        [SerializeField]
        private List<GameObject> m_cont = null; //the container
        [SerializeField]
        private string m_poolName = null; //the pool name, couldn't be same with any other pool    

        [SerializeField]
        private GameObject m_prefab = null; //the prefab used for cloning
        [SerializeField]
        private bool m_bAllowDespawnExtObj = false; //if true, then we could despawn some not-in-pool objects
        public int m_warnSize = -1; // if >0 and reach this size, log a waning

        #endregion

        #region "data"
        // data
        private int m_spawnedCnt = 0; //total spawned obj cnt
        private int m_despawnedCnt = 0; //total despawned obj cnt
        private bool m_Destroying = false; //prevent double OnDestroy()

        private bool m_Registered = false; //flag to indicate whether this pool is registered
        
        private static REGCONT m_RegCont = new REGCONT();

        #endregion

        #region "unity event handlers"
        // unity event handlers
        void Awake()
        {
            if (m_cont == null) //if the component is added at runtime, this will be effective
                m_cont = new List<GameObject>();
        }

        void Start()
        {
            Dbg.Assert(m_poolName != null, "PrefabPool.Start: poolName is null");
            RegToMgr(); //only register if not yet
        }

        public void OnDestroy()
        {
            if( !m_Destroying )
            {
#if PREFABPOOL_LOG
                Dbg.Log("PrefabPool.OnDestroy: id: {0}", gameObject.GetInstanceID());
#endif
                m_Destroying = true;
                Clear(false);

                if( PoolMgr.HasInst)
                    PoolMgr.Instance.Remove(m_poolName);
            }            
        }

        /// <summary>
        /// clear the GameObjects
        /// </summary>
        /// <param name="bAllClear">if true, then even in-use objects are destroyed too</param>
        public void Clear(bool bAllClear)
        {
#if PREFABPOOL_LOG
            Dbg.Log("PrefabPool.Clear: current count:{0}", m_cont.Count);
#endif
            for (var ie = m_cont.GetEnumerator(); ie.MoveNext(); )
            {
                GameObject o = ie.Current;
                if (!o)
                    continue;
                if (bAllClear || !o.activeSelf)
                {
                    GameObject.Destroy(o);
                }
            }

            m_cont.Clear();
        }
        #endregion

        #region "public method"
        // public method

        public GameObject Prefab
        {
            get { return m_prefab; }
            set { m_prefab = value; }
        }

        public string Name
        {
            get { return m_poolName; }
            set { m_poolName = value; }
        }

        public bool AllowDespawnExtObj
        {
            get { return m_bAllowDespawnExtObj; }
            set { m_bAllowDespawnExtObj = value; }
        }

        public int SpawnCnt
        {
            get { return m_spawnedCnt; }
        }

        public int DespawnCnt
        {
            get { return m_despawnedCnt; }
        }

        public int ObjOut
        {
            get { return m_spawnedCnt - m_despawnedCnt; }
        }

        public bool IsPoolObj(GameObject obj)
        {
            return m_cont.Contains(obj);
        }

        public void RegToMgr()
        {
            if (m_Registered)
                return;

            m_Registered = true;

            PoolMgr.Instance.Add(this); //will assert if the name is occupied
            
            GameObject prefab = this.Prefab;
            m_RegCont[prefab] = this;
#if PREFABPOOL_LOG
            Dbg.Log("PrefabPool.RegPrefab: {0} => {1}, prefabID: {2}", prefab, this, prefab.GetInstanceID());
#endif
        }
        
        /// <summary>
        /// SpawnData description:
        /// 1. if has transform parent, then it will be attached to the specified parent, else will be root parent
        /// 2. if has position, then it will set world position, else will be prefab's position
        /// 3. if has rotation, then it will set world rotation, else will be prefab's rotation
        /// </summary>
        public GameObject Spawn(SpawnData data)
        {
            Dbg.Assert(m_prefab != null, "PrefabPool.Spawn: prefab is null");
            Dbg.Assert(m_poolName != null, "PrefabPool.Spawn: poolName is null");

            GameObject spawned = _FindInactiveGO();
            if (spawned == null)
            {
                var pfTr = m_prefab.transform;
                spawned = (GameObject)Instantiate(m_prefab, pfTr.position, pfTr.rotation);
                spawned.name = m_prefab.name;
                m_cont.Add(spawned);
                if (m_warnSize > 0 && m_cont.Count >= m_warnSize)
                {
                    Dbg.LogWarn("PrefabPool.Spawn: pool {0} has {1} elements, limit is {2}", m_poolName, m_cont.Count, m_warnSize);
                }

                //Dbg.Log("pool {0} instantiated a {1}, m_cont: {2}", m_poolName, m_prefab.name, m_cont.Count);
            }

            var spawnTr = spawned.transform;

            // NOTE: it's important to remove from pool BEFORE activating it 
            // as NGUI has a petty behavior that would move any pool that has a ACTIVE UI element to be a child of UIRoot

            _ProcessTransform(spawnTr, ref data);

            ////////////////////////////////////////////////////////////////////////

            spawned.SetActive(true); //set it to in use

            var option = spawned.GetComponent<PoolTicketOption>();
            if (option && option.broadcastSpawnMsg)
            {
                spawned.BroadcastMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                spawned.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver); //SendMsg won't send to inactive obj
            }

            // get PoolTicket, fill in this pool so it can be despawn from the object
            PoolTicket ticket = spawned.ForceGetComponent<PoolTicket>();
            ticket.Pool = this;
            ticket.IsAvail = false;

            return spawned;
        }
        public GameObject Spawn()
        {
            return Spawn(SpawnData.Create());
        }
        object IPool.Spawn()
        {
            return Spawn();
        }

        private static void _ProcessTransform(Transform spawnTr, ref SpawnData data)
        {
            Vector3 prevLocalPos = spawnTr.localPosition;
            Quaternion prevLocalRot = spawnTr.localRotation;
            Vector3 prevLocalScale = spawnTr.localScale;

            if ( data.HasParentTr() )
            {
                Misc.AddChild(data.tr, spawnTr);
            }
            else
            {
                Misc.AddChild((Transform)null, spawnTr);
            }

            // set position and rotation if has data
            if (data.HasWorldPos())
                spawnTr.position = data.pos;
            else
                spawnTr.localPosition = prevLocalPos;

            if (data.HasWorldRot())
                spawnTr.rotation = data.rot;
            else
                spawnTr.localRotation = prevLocalRot;

            // if has specified localScale, use it; 
            // else if set to keep prefab.localScale, revert to prevLocalScale
            // else just keep the current localScale which is modified during AddChild
            if (data.HasScale())
                spawnTr.localScale = data.lscale;
            else if(data.IsKeepLocalScale())
                spawnTr.localScale = prevLocalScale;
        }

        public void Despawn(object obj, DespawnData data)
        {
            GameObject go = obj as GameObject;
            Dbg.Assert(go != null, "PrefabPool.Despawn: not a gameobject");
            Transform tr = go.transform;            

            int idx = m_cont.IndexOf(go);

            if (!m_bAllowDespawnExtObj)
            {
                Dbg.Assert(idx != -1, "PrefabPool.Despawn: cannot find given object in container");

            }
            else
            {
                if( idx == -1 )                
                {
                    m_cont.Add(go);
#if PREFABPOOL_LOG
                    Dbg.Log("PrefabPool.Despawn: an external object is despawned into pool \"{0}\", name: {1}", m_poolName, go.name);
#endif
                }
            }

            PoolTicket ticket = go.ForceGetComponent<PoolTicket>();
            ticket.Pool = this;
            ticket.IsAvail = true;
            Dbg.Assert(ticket.RefCnt == 0, "PrefabPool.Despawn: the refCnt is {0}, should be zero: '{1}'", ticket.RefCnt, ticket.name);
            ticket.RefCnt = 0;

            PoolTicketOption option = go.GetComponent<PoolTicketOption>();

            if( option && option.broadcastDespawnMsg )
            {
                go.BroadcastMessage("OnDespawn", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                go.SendMessage("OnDespawn", SendMessageOptions.DontRequireReceiver);
            }

            go.SetActive(false); // it's important to deactivate before add to pool, BECAUSE OF NGUI

            ///////////////// meddle with the transform ///////////////////////

            Vector3 prevLocalPos = tr.localPosition;
            Quaternion prevLocalRot = tr.localRotation;
            Vector3 prevLocalScale = tr.localScale;
            Misc.AddChild(gameObject, go, false);

            if( data.IsKeepLocalP() )
                tr.localPosition = prevLocalPos;
            if( data.IsKeepLocalR() )
                tr.localRotation = prevLocalRot;
            if( data.IsKeepLocalS() )
                tr.localScale = prevLocalScale;
        }

        public void Despawn(object o)
        {
            Despawn(o, DespawnData.Create());
        }

        #endregion

        #region "static method"

        public static PrefabPool GetPoolByPrefab(GameObject prefab)
        {
            //Dbg.Log("PrefabPool.GetPoolByPrefab: {0}, prefabID: {1}", prefab, prefab.GetInstanceID());

            PrefabPool pool = null;
            var ticket = prefab.GetComponent<PoolTicket>();
            if( ticket != null )
            {
                pool = ticket.Pool;
            }

            if( pool == null )
            {
                m_RegCont.TryGetValue(prefab, out pool);
            }
            return pool;
        }

        public static PrefabPool ForceGetPoolByPrefab(GameObject prefab)
        {
            PrefabPool pool = GetPoolByPrefab(prefab);
            if (pool == null)
            {
                pool = _CreatePoolByPrefab(prefab);
            }

            return pool;
        }

        public static GameObject SpawnPrefab(GameObject prefab)
        {
            if( Application.isPlaying )
            {
                PrefabPool pool = ForceGetPoolByPrefab(prefab);
                GameObject go = pool.Spawn();
                return go;
            }
            else
            {
                GameObject go = GameObject.Instantiate(prefab);
                return go;
            }            
        }
        public static GameObject SpawnPrefab(GameObject prefab, SpawnData data)
        {
            if( Application.isPlaying )
            {
                PrefabPool pool = ForceGetPoolByPrefab(prefab);
                GameObject go = pool.Spawn(data);
                return go;
            }
            else
            {
                GameObject go = GameObject.Instantiate(prefab);
                _ProcessTransform(go.transform, ref data);
                return go;
            }            
        }

        public static void DespawnPrefab(GameObject go, bool requireTicket = false)
        {
            DespawnPrefab(go, DespawnData.Create(), requireTicket);
        }

        public static void DespawnPrefab(GameObject go, DespawnData data, bool requireTicket = false)
        {
            PoolTicket ticket = go.GetComponent<PoolTicket>();
            if(ticket != null)
            {
                ticket.Despawn();
            }
            else
            {
                if( requireTicket )
                {
                    Dbg.LogWarn("PrefabPool.DespawnPrefab: cannot find PoolTicket when require it: '{0}'", go.name);
                }
                // else
                // {
                //     PrefabPool pool = ForceGetPoolByPrefab(go);
                //     pool.Despawn(go, data);
                // }
                GameObject.Destroy(go);
            }
        }

        public static int AddRef(GameObject go)
        {
            PoolTicket ticket = go.AssertGetComponent<PoolTicket>();
            ticket.RefCnt++;
            return ticket.RefCnt;
        }

        public static int DecRef(GameObject go)
        {
            PoolTicket ticket = go.AssertGetComponent<PoolTicket>();
            ticket.RefCnt--;

            if(ticket.RefCnt <= 0)
            {
                ticket.Despawn();
            }

            return ticket.RefCnt;
        }

        public static void DestroyPools()
        {
#if PREFABPOOL_LOG
            Dbg.Log("PrefabPool.DestroyPools: {0}", m_RegCont.Count);
#endif
            for (var ie = m_RegCont.GetEnumerator(); ie.MoveNext(); )
            {
                PrefabPool pool = ie.Current.Value;
                if (pool)
                {
                    pool.OnDestroy(); //force destroy, as the pool.OnDestroy will be called after MainCtrl.OnDestroy, it will try to find destroyed PoolMgr, so we need to destroy the pool here.
                    GameObject.Destroy(pool.gameObject); //the pool.OnDestroy will happen at OnDestroy phase
#if PREFABPOOL_LOG
                    Dbg.Log("PrefabPool.DestroyPools: id: {0}", pool.gameObject.GetInstanceID());
#endif
                }
            }
        }

        public static void SubscribeOnDespawn(GameObject go, Action<GameObject> cb)
        {
            PoolTicket ticket = go.GetComponent<PoolTicket>();
            ticket.SubscribeOnDespawn(cb);
        }
        
        #endregion "static method"

        #region "private method"
        // private method
        

        private GameObject _FindInactiveGO()
        {
            for (int i = 0; i < m_cont.Count; ++i)
            {
                var go = m_cont[i];
                if (go.activeSelf == false)
                {
                    var ticket = go.GetComponent<PoolTicket>();
                    if( ticket.IsAvail ) //double-check
                        return m_cont[i];
                }
            }
            return null;
        }

        private static PrefabPool _CreatePoolByPrefab(GameObject prefab)
        {
#if PREFABPOOL_LOG
            Dbg.LogWarn("Prefab._CreatePoolByPrefab: {0}", prefab.name);
#endif

            string poolName = prefab.name + "Pool_" + prefab.GetInstanceID();
            GameObject newPoolGO = new GameObject(poolName);
            PrefabPool pool = newPoolGO.AddComponent<PrefabPool>();
            pool.Prefab = prefab;
            pool.Name = poolName;
            pool.AllowDespawnExtObj = true;
            pool.RegToMgr();

            GameObject prefabPools = GameObject.FindGameObjectWithTag(TAG_PREFABPOOLS);
            if( prefabPools == null )
            {
                prefabPools = new GameObject("PrefabPools");
                prefabPools.tag = TAG_PREFABPOOLS;
            }
            Misc.AddChild(prefabPools, newPoolGO);

            return pool;
        }

        #endregion

        #region "constant data"
        // constant data
        public const string TAG_PREFABPOOLS = "PrefabPools";
#endregion

    }

    public struct DespawnData
    {
        public int flags;

        public const int None = 0;
        public const int KeepLocalP = 1;
        public const int KeepLocalR = 2;
        public const int KeepLocalS = 4;
        public const int KeepLocalPRS = KeepLocalP|KeepLocalR|KeepLocalS;

        public static DespawnData Create(int flag = KeepLocalPRS)
        {
            DespawnData o = new DespawnData();
            o.flags = flag;
            return o;
        }

        public bool IsKeepLocalP() {return (flags & KeepLocalP) != 0; }
        public bool IsKeepLocalR() {return (flags & KeepLocalR) != 0; }
        public bool IsKeepLocalS() {return (flags & KeepLocalS) != 0; }
    }

    public struct SpawnData
    {
        public Vector3 pos;
        public Quaternion rot;
        public Vector3 lscale; //localscale
        public Transform tr;
        public int flags;

        public const int None = 0;
        public const int Pos = 1;
        public const int Rot = 2;
        public const int Scale = 4;
        public const int Tr = 8;
        public const int DontKeepLocalScale = 16;

        public const int PR = 3;

        public void Clear()
        {
            pos = Vector3.zero;
            rot = Quaternion.identity;
            tr = null;
            flags = None;
        }

        // empty, used internally by PrefabPool.Spawn()
        public static SpawnData Create()
        {
            SpawnData ret = new SpawnData();
            return ret;
        }

        // specify the world position
        public static SpawnData Create(Vector3 p)
        {
            SpawnData ret = new SpawnData();
            ret.pos = p;
            ret.flags = Pos;
            return ret;
        }
        // specify the world rotation
        public static SpawnData Create(Quaternion r)
        {
            SpawnData ret = new SpawnData();
            ret.rot = r;
            ret.flags = Rot;
            return ret;
        }
        // specify the parentTransform
        public static SpawnData Create(Transform tr)
        {
            SpawnData ret = new SpawnData();
            ret.tr = tr;
            ret.flags = Tr;
            return ret;
        }
        // specify the world position & world rotation
        public static SpawnData Create(Vector3 p, Quaternion r)
        {
            SpawnData ret = new SpawnData();
            ret.pos = p;
            ret.rot = r;
            ret.flags = PR;
            return ret;
        }
        // specify the world position & parentTransform
        public static SpawnData Create(Vector3 p, Transform tr)
        {
            SpawnData ret = new SpawnData();
            ret.pos = p;
            ret.tr = tr;
            ret.flags = Pos | Tr;
            return ret;
        }
        // specify the world position & world rotation & parentTransform
        public static SpawnData Create(Vector3 p, Quaternion r, Transform tr)
        {
            SpawnData ret = new SpawnData();
            ret.pos = p;
            ret.rot = r;
            ret.tr = tr;
            ret.flags = PR|Tr;
            return ret;
        }

        public SpawnData SetLocalScale(Vector3 scale) 
        {
            flags |= (Scale|DontKeepLocalScale); 
            this.lscale = scale;
            return this;
        }
        public SpawnData SetDontKeepLocalScale() { flags |= DontKeepLocalScale; return this; }

        public bool HasWorldPos() { return (flags & Pos) != 0; }
        public bool HasWorldRot() { return (flags & Rot) != 0; }
        public bool HasScale() {return (flags & Scale) != 0;}
        public bool IsKeepLocalScale() {return (flags & DontKeepLocalScale) == 0;}
        public bool HasParentTr() { return (flags & Tr) != 0; }
    }
}

namespace ExtMethods
{
    public static class PrefabPool_GOExt
    {
        public static void DespawnAllChildren(this GameObject go)
        {
            go.transform.DespawnAllChildren();
        }
    }

    public static class PrefabPool_TransformExt
    {
        public static void DespawnAllChildren(this Transform tr)
        {
            int cnt = tr.childCount;
            for(int i=cnt-1; i>=0; --i)
            {
                Transform aTr = tr.GetChild(i);
                MH.PrefabPool.DespawnPrefab(aTr.gameObject, true);
            }
        }
    }
}