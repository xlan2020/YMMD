using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractiveSign : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private bool isHidden;
    private bool isNear = false;
    private MouseCursor cursor;
    private Button button;
    [SerializeField] private string changeCursorType = "point";

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
        isNear = true;
    }

    public void showSelfFar()
    {
        button.interactable = false;
        gameObject.SetActive(true);
        animator.SetTrigger("showFar");
        isHidden = false;
        isNear = false;
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
        isNear = false;
    }

    public bool IsNear()
    {
        return isNear;
    }
    public bool IsHidden()
    {
        return isHidden;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (button.interactable)
        {
            cursor.SetAnimationTrigger(changeCursorType);
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
