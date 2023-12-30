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
    public bool canDissolve = true;
    private bool canSubmit = false;
    [TextArea()] public string description;
    [TextArea()] public string description_EN;
    public string submitSpeak;
    public string submitSpeak_EN;
    private bool isCollected = false;
    private bool canGrab = true;
    private bool canMove = true;
    private bool submitting = false;
    private SubmitDrawing submitter;
    private bool hasAppeared = false;
    private Animator animator;
    public UnityEvent eventsOnDisplay;
    [SerializeField] private Color StartDissolveColor;

    private Vector3 snapPosLeft;
    private Vector3 snapPosRight;
    private bool isAtRight = false;

    private int LEFT_SORT_LAYER_ID;
    private string RIGHT_SORT_LAYER_NAME = "observee";

    void Awake()
    {
        gameObject.AddComponent<DragDrop>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        snapPosLeft = gameObject.transform.position;
        if (GetComponent<SpriteRenderer>() != null)
        {
            LEFT_SORT_LAYER_ID = GetComponent<SpriteRenderer>().sortingLayerID;
        }
        else if (GetComponent<Canvas>() != null)
        {
            LEFT_SORT_LAYER_ID = GetComponent<Canvas>().sortingLayerID;
        }
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


    public bool IsCollected()
    {
        return isCollected;
    }

    public void SetIsCollected(bool b)
    {
        isCollected = b;
    }

    public void SetSubmitting(bool b, SubmitDrawing submitter)
    {
        this.submitter = submitter;
        submitting = b;

    }
    public void SetSortingLayer(int layerId, int layerOrder = -1)
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().sortingLayerID = layerId;
            if (layerOrder >= 0)
            {
                GetComponent<SpriteRenderer>().sortingOrder = layerOrder;
            }
        }
        else if (GetComponent<Canvas>() != null)
        {
            GetComponent<Canvas>().sortingLayerID = layerId;
            if (layerOrder >= 0)
            {
                GetComponent<Canvas>().sortingOrder = layerOrder;
            }
        }
    }
    public void SendRight()
    {
        isAtRight = true;

        if (!canSubmit)
        {
            animator.SetTrigger("sendRight");
            SetSortingLayer(SortingLayer.NameToID(RIGHT_SORT_LAYER_NAME));

        }

    }
    public void SendLeft()
    {
        isAtRight = false;

        if (!isCollected && !canSubmit)
        {
            animator.SetTrigger("sendLeft");
            SetSortingLayer(LEFT_SORT_LAYER_ID);
        }
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

        // change grab cursor
        if (!isCollected && !isAtRight)
        {
            // observee not collected and on the left
            manager.cursor.ChangeGrabSprite("dragRight");
        }
        else if (manager.submitter.CanSubmit())
        {
            manager.cursor.ChangeGrabSprite("dragDown");
        }

        // change grab state
        manager.SetCursorBool("grab", true); //change to to right cursor when not collected

    }

    private void OnMouseUp()
    {
        string descri = "";
        switch (GameEssential.localeId)
        {
            case 0:
                descri = description;
                break;
            case 1:
                descri = description_EN;
                break;
            default:
                descri = description;
                break;
        }

        // change it back to default
        manager.cursor.ChangeGrabSprite("grab");
        manager.SetCursorBool("grab", false);

        if (submitting && submitter != null)
        {
            submitting = false;
            submitter.SubmitObservee(this);
            return;
        }

        // collected at the right workstation
        if (!isCollected && isAtRight)
        {
            manager.MarkAsCollected(this);
            manager.SetDescription(descri);
            this.SaveSnapPosRight();
            return;
        }

        // collecting, but back to left, then reset it to when it appears
        if (!isCollected && !isAtRight)
        {
            // snap
            gameObject.transform.position = snapPosLeft;
            // in this case, don't set its description
            return;
        }

        // if already collected, but drag to left, then reset it to right collected position
        if (isCollected && !isAtRight)
        {
            // snap
            gameObject.transform.position = snapPosRight;
            manager.SetDescription(descri);
            return;
        }

        // if already collected, and drag to anotion pos at right
        // then update its snap postiion right to the current one
        if (isCollected && isAtRight)
        {
            SaveSnapPosRight();
            manager.SetDescription(descri);
            return;
        }
    }

    private void OnMouseExit()
    {
        if (!canGrab)
        {
            return;
        }
        manager.SetCursorTrigger("default");
    }

    private void SaveSnapPosRight()
    {
        snapPosRight = gameObject.transform.position;
    }

    public void SetCanSubmit(bool b)
    {
        canSubmit = b;
    }


}
