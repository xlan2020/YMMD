using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialoguePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MouseCursor cursor;
    private bool interactive = true;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        cursor = MouseCursor.instance;
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (interactive)
        {
            cursor.SetAnimationTrigger("dialogue");
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (interactive)
        {
            cursor.SetAnimationDefault();
        }
    }

    public void SetInteractive(bool b)
    {
        interactive = b;
        if (animator != null)
        {
            animator.SetBool("canContinue", b);
        }
    }


}
