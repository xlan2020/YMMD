using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    public TextAsset inkJSON;


    public void StartDialogue()
    {
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
