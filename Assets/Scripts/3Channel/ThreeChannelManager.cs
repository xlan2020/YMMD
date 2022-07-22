using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeChannelManager : MonoBehaviour
{
    /**
    The design for coding this text change: 
    Each text string has: group(key frame) index x, line index y; 
    */

    public ThreeChannelText LeftText;
    public ThreeChannelText MidText;
    public ThreeChannelText RightText;
    public string RandomText;
    private char[] randomCharArray;

    private Queue<ThreeChannelLineUnit> lineScript;
    private ThreeChannelLineUnit currLineUnit;


    void Awake()
    {
        lineScript = new Queue<ThreeChannelLineUnit>();

    }
    void Start()
    {
        // loop through children, which are line units
        foreach (Transform child in transform)
        {
            lineScript.Enqueue(child.gameObject.GetComponent<ThreeChannelLineUnit>());
        }
        NextLineUnit();

        randomCharArray = RandomText.ToCharArray();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
        {
            NextLineUnit();
        }
    }

    public void NextLineUnit()
    {
        if (lineScript.Count > 0)
        {
            currLineUnit = lineScript.Dequeue();

            LeftText.SetCurrLines(currLineUnit.LeftLines);
            MidText.SetCurrLines(currLineUnit.MidLines);
            RightText.SetCurrLines(currLineUnit.RightLines);

            LeftText.SetAttemptLimit(currLineUnit.OverrideAttemptLimit);
            MidText.SetAttemptLimit(currLineUnit.OverrideAttemptLimit);
            RightText.SetAttemptLimit(currLineUnit.OverrideAttemptLimit);

            LeftText.SetTextChangeInterval(currLineUnit.OverrideTextChangeInterval);
            MidText.SetTextChangeInterval(currLineUnit.OverrideTextChangeInterval);
            RightText.SetTextChangeInterval(currLineUnit.OverrideTextChangeInterval);

        }
        else
        {
            UnityEngine.Debug.Log("no more line unit! This part is done. ");
        }
    }

    public string GenerateRandomString(int wordCount)
    {
        if (wordCount == null || wordCount < 0)
        {
            UnityEngine.Debug.Log("Invalid word Count: this number must be a positive integer.");
            return "";
        }

        string word = "";
        for (int i = 0; i < wordCount; i++)
        {
            int j = UnityEngine.Random.Range(0, randomCharArray.Length - 1);
            word = word + randomCharArray[j].ToString();
        }
        return word;
    }
}
