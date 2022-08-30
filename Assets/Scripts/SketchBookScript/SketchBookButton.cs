using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SketchBookButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    public MouseCursor cursor;
    public SketchBook book;
    private bool entered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                cursor.SetAnimationBool("grab", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                cursor.SetAnimationBool("grab", false);
                book.ToggleOpen();
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            cursor.SetAnimationBool("grab", false);
        }
    }


    public void ChangeNewIcon(bool b)
    {
        animator.SetBool("New", b);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        animator.SetBool("MouseOn", true);
        cursor.SetAnimationTrigger("hand");
        entered = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        animator.SetBool("MouseOn", false);
        cursor.SetAnimationTrigger("default");
        entered = false;
    }
}
