using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBook : MonoBehaviour
{
    private Animator animator;
    public MouseCursor cursor;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        animator.SetBool("MouseOn", true);
        cursor.SetAnimationTrigger("hand");
    }


    private void OnMouseDown()
    {
        cursor.SetAnimationBool("grab", true);
    }


    private void OnMouseUp()
    {
        cursor.SetAnimationBool("grab", false);
    }


    private void OnMouseExit()
    {
        animator.SetBool("MouseOn", false);
        cursor.SetAnimationTrigger("default");
    }
}
