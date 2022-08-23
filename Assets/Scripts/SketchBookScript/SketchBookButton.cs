using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchBookButton : MonoBehaviour
{
    private Animator animator;
    public MouseCursor cursor;
    public SketchBook book;

    void Start()
    {
        animator = GetComponent<Animator>();
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
        book.ToggleOpen();
    }


    private void OnMouseExit()
    {
        animator.SetBool("MouseOn", false);
        cursor.SetAnimationTrigger("default");
    }

    public void ChangeNewIcon(bool b)
    {
        animator.SetBool("New", b);
    }
}
