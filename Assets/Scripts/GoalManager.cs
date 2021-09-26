using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{

    public Hoop hoop;
    public int points;
    public int rounds = 0;

    void Update()
    {
        // if goal on click, 
        // this.JudgeGoal(/* on_click goal*/);
        // if clicked when hoop's movement animation towards target is finished, failed;
        // if didn't click, failed;
    }

    public void StartNewGame()
    {
        // start over the process;
        hoop = new Hoop();
        hoop.RandGoal();
        rounds++;
    }

    public void JudgeGoal(Goal click_goal)
    {
        /*
        // clicked wrong goal
        if (click_goal.isTarget == false)
        {
            this.Fail(1);
        }

        // clicked too late
        if (Hoop already arrived at the same location as target)
        {
            this.Fail(1);
        }

        // won S
        if (distance from hoop to target <= 5px)
        {
            this.Win(4);
        }

        // failed 2
        if (hoop's shape collides with target's shape )
        {
            this.Fail(2);
        }

        // won C
        if (distance from hoop to target <= 1/4 the distance fon initial point to target)
        {
            this.Win(1);
        }

        // won B
        if (distance from hoop to target <= 1/2 the initial distance)
        {
            this.Win(2);
        }

        // won A
        if (distance from hoop to target <= 3/4 the initial distance)
        {
            this.Win(3);
        }

        // distance from hoop to target > 3/4 the initial distance, Won S
        else
        {
            this.Win(4);
        }
        */

    }

    public void Fail(int situation)
    {
        // failed, start new round;
        // change boss img: imageswitcher.switch
        // situation 1: clicked wrong goal; didn't click; too late - already arrived;
        if (situation == 1)
        {
            //costumer win animation
        }
        // situation 2: busted by costumer
        else
        {
            // busted! costumer angry animation
        }

        // if there are rounds left:
        if (rounds <= 10)
        {
            this.StartNewGame();
        }
        // else, end whole game;
        else
        {
            this.EndGame();
        }
    }

    public void Win(int grade)
    {
        // won, add point based on grade, start new round;
        // 4 = S; 3 = A; 2 = B; 1 = C
        points += grade;
    }

    public void EndGame()
    {
        // exit game(return to previous scene); add money to pocket based on points;
    }

}
