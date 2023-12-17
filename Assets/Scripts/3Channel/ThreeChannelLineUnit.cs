using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreeChannelLineUnit : MonoBehaviour
{
    public string[] LeftLines;
    public string[] LeftLines_EN;
    public string[] MidLines;
    public string[] MidLines_EN;
    public string[] RightLines;
    public string[] RightLines_EN;

    public int OverrideAttemptLimit = -1;
    public float OverrideTextChangeInterval = -1f;

    public float OverrideAcceleration = 0f;

    public bool syncAllScreensAsLeft = false;

    public string newBGM;

    public UnityEvent events;
}
