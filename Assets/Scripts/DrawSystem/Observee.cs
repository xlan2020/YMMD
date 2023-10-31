using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Observee : MonoBehaviour
{
    public ObserveeManager manager;
    public string tagName;
    public int choiceIndex;
    public bool canSkip = false;
    public string description;
    private bool isCollected = false;
    private bool canGrab = true;
    private bool canMove = true;
    private bool hasAppeared = false;
    private Animator animator;
    public UnityEvent eventsOnDisplay;
    [SerializeField] private Color StartDissolveColor;

    void Awake()
    {
        gameObject.AddComponent<DragDrop>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void show()
    {
        gameObject.SetActive(true);
        eventsOnDisplay.Invoke();
    }

    public void appearOnWorkStation()
    {

    }

    public bool IsCollected()
    {
        return isCollected;
    }

    public void SetIsCollected(bool b)
    {
        isCollected = b;
    }

    public void SendRight()
    {
        animator.SetTrigger("sendRight");
    }
    public bool HasAppeared()
    {
        return hasAppeared;
    }

    public void SetHasAppeared(bool b)
    {
        hasAppeared = b;
    }

    public bool CanSkip()
    {
        return canSkip;
    }

    public void SetCanSkip(bool b)
    {
        canSkip = b;
    }


    public void SetCanGrab(bool b)
    {
        canGrab = b;
    }

    private void OnMouseEnter()
    {
        if (!canGrab)
        {
            return;
        }
        if (!isCollected)
        {
            manager.SetCursorTrigger("observe");
        }
        else
        {
            manager.SetCursorTrigger("hand");
        }
    }
    private void OnMouseDown()
    {
        if (!canGrab)
        {
            return;
        }
        manager.SetCursorBool("grab", true);
    }

    private void OnMouseUp()
    {
        manager.SetCursorBool("grab", false);
        manager.SetDescription(description);
    }

    private void OnMouseExit()
    {
        if (!canGrab)
        {
            return;
        }
        manager.SetCursorTrigger("default");
    }

}
