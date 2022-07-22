using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeChannelLineUnit : MonoBehaviour
{
    public string[] LeftLines;
    public string[] MidLines;
    public string[] RightLines;

    public int OverrideAttemptLimit = -1;
    public float OverrideTextChangeInterval = -1f;
}
