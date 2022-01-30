
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvableManager : MonoBehaviour
{

    public List<Solvable> AllSolvables;
    public Queue<Solvable> solvables;
    private Solvable currSolvable;
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
        currSolvable.SetInteractive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // update next solvable
        if (currSolvable != null && solvables.Count > 0 && currSolvable.IsDone())
        {
            currSolvable = solvables.Dequeue();
            currSolvable.SetInteractive(true);
        }
    }

}
