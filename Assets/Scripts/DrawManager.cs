using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public TextAsset inkJSON;

    // Start is called before the first frame update
    void Start()
    {
        // load the dialogue for this drawing scene
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
