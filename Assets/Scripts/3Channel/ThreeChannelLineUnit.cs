using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreeChannelLineUnit : MonoBehaviour
{
    public string[] LeftLines;
    public string[] MidLines;
    public string[] RightLines;

    public int OverrideAttemptLimit = -1;
    public float OverrideTextChangeInterval = -1f;

    public float OverrideAcceleration = 0f;

    public bool syncAllScreensAsLeft = false;

    public string newBGM;

    public UnityEvent events;
}
