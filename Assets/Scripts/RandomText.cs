using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomText : MonoBehaviour
{
    public string[] textPool;
    private Text text;
    public bool displayAtStart = true;
    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        if (displayAtStart)
        {
            DisplayRandomText();
        }
    }
    public void DisplayRandomText()
    {
        int rand = Random.Range(0, textPool.Length);
        text.text = textPool[rand];
    }
}
