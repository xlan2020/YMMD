using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    // input goals list;
    public Goal[] goals;
    // initial loc;
    private int x_loc = 0;
    private int y_loc = 0;

    // start hoop moving animations, x and y = target location
    public void StartHoop(int x, int y)
    {
        // set hoop start location
        // animation of hoop flying towards goal
        // animation of hoop falling at goal
    }

    public void RandGoal()
    {
        // make sure all goals are initially false
        foreach (Goal g in goals)
        {
            g.SetTarget(false);
        }

        // randomly choose a target goal
        Random random = new Random();
        int num = random.Next(0, 7);
        goals[num].SetTarget(true);

        // start hoop
        this.StartHoop(goals[num].GetX(), goals[num].GetY()) ;
    }

    // set&get location (is there a way to set/get center loc?)
    public void SetX(int x)
    {
        // set x;
        x_loc = x;
    }

    public void SetY(int y)
    {
        // set y;
        y_loc = y;
    }

    public int GetX()
    {
        return x_loc;
    }

    public int GetY()
    {
        return y_loc;
    }
}
