using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool isTarget = false;

    public void SetTarget(bool b)
    {
        isTarget = b;
    }

    public bool IsTarget()
    {
        return isTarget;
    }

    // get loc of target for hoop movement animation;
    public int GetX()
    {
        // get x of goal
        return 0;
    }

    public int GetY()
    {
        // get y of goal
        return 0;
    }

}
