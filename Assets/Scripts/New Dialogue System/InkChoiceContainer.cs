using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkChoiceContainer : MonoBehaviour
{

    public GameObject[] choices;
    public string tagName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
