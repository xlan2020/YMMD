
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvableManager : MonoBehaviour
{

    public InkDialogueManager dialogueManager;
    public List<Solvable> AllSolvables;
    public Queue<Solvable> solvables;

    public MouseCursor cursor;
    private Solvable currSolvable;
    private Solvable suspendSolvable;
    private bool _canSolve = false;
    private bool _suspending;
    // private List<Solvable> leftSolvables;
    // private List<Solvable> rightSolvables;

    void Start()
    {
        solvables = new Queue<Solvable>();
        // leftSolvables = new List<Solvable>();
        // rightSolvables = new List<Solvable>();
        int index = 0;
        foreach (Solvable s in AllSolvables)
        {
            solvables.Enqueue(s);
            // UnityEngine.Debug.Log("Set Solvable interactive, index:  " + index);
            s.SetInteractive(false);
            /**
            if (s.InLeft())
            {
                leftSolvables.Add(s);
            }
            else
            {
                rightSolvables.Add(s);
            }
            */
            index++;
        }
        if (solvables.Count > 0)
        {
            currSolvable = solvables.Dequeue();
            currSolvable.Show();
        }
        SuspendInteractiveTillCanSolve(currSolvable);
        // currSolvable.SetInteractive(true);

        cursor.SetInFluidBrain(true);
    }

    void Update()
    {
        // update next solvable
        if (currSolvable != null && solvables.Count > 0 && currSolvable.IsDone())
        {
            _canSolve = false;
            currSolvable = solvables.Dequeue();
            if (currSolvable.showAfterLast){
                currSolvable.Show();
            }
            dialogueManager.SetCanContinueToNextLine(true);
            dialogueManager.ContinueStory();
            SuspendInteractiveTillCanSolve(currSolvable);

        }

        if (_suspending && _canSolve)
        {
            _suspending = false;
            suspendSolvable.SetInteractive(true);
            suspendSolvable = null;
        }
    }

    private void SuspendInteractiveTillCanSolve(Solvable s)
    {
        suspendSolvable = s;
        _suspending = true;
    }

    public void SetCanSolve(bool b)
    {
        _canSolve = b;
    }

    public bool CanSolve()
    {
        return _canSolve;
    }
    public MouseCursor GetCursor()
    {
        return cursor;
    }

    public void SetSolveToBeChoice(int i)
    {
        currSolvable.SetSolveToBeChoice(i);
    }

    public void MakeDialogueChoice(int i)
    {
        dialogueManager.MakeChoice(i);
    }

}
