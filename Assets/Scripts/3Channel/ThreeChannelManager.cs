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
    public string RandomText_EN;
    private char[] randomCharArray;
    private char[] randomCharArray_EN;

    private Queue<ThreeChannelLineUnit> lineScript;
    private ThreeChannelLineUnit currLineUnit;
    public Animator ThreeScreensAnimator;

    public LoadingScene loadingScene;
    public string nextSceneName;


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
        randomCharArray_EN = RandomText_EN.ToCharArray();
    }

    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
        //{
        //    NextLineUnit();
        //}
    }

    private void NextLineUnit()
    {
        if (lineScript.Count > 0)
        {
            currLineUnit = lineScript.Dequeue();

            currLineUnit.events.Invoke();

            string[] leftLines;
            string[] midLines;
            string[] rightLines;

            switch (GameEssential.localeId)
            {
                case 0:
                    leftLines = currLineUnit.LeftLines;
                    midLines = currLineUnit.MidLines;
                    rightLines = currLineUnit.RightLines;
                    break;
                case 1:
                    leftLines = currLineUnit.LeftLines_EN;
                    midLines = currLineUnit.MidLines_EN;
                    rightLines = currLineUnit.RightLines_EN;
                    break;
                default:
                    leftLines = currLineUnit.LeftLines;
                    midLines = currLineUnit.MidLines;
                    rightLines = currLineUnit.RightLines;
                    break;
            }

            LeftText.SetCurrLines(leftLines);
            MidText.SetCurrLines(midLines);
            RightText.SetCurrLines(rightLines);

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


            if (leftLines.Length > 0)
            {
                LeftText.screenAnimator.SetBool("isNext", true);
                LeftText.doneLines = false;
            }

            if (midLines.Length > 0)
            {
                MidText.screenAnimator.SetBool("isNext", true);
                MidText.doneLines = false;
            }

            if (rightLines.Length > 0)
            {
                RightText.screenAnimator.SetBool("isNext", true);
                RightText.doneLines = false;
            }

            if (currLineUnit.syncAllScreensAsLeft)
            {
                LeftText.ChangeText(leftLines[0]);
                MidText.ChangeText(leftLines[0]);
                RightText.ChangeText(leftLines[0]);
            }

            if (currLineUnit.newBGM != "" && currLineUnit.newBGM != null)
            {
                bgmPlayer.ChangeBGM(currLineUnit.newBGM, 0.1f);
            }
        }
        else
        {
            UnityEngine.Debug.Log("no more line unit! This part is done. ");
            ThreeScreensAnimator.SetTrigger("end");
            GetComponent<GlitchController>().SetAuto(false);
            loadingScene.LoadScene(nextSceneName);
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

        char[] chars;
        switch (GameEssential.localeId)
        {
            case 0:
                chars = randomCharArray;
                break;
            case 1:
                chars = randomCharArray_EN;
                break;
            default:
                chars = randomCharArray;
                break;
        }

        string word = "";
        for (int i = 0; i < wordCount; i++)
        {
            int j = UnityEngine.Random.Range(0, randomCharArray.Length - 1);
            word = word + chars[j].ToString();
        }
        return word;
    }

    public void SetInteractive(bool b)
    {
        LeftText.SetInteractive(b);
        MidText.SetInteractive(b);
        RightText.SetInteractive(b);

    }

}
