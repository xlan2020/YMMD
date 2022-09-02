using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset BeginningInkJSON;
    public UI_Inventory uiInventory;
    public UI_Money uiMoney;

    public bool HasBeginningDialogue = true;
    public Inventory inventory;
    Money money;

    void Awake()
    {
        Application.targetFrameRate = 60;

        inventory = new Inventory();
        if (uiInventory)
        {
            uiInventory.SetInventory(inventory);
        }
        inventory.SetItemList(StaticInventory.ItemArry);

        money = new Money();
        if (uiMoney)
        {
            uiMoney.SetMoney(money);
        }
        money.SetMoney(StaticInventory.MoneyAmount);
    }

    void Start()
    {
        if (HasBeginningDialogue)
        {
            // load the dialogue for this scene
            InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
        }
    }

    public void SaveInventory()
    {
        StaticInventory.ItemArry = inventory.GetItemList();
    }

    public void DisplaceItemAtSlot(ItemSlot slot)
    {
        if (slot == null)
        {
            UnityEngine.Debug.Log("Can't displace because slot is empty!");
            return;
        }
        money.ChangeMoney(slot.item.price);
        inventory.RemoveItemAtIndex(slot.uiIndex);
    }

    public void AddItemToInventory(Item item)
    {
        inventory.AddItem(item);
    }

    public void AddMoney(float amount)
    {
        money.ChangeMoney(amount);
    }

    public void BuyItem(Item item)
    {
        if (money.GetMoney() - item.storePrice < 0)
        {
            // money not enough to buy
            UnityEngine.Debug.Log("not enough money!");
        }
        else
        {
            // buy item
            AddMoney(-item.storePrice);
            AddItemToInventory(item);

        }

    }
}
