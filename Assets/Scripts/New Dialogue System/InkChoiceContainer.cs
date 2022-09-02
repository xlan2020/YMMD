using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkChoiceContainer : MonoBehaviour
{

    private GameObject[] choices;
    public string tagName;

    void Awake()
    {
        // instantiate proper choice array
        int choiceNum = 0;
        foreach (Transform child in transform)
        {
            choiceNum++;
        }

        choices = new GameObject[choiceNum];
        int i = 0;
        foreach (Transform child in transform)
        {
            choices[i] = child.gameObject;
            i++;
        }
    }

    public GameObject[] getChoices()
    {
        return choices;
    }

    public string getName()
    {
        return tagName;
    }
}
