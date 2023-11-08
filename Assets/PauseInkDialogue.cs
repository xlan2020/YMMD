using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInkDialogue : MonoBehaviour
{
    public InkDialogueManager dialogueManager; 


    public void PauseStory(){
        dialogueManager.SetCanContinueToNextLine(false);
    }

    public void UnPauseStory(){
        dialogueManager.SetCanContinueToNextLine(true);
    }

    public void UnPauseAndContinueStory(){
        dialogueManager.SetCanContinueToNextLine(true);
        dialogueManager.ContinueStory();
    }   

}
