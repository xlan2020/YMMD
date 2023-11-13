using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameLanguage language = GameLanguage.CH;

    [Header("Scene Start Setup")]
    public bool HasBeginningDialogue = true;
    [SerializeField] TextAsset BeginningInkJSON;
    public LoadInventory loadInventory;
    public LoadingScene sceneLoader;
    public float initialMoney;

    [Header("UI Element")]
    public UI_Inventory uiInventory;
    public UIDraw_Inventory uiDraw_Inventory;
    public UI_Money uiMoney;
    public InfoBar infoBar;

    [Header("Assets")]
    public DisplaceSFX displaceSFX;
    public AllItemScriptableObject allItem;
    public SceneInfoScriptableObject allSceneInfo;
    public InkStoriesScriptableObject allInkStories;

    //public Camera positionReferenceCamera;
    public Inventory inventory;
    private DialogueVariables dialogueVariables;
    private Dictionary<string, SceneInfo> sceneDict;
    private InkDialogueManager dialogueManager;
    Money money;

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

        sceneDict = allSceneInfo.GetSceneInfoDict();

        // load global ink dialogue variables
        dialogueManager = InkDialogueManager.GetInstance();
        if (dialogueManager)
        {
            dialogueVariables = dialogueManager.GetDialogueVariables();
        }


        SaveSystem.Init();

    }

    void Start()
    {
        SetMoney(initialMoney);

        //Load(1);
        LoadAutoSave();
    }


    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void Save() {

        // clean up data to be saved
        float currMoney = money.GetMoney();
        int[] itemIdArray = inventory.GetItemIdSaveArray();
        bool[] noteUnlockedState = SketchbookData.GetNoteUnlockedSaveArray();
        string sceneId = sceneLoader.GetActiveSceneId();
        bool loadSceneFromStart = true;
        string dialogueVariablesState = dialogueVariables.GetGlobalVariablesJsonState();
        string currentDialogueJson = dialogueManager.GetCurrentStoryJson();
        string currentDialogueState = dialogueManager.GetCurrentStoryJsonState();

        // serialize to SaveObject json string
        SaveObject saveObject = new SaveObject
        {
            moneyAmount = currMoney,
            itemIdArray = itemIdArray,
            noteUnlockedState = noteUnlockedState,
            sceneId = sceneId,
            loadSceneFromStart = loadSceneFromStart,
            dialogueVariablesState = dialogueVariablesState,
            currentDialogueJson = currentDialogueJson,
            currentDialogueState = currentDialogueState
        };
        string json = JsonUtility.ToJson(saveObject);

        // write the save file
        SaveSystem.Save(json);
    }

    public void AutoSave(string nextSceneId) {
        float currMoney = money.GetMoney();
        int[] itemIdArray = inventory.GetItemIdSaveArray();
        bool[] noteUnlockedState = SketchbookData.GetNoteUnlockedSaveArray();
        string sceneId = nextSceneId; // this is different!
        string dialogueVariablesState = "";
        if (InkDialogueManager.GetInstance() != null){
            dialogueVariablesState = InkDialogueManager.GetInstance().GetDialogueVariables().GetGlobalVariablesJsonState();
        }
        // no need to save dialogue state, but need to save variables

        // serialize to SaveObject json string
        SaveObject saveObject = new SaveObject
        {
            moneyAmount = currMoney,
            itemIdArray = itemIdArray,
            noteUnlockedState = noteUnlockedState,
            sceneId = sceneId,
            loadSceneFromStart = true, // for auto save, load from scene start has to be true
            dialogueVariablesState = dialogueVariablesState,
        };
        string json = JsonUtility.ToJson(saveObject);

        // write the save file
        SaveSystem.AutoSave(json);
    }

    public void LoadAutoSave() {
        string saveString = SaveSystem.Load(0);

        if (saveString == null || saveString == ""){
            UnityEngine.Debug.Log("no auto save!");
            if (HasBeginningDialogue)
            {
                // load the dialogue for this scene
                InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
            }
            return;
        } else {
            UnityEngine.Debug.Log("loading auto save...");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            LoadFromSaveObject(saveObject);
            if (saveObject.sceneId != sceneLoader.GetActiveSceneId()){
                sceneLoader.LoadScene(saveObject.sceneId);
            }
        }
    }

    private void Load(int saveFileId){
        string saveString = SaveSystem.Load(saveFileId);
        if (saveFileId == 0){
            LoadAutoSave(); // USE THE LOAD auto save function instead, this is slightly different in the way of loading
        }
        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.Log("no save data file");
            if (HasBeginningDialogue)
            {
                // load the dialogue for this scene
                InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
            }
            return;
        }
        // convert save data to SaveObject
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        // for normal load, not auto save load load scene first
        if (saveObject.sceneId != sceneLoader.GetActiveSceneId()){
            sceneLoader.LoadScene(saveObject.sceneId);
        }
        LoadFromSaveObject(saveObject);
    }

    private void LoadFromSaveObject(SaveObject saveObject){
        // ****load the game according to the save***

        // initialize scene info according to scene
        SceneInfo sceneInfo = sceneDict[saveObject.sceneId];
        switch(language){
            case GameLanguage.CH:
                infoBar.SetInfoText(sceneInfo.sceneDescription_CH);
                break;
            case GameLanguage.EN:
                infoBar.SetInfoText(sceneInfo.sceneDescription_EN);
                break;
            default:
                break;
        }
        // money
        this.SetMoney(saveObject.moneyAmount);
        // inventory
        inventory.LoadItemListFromIdArray(saveObject.itemIdArray, allItem.arrayById);
        // notes in sketchbook
        SketchbookData.LoadNotesUnlockedStates(saveObject.noteUnlockedState);

        if (saveObject.loadSceneFromStart)
        {
            if (HasBeginningDialogue)
            {
                // load the dialogue for this scene
                InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
            }
        } else {
            // dialogue variables
            dialogueVariables.LoadGlobalVariablesSave(saveObject.dialogueVariablesState);

            switch (sceneInfo.sceneType)
            {
                case SceneType.ThreeScreen:
                    // has to restart, can't load progress
                    break;
                case SceneType.Waking:
                    // re-locate the saved dialogue
                    dialogueManager.LoadStorySave(saveObject.currentDialogueJson, saveObject.currentDialogueState);
                    break;
                case SceneType.Map:
                    // re-locate the saved dialogue
                    dialogueManager.LoadStorySave(saveObject.currentDialogueJson, saveObject.currentDialogueState);
                    break;
                case SceneType.Draw:
                    // re-locate the saved dialogue
                    dialogueManager.LoadStorySave(saveObject.currentDialogueJson, saveObject.currentDialogueState);
                    break;
                case SceneType.FluidBrain:
                    // has to restart, can't load progress
                    break;
                case SceneType.DFD:
                    // re-locate the saved dialogue
                    dialogueManager.LoadStorySave(saveObject.currentDialogueJson, saveObject.currentDialogueState);
                    break;
            }
        }
    }
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
        // UNIVERSAL
        public float moneyAmount;   // money
        public int[] itemIdArray;   // owned item list, no changed states
        public bool[] noteUnlockedState; // notebook unlock state
        public string sceneId;  // current scene
        public bool loadSceneFromStart;

        // DIALOGUE
        public string dialogueVariablesState;    // ink dialogue variables
        // ink dialogue story progress if any
        public string currentDialogueJson;
        public string currentDialogueState; 

        // SCENE SPECIFIC
        public int drawBinaryVal;
        // collected observee choices
        public Vector3 mapPlayerPos;
        public bool[] mapItemCollectedState;

        // 3screen: no save
        // waking: dialogue
        // map: player position + map object collected state + ink global var
        // draw: dialogue + binary val
        // fluid brain: no save
        // dfd: dialogue

        // save real life time

    }

    private class GlobalSaveObject {
        // note unlocked state;
        // item gallery
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
}

public enum GameLanguage {
    CH,
    EN
}