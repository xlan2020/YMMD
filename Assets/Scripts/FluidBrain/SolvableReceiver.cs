using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
The content in the receiver will not be hidden anymore if a solvable enters. 
*/
public class SolvableReceiver : MonoBehaviour
{
    public Solvable TargetSolvable;
    private Animator animator;
    public GameObject[] AdditionalReceivers;

    private bool _hidden = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("hidden", true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == TargetSolvable.gameObject)
        {
            if (other.GetComponent<DragDrop>().IsOnDrop() == true)
            {
                show();
                TargetSolvable.DoneSolving();
            }
        }
    }

    void show()
    {
        animator.SetBool("hidden", false);
        foreach (GameObject o in AdditionalReceivers)
        {
            o.SetActive(true);
            Animator a = o.GetComponent<Animator>();
            if (a != null)
            {
                a.SetBool("hidden", false);
            }
        }
    }
}
