using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    public GameObject startButtonObj;
    public GameObject restartButtonObj;
    public Button continueButton;
    public Text restartButtonText;
    public Text continueButtonText;
    public Text quitButtonText;

    void Start()
    {
        if (SaveSystem.HasAutoSave())
        { // continue and restart
            continueButton.gameObject.SetActive(true);
            startButtonObj.SetActive(false);
            restartButtonObj.SetActive(true);
        }
        else
        {
            // completely new 
            continueButton.gameObject.SetActive(false);
            startButtonObj.SetActive(true);
            restartButtonObj.SetActive(false);
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
