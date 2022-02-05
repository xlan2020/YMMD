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
    private AudioSource source;
    public GameObject[] AdditionalReceivers;
    public SolvableReceiver[] ClearSound;

    private bool _hidden = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("hidden", true);
        source = GetComponent<AudioSource>();

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
                ClearOtherSound();
                TargetSolvable.DoneSolving();
            }
        }
    }

    void show()
    {
        animator.SetBool("hidden", false);
        source.Play();
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

    public void ChangeLowerSound(bool b)
    {
        animator.SetBool("lowSound", b);
        UnityEngine.Debug.Log("lowering sound" + b);
    }

    private void ClearOtherSound()
    {
        if (ClearSound != null)
        {
            foreach (SolvableReceiver s in ClearSound)
            {
                s.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
