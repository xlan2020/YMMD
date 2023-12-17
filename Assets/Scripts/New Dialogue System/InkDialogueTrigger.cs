using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    public TextAsset inkJSON;
    public TextAsset inkJSON_EN;


    public void StartDialogue()
    {
        TextAsset dialogue;
        switch (GameEssential.localeId)
        {
            case 0:
                dialogue = inkJSON;
                break;
            case 1:
                dialogue = inkJSON_EN;
                break;
            default:
                dialogue = inkJSON;
                break;
        }
        if (InkDialogueManager.GetInstance() != null)
        {
            InkDialogueManager.GetInstance().EnterDialogueMode(dialogue);
        }
    }
}
