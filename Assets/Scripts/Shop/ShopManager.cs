using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopItemListScriptableObject initialItems;  // 初始货架物品列表
    public ShopItemListScriptableObject randomItems;   // 随机刷新物品列表
    public List<Transform> itemSlots;                  // Hierarchy中的物品格子列表
    public Text walletText;                            // 显示玩家金钱的UI
    public Text desText;                               // 描述文本
    public Text priceText;                             // 价格文本
    public Button buyButton;                           // 全局的购买按钮
    public Button refreshButton;                       // 刷新按钮
    public GameObject popup;                           // 购买提示弹窗
    public float playerMoney = 1000;                   // 玩家金钱
    private List<ItemScriptableObject> currentItems;   // 当前显示的物品
    private ItemScriptableObject selectedItem;         // 当前选中的物品
    private Transform selectedSlot;                    // 当前选中的物品格子
    private List<ItemScriptableObject> randomList;

    void Start()
    {
        // 初始化商店
        LoadInitialItems();
        UpdateWalletDisplay();
        randomList = new List<ItemScriptableObject>(randomItems.items);
        // 隐藏购买按钮，直到选中物品
        buyButton.gameObject.SetActive(false);
        buyButton.onClick.AddListener(OnBuyButtonPressed);  // 将购买按钮关联到点击事件

        // 关联刷新按钮的点击事件
        refreshButton.onClick.AddListener(OnRefreshButtonPressed);
    }

    void LoadInitialItems()
    {
        currentItems = new List<ItemScriptableObject>(initialItems.items);
        DisplayItems(currentItems);
    }

    void DisplayItems(List<ItemScriptableObject> items)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < items.Count)
            {
                ItemScriptableObject item = items[i];
                Transform slot = itemSlots[i];

                // 设置物品图片
                Image itemImage = slot.GetComponent<Image>(); // 获取Image组件
                itemImage.sprite = item.spriteImage;

                // 设置物品格子的点击事件，点击后选择该物品
                Button slotButton = slot.GetComponent<Button>();  // 将整个物品格子设为按钮
                slotButton.onClick.RemoveAllListeners();  // 清空之前的监听器，防止重复绑定
                slotButton.onClick.AddListener(() => OnSelectItem(item, slot));

                // 确保格子被激活
                slot.gameObject.SetActive(true);
            }
            else
            {
                // 隐藏没有物品的格子
                itemSlots[i].gameObject.SetActive(false);
            }
        }
    }

    // 选中物品时的逻辑
    public void OnSelectItem(ItemScriptableObject item, Transform slot)
    {
        selectedItem = item;  // 设置当前选中的物品
        selectedSlot = slot;  // 记录当前选中的物品格子
        desText.text = item.description;
        priceText.text = item.storePrice.ToString();

        // 显示全局的购买按钮
        buyButton.gameObject.SetActive(true);
    }

    // 购买按钮点击时的逻辑
    public void OnBuyButtonPressed()
    {
        if (selectedItem == null)
        {
            Debug.Log("没有选中任何物品！");
            return;
        }

        if (playerMoney >= selectedItem.storePrice)
        {
            playerMoney -= selectedItem.storePrice;
            currentItems.Remove(selectedItem);  // 从当前物品列表中移除选中物品
            UpdateWalletDisplay();

            // 隐藏已购买的物品格子
            selectedSlot.gameObject.SetActive(false);

            // 隐藏购买按钮，重置选中物品
            buyButton.gameObject.SetActive(false);
            selectedItem = null;

            // 弹出获得物品的提示
            ShowItemAcquiredPopup();
        }
        else
        {
            Debug.Log("钱不够了！");
        }
    }

    void ShowItemAcquiredPopup()
    {
        popup.SetActive(true);
        // 这里可以进一步配置弹窗内容，比如显示刚刚获得的物品信息
    }

    void UpdateWalletDisplay()
    {
        walletText.text = "钱包: " + playerMoney + " 金币";
    }

    // 刷新按钮点击时的逻辑
    public void OnRefreshButtonPressed()
    {
        // 清空当前的物品格子
        foreach (Transform slot in itemSlots)
        {
            slot.gameObject.SetActive(false);  // 隐藏每个物品格子
        }

        // 随机选择新的一组物品
        List<ItemScriptableObject> randomSelection = new List<ItemScriptableObject>();
        for (int i = 0; i < itemSlots.Count; i++)
        {
            ItemScriptableObject newItem = randomItems.items[Random.Range(0, randomList.Count)];
            randomSelection.Add(newItem);
        }

        // 显示新的物品
        DisplayItems(randomSelection);
    }
}
