using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    public SaveLoad saveLoad;
    [Header("Logic")]
    public int index;
    public bool isAutoSave = false;

    [Header("UI")]
    public Text indexText;
    public Text sceneInfoText;
    public Text saveTimeText;
    public GameObject loadButton;
    public Text saveButtonText;

    private static string NO_INFO_CH = "（无内容）";
    private static string NO_INFO_EN = "(no content)";

    public void ShowNoContentUI()
    {
        switch (GameEssential.localeId)
        {
            case 0:
                sceneInfoText.text = NO_INFO_CH;
                break;
            case 1:
                sceneInfoText.text = NO_INFO_EN;
                break;
            default:
                break;
        }
        saveTimeText.text = "";
        loadButton.SetActive(false);
        if (!isAutoSave)
        {
            switch (GameEssential.localeId)
            {
                case 0:
                    saveButtonText.text = "存档";
                    break;
                case 1:
                    saveButtonText.text = "save";
                    break;
                default:
                    break;
            }
        }
    }

    public void ShowUI(string sceneInfo, string saveTime)
    {
        sceneInfoText.text = sceneInfo;
        saveTimeText.text = saveTime;
        loadButton.SetActive(true);
        if (!isAutoSave)
        {
            switch (GameEssential.localeId)
            {
                case 0:
                    saveButtonText.text = "覆盖";
                    break;
                case 1:
                    saveButtonText.text = "override";
                    break;
                default:
                    break;
            }
        }
    }

    public void Save()
    {
        saveLoad.Save(index);
        // the save load manager displays the new UI
    }

    public void Load()
    {
        saveLoad.Load(index);
    }

    public void Delete()
    {
        saveLoad.Delete(index);
        ShowNoContentUI();
    }
}
