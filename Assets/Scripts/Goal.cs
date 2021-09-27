using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GoalManager manager;
    private bool isTarget = false;


    public void ReportClick()
    {
        Debug.Log("clicked");
        Debug.Log(manager.Clicked);
        if (!manager.Clicked)
        {
            manager.ClickedGoal = GetComponent<Goal>();
            manager.Clicked = true;
        }
    }
    public void SetTarget(bool b)
    {
        isTarget = b;
    }

    public bool IsTarget()
    {
        return isTarget;
    }


}
