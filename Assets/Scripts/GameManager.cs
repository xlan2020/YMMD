using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextAsset BeginningInkJSON;
    public LoadInventory loadInventory;
    public UI_Inventory uiInventory;
    public UIDraw_Inventory uiDraw_Inventory;
    public UI_Money uiMoney;
    public DisplaceSFX displaceSFX;

    public bool HasBeginningDialogue = true;
    public Inventory inventory;
    private DialogueVariables dialogueVariables;
    Money money;

    public float initialMoney;
    //public Camera positionReferenceCamera;

    void Awake()
    {
        Application.targetFrameRate = 60;

        inventory = new Inventory();

        if (loadInventory)
        {
            loadInventory.SetInventory(inventory);
        }
        if (uiInventory != null)
        {
            uiInventory.SetInventory(inventory);
        }
        if (uiDraw_Inventory != null)
        {
            uiDraw_Inventory.SetInventory(inventory);
        }

        inventory.SetItemList(StaticInventory.ItemArry);

        money = new Money();
        if (uiMoney)
        {
            uiMoney.SetMoney(money);
        }
        money.SetMoney(StaticInventory.MoneyAmount);

        if (displaceSFX)
        {
            displaceSFX = Instantiate(displaceSFX);
        }
    }

    void Start()
    {
        if (HasBeginningDialogue)
        {
            // load the dialogue for this scene
            InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
        }

        // load global ink dialogue variables
        InkDialogueManager manager = InkDialogueManager.GetInstance();
        if (manager)
        {
            dialogueVariables = manager.GetDialogueVariables();
        }

        // dialogueIntegrationTest();

        SetMoney(initialMoney);

        //MouseCursor.instance.positionReferenceCamera = positionReferenceCamera;

    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
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

    public void DisplaceItem(Item item)
    {
        AddMoney(item.value);
        displaceSFX.PlayItemToMoneySound();
        uiInventory.ShowDisplaceResultWindow(item);
        inventory.RemoveItem(item);
    }


    public void AddItemToInventory(ItemScriptableObject item)
    {
        inventory.AddItemFromScriptableObject(item);
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


    public void BuyItem(ItemScriptableObject item)
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
