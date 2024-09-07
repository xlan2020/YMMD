using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class NetCafeCreator : MonoBehaviour
{
    [Header("Content Loaded")]
    [SerializeField] private NetCafeContentScriptableObject contentScriptableObject;

    [Header("UI Setup")]
    //public GameObject netCafePrefab;  // NetCafeUIManager的Prefab
    public Transform uiParent;  // NetCafeUIManager放置的父物体（如Canvas）

    private string netCafePrefabAddress = "Assets/prefab/NetCafePrefabs/NetCafeUIPrefab.prefab"; //NetCafePrefab的Addressable地址
    private GameObject netCafeInstance;

    // 按钮点击时调用的创建函数
    public void CreateNetCafe()
    {
        if (netCafeInstance != null)
        {
            Debug.LogError("NetCafe UI already instantiated");
            return;
        }

        if (uiParent == null)
        {
            Debug.LogError("NetCafeCreator: 未添加 UICanvas_MAP");
            return;
        }

        if (contentScriptableObject == null)
        {
            Debug.LogError("NetCafeCreator: 未添加 NetCafeContentSO");
            return;
        }

        Addressables.LoadAssetAsync<GameObject>(netCafePrefabAddress).Completed += OnNetCafePrefabLoaded;
    }

    // 加载 Prefab 完成后的回调函数
    private void OnNetCafePrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Loaded NetCafeUIPrefab");
            GameObject netCafePrefab = handle.Result;

            // 实例化 NetCafeUIPrefab
            netCafeInstance = Instantiate(netCafePrefab, uiParent);

            // 获取 NetCafeUIManager 并加载内容
            NetCafeUIManager uiManager = netCafeInstance.GetComponent<NetCafeUIManager>();

            if (uiManager != null)
            {
                // 将 ScriptableObject 中的内容传递给 NetCafeUIManager
                uiManager.SetContent(contentScriptableObject);

                // 初始化 UI (加载新闻、论坛页面等)
                uiManager.InitializeUI();
            }
            else
            {
                Debug.LogError("NetCafeUIManager 未找到，请检查 Prefab 设置！");
            }
        }
        else
        {
            Debug.LogError("加载 NetCafeUIPrefab 失败！");
        }
    }

}