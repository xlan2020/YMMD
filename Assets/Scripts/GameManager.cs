using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextAsset inkJSON;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        // load the dialogue for this drawing scene
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    void Update()
    {

    }
}
