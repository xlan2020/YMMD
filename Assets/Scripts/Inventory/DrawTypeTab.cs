using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTypeTab : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetSelfReady(bool b)
    {
        animator.SetBool("Ready", b);
    }

    public void SetSelfSelected(bool b)
    {
        animator.SetBool("Selected", b);
    }
}
