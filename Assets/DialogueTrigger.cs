using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Triggers a conversation;
public class DialogueTrigger : MonoBehaviour
{
    // Creates a dialogue object
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        // find a dialogueManager object and run StartDialogue()
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
