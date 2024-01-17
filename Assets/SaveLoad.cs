using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveLoad : MonoBehaviour
{
    private static int MAX_SAVES = 10;

    public Scrollbar scrollBar;
    public GameObject saveSlotPrefab;
    public Transform saveSlotsParent;

    private SaveSlot[] saveSlots;
    public SceneInfoScriptableObject allSceneInfo;
    private Dictionary<string, SceneInfo> sceneDict;

    private static string TIME_PREFIX_CH = "回溯时间：";
    private static string TIME_PREFIX_EN = "Recalled Time: ";

    void Awake()
    {
        sceneDict = allSceneInfo.GetSceneInfoDict();

    }
    void Start()
    {
        InitializeSaves();
    }

    private void InitializeSaves()
    {
        // counting from 1, neglectin the autosave 0
        saveSlots = new SaveSlot[MAX_SAVES + 1];
        for (int i = 1; i < MAX_SAVES + 1; i++)
        {
            SaveSlot slot = Instantiate(saveSlotPrefab, saveSlotsParent).GetComponent<SaveSlot>();
            slot.saveLoad = this;
            slot.index = i;
            slot.indexText.text = "" + i;
            string saveString = SaveSystem.Load(i);
            if (saveString == null || saveString == "")
            {
                // no such save file
                slot.ShowNoContentUI();
            }
            else
            {
                SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                UpdateSlotUI(slot, saveObject);
            }
            saveSlots[i] = slot;
        }
        // scrollBar.value = 1f;
    }

    private void UpdateSlotUI(SaveSlot slot, SaveObject saveObject)
    {
        string sceneDescription = "";
        string prefix = "";

        switch (GameEssential.localeId)
        {
            case 0:
                sceneDescription = sceneDict[saveObject.sceneId].sceneDescription_CH;
                prefix = TIME_PREFIX_CH;
                break;
            case 1:
                sceneDescription = sceneDict[saveObject.sceneId].sceneDescription_EN;
                prefix = TIME_PREFIX_EN;
                break;
            default:
                break;
        }

        slot.ShowUI(sceneDescription, prefix + saveObject.saveRealTime);
    }

    public void Save(int saveFileId)
    {
        if (GameManager.GetInstance() == null)
        {
            UnityEngine.Debug.Log("there is no game manager in this scene! Can't save current state. ");
            // UI log warning
            return;
        }
        SaveObject saveObject = GameManager.GetInstance().Save(saveFileId);

        // 这个也会覆盖，所以要更新新UI
        UpdateSlotUI(saveSlots[saveFileId], saveObject);
    }

    public void Load(int saveFileId)
    {
        if (saveFileId == -1)
        {
            // do not load any save, restart the scene
            // only use this when restarting the game
            return;
        }

        string saveString = SaveSystem.Load(saveFileId);
        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.LogWarning("no matching save data file");
            return;
        }
        // convert save data to SaveObject
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

        // load the save file
        GameEssential.currentSave = saveFileId;
        if (LoadingScene.GetInstance() != null)
        {
            LoadingScene.GetInstance().LoadScene(saveObject.sceneId, autoSave: false, deleteAutoSave: false);
        }
    }

    public void Delete(int saveFileId)
    {
        SaveSystem.DeleteSave(saveFileId);
    }
}
