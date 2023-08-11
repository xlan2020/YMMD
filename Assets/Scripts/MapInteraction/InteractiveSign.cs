using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractiveSign : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private bool isHidden;
    private MouseCursor cursor;
    private Button button;

    void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }

    void Start()
    {
        hideSelf();
    }

    public void showSelfNear()
    {
        button.interactable = true;
        gameObject.SetActive(true);
        animator.SetTrigger("showNear");
        isHidden = false;
    }

    public void showSelfFar()
    {
        button.interactable = false;
        gameObject.SetActive(true);
        animator.SetTrigger("showFar");
        isHidden = false;
    }

    /**
    public void showInteracting()
    {
        animator.SetTrigger("showInteracting");
    }
    */
    public void hideSelf()
    {
        button.interactable = false;
        gameObject.SetActive(false);
        isHidden = true;
    }
    public bool IsHidden()
    {
        return isHidden;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (button.interactable)
        {
            cursor.SetAnimationTrigger("point");
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursor.SetAnimationTrigger("default");
    }

    public void SetCursor(MouseCursor c)
    {
        cursor = c;
    }
}
