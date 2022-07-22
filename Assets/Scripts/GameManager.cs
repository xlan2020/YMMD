using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset BeginningInkJSON;
    public bool HasBeginningDialogue = true;
    //public InkDialogueManager InkDialogueManagerInstance;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        if (HasBeginningDialogue)
        {
            // load the dialogue for this scene
            InkDialogueManager.GetInstance().EnterDialogueMode(BeginningInkJSON);
        }
    }

    void Update()
    {

    }
}
