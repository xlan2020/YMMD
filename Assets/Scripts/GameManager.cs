using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset BeginningInkJSON;
    public UI_Inventory uiInventory;
    public UI_Money uiMoney;
    public DisplaceSFX displaceSFX;

    public bool HasBeginningDialogue = true;
    public Inventory inventory;
    private DialogueVariables dialogueVariables;
    Money money;

    public float initialMoney;

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

        displaceSFX = Instantiate(displaceSFX);
    }

    void Start()
    {
        if (HasBeginningDialogue)
        {
            // load the dialogue for this scene
            InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
        }
        // load global ink dialogue variables
        dialogueVariables = InkDialogueManager.GetInstance().GetDialogueVariables();

        // dialogueIntegrationTest();

        SetMoney(initialMoney);
    }

    private void dialogueIntegrationTest()
    {
        // UnityEngine.Debug.Log("trying to set global variable test: ");
        // dialogueVariables.SetGlobalVariable("mamaTalk", 10);
        // dialogueVariables.SetGlobalVariable("money", 100);
        this.AddMoney(100f);

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
        AddMoney(slot.item.price);
        displaceSFX.PlayItemToMoneySound();
        uiInventory.ShowDisplaceResultWindow(slot.item);
        inventory.RemoveItemAtIndex(slot.uiIndex);
    }

    public void AddItemToInventory(Item item)
    {
        inventory.AddItem(item);
    }

    public void AddMoney(float amount)
    {
        money.ChangeMoney(amount);
        dialogueVariables.SetGlobalVariable("money", money.GetMoney());
    }

    public void SetMoney(float amount)
    {
        money.SetMoney(amount);
        dialogueVariables.SetGlobalVariable("money", money.GetMoney());
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
            displaceSFX.PlayBuyItemSound();

        }

    }
}
