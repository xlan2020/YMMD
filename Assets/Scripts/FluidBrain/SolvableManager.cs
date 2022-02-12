
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
        foreach (Solvable s in AllSolvables)
        {
            solvables.Enqueue(s);
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
        }
        if (solvables.Count > 0)
        {
            currSolvable = solvables.Dequeue();
        }
        SuspendInteractiveTillCanSolve(currSolvable);
        // currSolvable.SetInteractive(true);

        cursor.SetInFluidBrain(true);
    }

    // Update is called once per frame
    void Update()
    {
        // update next solvable
        if (currSolvable != null && solvables.Count > 0 && currSolvable.IsDone())
        {
            _canSolve = false;
            currSolvable = solvables.Dequeue();
            currSolvable.Show();
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

}
