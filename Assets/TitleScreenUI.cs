using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    public Button restartButton;
    public Button continueButton;
    public Text restartButtonText;
    public Text continueButtonText;
    public Text quitButtonText;

    void Start()
    {
        if (SaveSystem.HasAutoSave())
        {
            continueButton.gameObject.SetActive(true);
            restartButtonText.text = "重新开始";
        }
        else
        {
            continueButton.gameObject.SetActive(false);
            restartButtonText.text = "开始游戏";
        }
    }

    public void SetRestartGameSave()
    {
        GameEssential.currentSave = -1;
    }

    public void SetResumeGameSave()
    {
        GameEssential.currentSave = 0;
    }
}
