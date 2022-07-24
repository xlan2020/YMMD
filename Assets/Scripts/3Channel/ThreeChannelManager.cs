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
    public BGMPlayer bgmPlayer;
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

    private void NextLineUnit()
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

            LeftText.SetAcceleratingInterval(currLineUnit.OverrideAcceleration);
            MidText.SetAcceleratingInterval(currLineUnit.OverrideAcceleration);
            RightText.SetAcceleratingInterval(currLineUnit.OverrideAcceleration);


            LeftText.doneLines = true;
            MidText.doneLines = true;
            RightText.doneLines = true;


            if (currLineUnit.LeftLines.Length > 0)
            {
                LeftText.screenAnimator.SetBool("isNext", true);
                LeftText.doneLines = false;
            }

            if (currLineUnit.MidLines.Length > 0)
            {
                MidText.screenAnimator.SetBool("isNext", true);
                MidText.doneLines = false;
            }

            if (currLineUnit.RightLines.Length > 0)
            {
                RightText.screenAnimator.SetBool("isNext", true);
                RightText.doneLines = false;
            }

            if (currLineUnit.syncAllScreensAsLeft)
            {
                LeftText.ChangeText(currLineUnit.LeftLines[0]);
                MidText.ChangeText(currLineUnit.LeftLines[0]);
                RightText.ChangeText(currLineUnit.LeftLines[0]);
            }

            if (currLineUnit.newBGM != "" && currLineUnit.newBGM != null)
            {
                bgmPlayer.ChangeBGM(currLineUnit.newBGM);
            }
        }
        else
        {
            UnityEngine.Debug.Log("no more line unit! This part is done. ");
        }
    }

    public void CheckDoneLineUnit()
    {
        if (LeftText.doneLines && MidText.doneLines && RightText.doneLines)
        {
            NextLineUnit();
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
