using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Top-Level Logic")]
    public GameManager gameManager;

    [Header("Shop Special")]
    public ShopItemListScriptableObject initialItems;  // 初始货架物品列表
    public ShopItemListScriptableObject randomItems;   // 随机刷新物品列表

    [Header("Sale Person")]
    public ShopSpeech shopSpeech;
    public TextTyper saleSpeechTyper;
    //public ProfileSwitcher salePersonProfile;

    [Header("UI Store View")]
    public List<ItemSlot> itemSlots;                  // Hierarchy中的物品格子列表
    public Text namePriceText;                             // name文本
    public Text desText;                               // 描述文本
    public DisplaceButton buyButton;                           // 全局的购买按钮
    public Button refreshButton;                       // 刷新按钮
    public Text refreshText;                           // refresh价格
    public UI_DisplaceSuccess buySuccess;                           // 购买提示弹窗

    //public float playerMoney = 1000;                   // 玩家金钱
    private List<ItemScriptableObject> currentItems;   // 当前显示的物品
    private ItemScriptableObject selectedItem;         // 当前选中的物品
    private ItemSlot selectedSlot;                    // 当前选中的物品格子
    private List<ItemScriptableObject> randomList;
    private int refreshTime = 0;
    private int refreshCost = 50;

    void Start()
    {
        // 初始化商店
        LoadInitialItems();
        refreshText.text = refreshCost.ToString();
        randomList = new List<ItemScriptableObject>(randomItems.items);
        // 隐藏购买按钮，直到选中物品
        buyButton.ShowButton(false);
        buyButton.customEvent.AddListener(OnBuyButtonPressed);
        // hide弹窗
        buySuccess.HideResultWindow();
        // 关联刷新按钮的点击事件
        refreshButton.onClick.AddListener(OnRefreshButtonPressed);


        // Speech
        shopSpeech.PlayWelcomeSpeech(saleSpeechTyper);
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
                ItemSlot slot = itemSlots[i];

                // 设置物品图片
                slot.itemImage.sprite = item.spriteImage;

                // 设置物品格子的点击事件，点击后选择该物品
                Button slotButton = slot.selectButton;  // 将整个物品格子设为按钮
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
    public void OnSelectItem(ItemScriptableObject item, ItemSlot slot)
    {
        // clear selection
        foreach (ItemSlot s in itemSlots)
        {
            s.ShowSelfSelected(false);
        }
        slot.ShowSelfSelected(true);

        selectedItem = item;  // 设置当前选中的物品
        selectedSlot = slot;  // 记录当前选中的物品格子

        // display description
        string money = "";
        string name = "";
        string des = "";
        switch (GameEssential.localeId)
        {
            case 0:
                money = "¥";
                name = item.itemName;
                des = item.description;
                break;
            case 1:
                money = "$";
                name = item.itemName_EN;
                des = item.description_EN;
                break;
            default:
                money = "¥";
                name = item.itemName;
                des = item.description;
                break;
        }
        //string displayText = "<color=magenta>[" + money + item.storePrice.ToString() + "]</color> " + name;
        string displayText = name;
        string descriptionText = "<color=magenta>[" + money + item.storePrice.ToString() + "]</color>\n" + des;
        namePriceText.text = displayText;
        desText.text = descriptionText;

        // update talking line, and sale person is preset
        shopSpeech.PlaySaleSpeech(saleSpeechTyper);

        // 显示全局的购买按钮
        buyButton.ShowButton(true);
    }


    // 购买按钮点击时的逻辑
    public void OnBuyButtonPressed()
    {
        if (selectedItem == null)
        {
            Debug.Log("没有选中任何物品！");
            return;
        }

        if (gameManager.GetMoney() >= selectedItem.storePrice)
        {
            Item itemAdded = gameManager.BuyItem(selectedItem);
            currentItems.Remove(selectedItem);  // 从当前物品列表中移除选中物品

            // 隐藏已购买的物品格子
            selectedSlot.gameObject.SetActive(false);

            // 隐藏购买按钮，重置选中物品
            buyButton.ShowButton(false);
            selectedItem = null;

            // 弹出获得物品的提示
            ShowItemAcquiredPopup(itemAdded);

            // speech
            shopSpeech.PlayBuySuccessSpeech(saleSpeechTyper);
        }
        else
        {
            Debug.Log("钱不够了！");
            shopSpeech.PlayNoMoneySpeech(saleSpeechTyper);
        }
    }

    void ShowItemAcquiredPopup(Item item)
    {
        buySuccess.ShowResultWindow_moneyToItem(item);
    }

    // 刷新按钮点击时的逻辑
    public void OnRefreshButtonPressed()
    {
        if (gameManager.GetMoney() >= refreshCost)
        {
            refreshTime++;
            if (refreshTime >= 3)
            {
                refreshCost += refreshTime * 10;
                refreshText.text = refreshCost.ToString();
            }

            //update金钱
            gameManager.AddMoney(-refreshCost);

            // 清空当前的物品格子
            foreach (ItemSlot slot in itemSlots)
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

            // play speech
            shopSpeech.PlayRefreshSpeech(saleSpeechTyper);

        }
        else
        {
            Debug.Log("钱不够了！");
            shopSpeech.PlayNoMoneySpeech(saleSpeechTyper);
        }

    }
}
