using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene Start Setup")]
    private bool loadCurrentSave = true;
    private bool HasBeginningDialogue = true;
    [SerializeField] TextAsset BeginningInkJSON;
    public LoadInventory loadInventory;
    public LoadingScene sceneLoader;
    public LocaleSelector localeSelector;
    public bool playTestAddMoney = false;
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

    public event EventHandler onItemDisplaced;

    private static GameManager instance;

    void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one game manager per scene!");
        }
        instance = this;

        inventory = new Inventory()
        {
            cashItem = allItem.arrayById[0]
        };

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

    public static GameManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        if (loadCurrentSave)
        {
            UnityEngine.Debug.Log("About to load current save: " + GameEssential.currentSave);
            Load(GameEssential.currentSave);
        }
        if (loadInventory != null)
        {
            loadInventory.AppendListToInventory(inventory);
        }
        sceneLoader.FadeOutLoadingScreen();

        if (playTestAddMoney)
        {
            AddMoney(initialMoney);
        }
    }

    void Update()
    {

    }

    public void SetLoadCurrentSave(bool b)
    {
        loadCurrentSave = b;
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }


    public SaveObject Save(int saveFileId)
    {
        if (saveFileId == 0)
        {
            UnityEngine.Debug.LogWarning("Can't save as autosave! The autosave only happen during scene transition. ");
            return null;
        }

        // clean up data to be saved
        string saveRealTime = GetCurrentTimeString();
        float currMoney = money.GetMoney();
        int[] itemIdArray = inventory.GetItemIdSaveArray();
        bool[] noteUnlockedState = SketchbookData.GetNoteUnlockedSaveArray();
        int currPage = SketchbookData.currPage;
        string sceneId = sceneLoader.GetActiveSceneId();
        bool loadSceneFromStart = false;
        string dialogueVariablesState = "";
        string currentDialogueJson = "";
        string currentDialogueState = "";
        List<string> chatHistory = new List<string>();
        // remaining question: if there isn't a dialogue manager, you will loose all your chat history
        if (InkDialogueManager.GetInstance() != null)
        {
            dialogueManager = InkDialogueManager.GetInstance();
            dialogueVariablesState = dialogueManager.GetDialogueVariables().GetGlobalVariablesJsonState();
            currentDialogueJson = dialogueManager.GetCurrentStoryJson();
            currentDialogueState = dialogueManager.GetCurrentStoryJsonState();
            chatHistory = dialogueManager.GetChatHistorySaveObject();
        }

        // serialize to SaveObject json string
        SaveObject saveObject = new SaveObject
        {
            saveRealTime = saveRealTime,
            moneyAmount = currMoney,
            itemIdArray = itemIdArray,
            noteUnlockedState = noteUnlockedState,
            currPage = currPage,
            sceneId = sceneId,
            loadSceneFromStart = loadSceneFromStart,
            dialogueVariablesState = dialogueVariablesState,
            currentDialogueJson = currentDialogueJson,
            currentDialogueState = currentDialogueState,
            chatHistory = chatHistory
        };
        string json = JsonUtility.ToJson(saveObject);

        // write the save file
        SaveSystem.SaveAtSlot(json, saveFileId);

        return saveObject;
    }

    public void AutoSave(string nextSceneId)
    {
        string saveRealTime = GetCurrentTimeString();
        float currMoney = money.GetMoney();
        int[] itemIdArray = inventory.GetItemIdSaveArray();
        bool[] noteUnlockedState = SketchbookData.GetNoteUnlockedSaveArray();
        int currPage = SketchbookData.currPage;
        string sceneId = nextSceneId; // this is different!
        string dialogueVariablesState = "";
        List<string> chatHistory = new List<string>();
        if (InkDialogueManager.GetInstance() != null)
        {
            dialogueManager = InkDialogueManager.GetInstance();
            dialogueVariablesState = dialogueManager.GetDialogueVariables().GetGlobalVariablesJsonState();
            chatHistory = dialogueManager.GetChatHistorySaveObject();
        }
        // no need to save dialogue state, but need to save variables

        // serialize to SaveObject json string
        SaveObject saveObject = new SaveObject
        {
            saveRealTime = saveRealTime,
            moneyAmount = currMoney,
            itemIdArray = itemIdArray,
            noteUnlockedState = noteUnlockedState,
            currPage = currPage,
            sceneId = sceneId,
            loadSceneFromStart = true, // for auto save, load from scene start has to be true
            dialogueVariablesState = dialogueVariablesState,
            chatHistory = chatHistory
        };
        string json = JsonUtility.ToJson(saveObject);

        // write the save file
        SaveSystem.AutoSave(json);
    }

    public void LoadAutoSave()
    {
        string saveString = SaveSystem.Load(0);

        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.Log("no auto save!");
            if (HasBeginningDialogue && GetComponent<InkDialogueTrigger>() != null)
            {
                // load the dialogue for this scene
                GetComponent<InkDialogueTrigger>().StartDialogue();

            }
            return;
        }
        else
        {
            UnityEngine.Debug.Log("loading auto save...");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            LoadFromSaveObject(saveObject);
        }
    }

    private void Load(int saveFileId)
    {
        if (saveFileId == -1)
        {
            // do not load any save, restart the scene
            // only use this when restarting the game
            return;
        }

        if (saveFileId == 0)
        {
            LoadAutoSave(); // USE THE LOAD auto save function instead, this is slightly different in the way of loading
            return;
        }

        string saveString = SaveSystem.Load(saveFileId);

        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.LogWarning("no matching save data file");
        }

        // convert save data to SaveObject
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        LoadFromSaveObject(saveObject);

    }

    private void LoadFromSaveObject(SaveObject saveObject)
    {
        // ****load the game according to the save***

        // initialize scene info according to scene
        SceneInfo sceneInfo = sceneDict[saveObject.sceneId];
        string sceneInfoText = "";
        switch (GameEssential.localeId)
        {
            case 0:
                sceneInfoText = sceneInfo.sceneDescription_CH;
                break;
            case 1:
                sceneInfoText = sceneInfo.sceneDescription_EN;
                break;
            default:
                break;
        }
        // //infoBar.SetInfoText(sceneInfoText);

        // now use localized string instead, which also works as font resetter activator
        // only need to resolve how the game manager can access the scene info table
        // or maybe we just write it twice


        // locale id
        // Now using the global save for locale
        // localeSelector.UpdateLocaleToGame();

        // money
        this.SetMoney(saveObject.moneyAmount);
        // inventory
        inventory.LoadItemListFromIdArray(saveObject.itemIdArray, allItem.arrayById);

        // notes in sketchbook
        SketchbookData.LoadNotesUnlockedStates(saveObject.noteUnlockedState);
        SketchbookData.currPage = saveObject.currPage;

        // dialogue loadss
        if (InkDialogueManager.GetInstance() != null)
        {
            dialogueManager = InkDialogueManager.GetInstance();

            // dialogue variables
            if (saveObject.dialogueVariablesState != null && saveObject.dialogueVariablesState != "")
            {
                dialogueManager.GetDialogueVariables().LoadGlobalVariablesSave(saveObject.dialogueVariablesState);
            }

            // chat history
            List<string> chatHistory = saveObject.chatHistory;
            if (saveObject.loadSceneFromStart)
            {
                // add scene title to chat history
                if (chatHistory != null && chatHistory.Count > 0)
                {
                    chatHistory[chatHistory.Count - 1] += sceneInfoText + "\n\n";
                }
            }
            dialogueManager.LoadChatHistorySaveObject(chatHistory);
        }

        if (!saveObject.loadSceneFromStart)
        {
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
        if (saveObject.sceneId != sceneLoader.GetActiveSceneId())
        {
            sceneLoader.LoadScene(saveObject.sceneId, transition: false);
        }

        // enter the beginning dialogue only if the save object wanna load scene from start
        if (saveObject.loadSceneFromStart && HasBeginningDialogue && GetComponent<InkDialogueTrigger>() != null)
        {
            // load the dialogue for this scene
            GetComponent<InkDialogueTrigger>().StartDialogue();

        }

    }

    public void RemoveItem(Item item)
    {
        inventory.RemoveItem(item);
    }
    public void DisplaceItem(Item item)
    {
        AddMoney(item.value);
        displaceSFX.PlayItemToMoneySound();
        uiInventory.ShowResultWindow_itemToMoney(item);
        inventory.RemoveItem(item);

        onItemDisplaced?.Invoke(this, EventArgs.Empty);
    }

    public void DisplaceItemFromDrawing(float moneyIn, ItemScriptableObject itemOut)
    {

        AddMoney(-moneyIn);
        Item item = inventory.AddItemFromScriptableObject(itemOut);
        item.value = moneyIn; // modify the value of the item to the user input one
        uiInventory.ShowResultWindow_moneyToItem(item);

        displaceSFX.PlayMoneyToItemSound();

        onItemDisplaced?.Invoke(this, EventArgs.Empty);
    }

    public void AddItemToInventory(ItemScriptableObject item)
    {
        if (inventory == null)
        {
            UnityEngine.Debug.Log("Hard to believe, but inventory is null!");
        }

        displaceSFX.PlayItemToInventorySound();
        inventory.AddItemFromScriptableObject(item);
    }

    public void AddMoney(float amount)
    {
        float currAmount = money.GetMoney() + amount;
        money.SetMoney(currAmount);

        updateCashItem();

        if (dialogueVariables == null)
        {
            dialogueVariables = InkDialogueManager.GetInstance().GetDialogueVariables();
        }

        if (dialogueVariables != null)
        {
            dialogueVariables.SetGlobalVariable("money", currAmount);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Try to add money, but dialogue variable is null!");
        }
    }

    public void SetMoney(float amount)
    {
        money.SetMoney(amount);

        updateCashItem();

        if (dialogueVariables != null)
        {
            dialogueVariables.SetGlobalVariable("money", amount);
        }
    }

    private void updateCashItem()
    {
        /**
        CASH item always stay at index 0 at the inventory!!
        */
        if (money.GetMoney() <= 0)
        {
            // remove cash item
            inventory.TryRemoveCashItem();
        }
        else
        {
            inventory.TryAddCashItem();
        }
    }

    public float GetMoney()
    {
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
            displaceSFX.PlayBuyItemSound();
            this.AddItemToInventory(item);
        }

    }

    private string GetCurrentTimeString()
    {
        DateTime now = DateTime.Now;
        string s = now.ToString("yyyy-MM-dd HH:mm:ss");

        UnityEngine.Debug.Log("Current Time: " + s);

        return s;
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
public class SaveObject
{
    // UNIVERSAL
    public string saveRealTime;
    public float moneyAmount;   // money
    public int[] itemIdArray;   // owned item list, no changed states
                                // item durability; (subjective) value; isNew?
    public bool[] noteUnlockedState; // notebook unlock state
    public int currPage;
    public string sceneId;  // current scene
    public bool loadSceneFromStart;

    // USER PREF
    // DIALOGUE
    public string dialogueVariablesState;    // ink dialogue variables
                                             // ink dialogue story progress if any
    public string currentDialogueJson;
    public string currentDialogueState;
    public List<string> chatHistory;

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
