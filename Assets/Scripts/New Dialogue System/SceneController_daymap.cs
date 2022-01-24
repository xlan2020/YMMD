using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController_daymap : MonoBehaviour
{
    public GameObject eggplant;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(getVariable("showEggplant")) == 1)
        {
            eggplant.SetActive(true);
        }
        else
        {
            eggplant.SetActive(false);
        }

        if (Int32.Parse(getVariable("enlargeEggplant")) == 1)
        {
            eggplant.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private string getVariable(string variableName)
    {
        return (InkDialogueManager
            .GetInstance()
            .GetVariableState(variableName)).ToString();
    }
}
