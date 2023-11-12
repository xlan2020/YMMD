using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene Start Setup")]
    [SerializeField] TextAsset BeginningInkJSON;
    public LoadInventory loadInventory;
    public float initialMoney;
    
    [Header("UI Element")]
    public UI_Inventory uiInventory;
    public UIDraw_Inventory uiDraw_Inventory;
    public UI_Money uiMoney;
    public DisplaceSFX displaceSFX;

    [Header("Game Element")]

    public bool HasBeginningDialogue = true;
    public Inventory inventory;
    private DialogueVariables dialogueVariables;
    Money money;
    public AllItemScriptableObject allItem;

    //public Camera positionReferenceCamera;

    void Awake()
    {
        Application.targetFrameRate = 60;

        inventory = new Inventory() {
            cashItem = allItem.arrayById[0]
        };

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
            uiDraw_Inventory.gameObject.SetActive(true);
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

        SaveSystem.Init();

    }

    void Start()
    {
        SetMoney(initialMoney);
        Load(1);


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

    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void Save(){

        // clean up data to be saved
        float currMoney = money.GetMoney();
        int[] itemIdArray = inventory.GetItemIdSaveArray();
        bool[] noteUnlockedState = SketchbookData.GetNoteUnlockedSaveArray();

        // serialize to SaveObject json string
        SaveObject saveObject = new SaveObject
        {
            moneyAmount = currMoney,
            itemIdArray = itemIdArray,
            noteUnlockedState = noteUnlockedState
        };
        string json = JsonUtility.ToJson(saveObject);

        // write the save file
        SaveSystem.Save(json);


    }

    private void Load(int saveFileId){
        string saveString = SaveSystem.Load(saveFileId);
        if (saveString != null){

            // convert save data to SaveObject
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            // ****load the game according to the save
            // money
            this.SetMoney(saveObject.moneyAmount);
            // inventory
            inventory.LoadItemListFromIdArray(saveObject.itemIdArray, allItem.arrayById);
            // notes in sketchbook
            SketchbookData.LoadNotesUnlockedStates(saveObject.noteUnlockedState);


        }else {
            UnityEngine.Debug.Log("no save data file");
        }
    }


    /**
    private void dialogueIntegrationTest()
    {
        // UnityEngine.Debug.Log("trying to set global variable test: ");
        // dialogueVariables.SetGlobalVariable("mamaTalk", 10);
        // dialogueVariables.SetGlobalVariable("money", 100);
        this.AddMoney(100f);

    }
    */

    /** LEGACY
    public void SaveInventory()
    {
        StaticInventory.ItemArry = inventory.GetItemList();
    }
    */

    public void DisplaceItem(Item item)
    {
        AddMoney(item.value);
        displaceSFX.PlayItemToMoneySound();
        uiInventory.ShowResultWindow_itemToMoney(item);
        inventory.RemoveItem(item);
    }

    public void DisplaceItemFromDrawing(float moneyIn, ItemScriptableObject itemOut){
        
        AddMoney(-moneyIn);
        Item item = inventory.AddItemFromScriptableObject(itemOut);
        item.value = moneyIn; // modify the value of the item to the user input one
        uiInventory.ShowResultWindow_moneyToItem(item);

        displaceSFX.PlayMoneyToItemSound();
    }

    public void AddItemToInventory(ItemScriptableObject item)
    {
        inventory.AddItemFromScriptableObject(item);

    }

    public void AddMoney(float amount)
    {
        float currAmount = money.GetMoney()+amount;
        money.SetMoney(currAmount);

        updateCashItem();

        dialogueVariables.SetGlobalVariable("money", currAmount);
    }

    public void SetMoney(float amount)
    {
        money.SetMoney(amount);

        updateCashItem();

        if (dialogueVariables!=null){
            dialogueVariables.SetGlobalVariable("money", amount);
        }
    }

    private void updateCashItem(){
        /**
        CASH item always stay at index 0 at the inventory!!
        */
        if (money.GetMoney() <= 0){
            // remove cash item
            inventory.TryRemoveCashItem();
        }else{
            inventory.TryAddCashItem();
        }
    }

    public float GetMoney(){
        return money.GetMoney();
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

    private class SaveObject {
        public float moneyAmount;   // money
        public int[] itemIdArray;   // owned item list, no changed states
        public bool[] noteUnlockedState; // notebook unlock state

        // ink dialogue story progress if any
        // ink dialogue variables

        // current scene

        // if in map, player position
        // if in map, map object collected state
        // if in draw, binary val
        // if in fluid brain, solvable进度别保存了太麻烦了

    }
}
