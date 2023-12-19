using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubmitDrawing : MonoBehaviour
{
    [SerializeField] private DrawingSystem drawingSystem;
    [SerializeField] InkDialogueManager dialogueManager;
    [SerializeField] ObserveeManager observeeManager;
    [SerializeField] private UIDraw_Inventory uiDraw_Inventory;
    [SerializeField] private bool canSubmit = false;
    public MouseCursor cursor;
    //public Animator progressAnimator;
    private Animator animator;

    [Header("Visual UI Renderers")]
    public Canvas boardRenderer;
    public Renderer clipRenderer;
    public Canvas backBorder;

    private string DEFAULT_LAYER = "drawSubmitterDefault";
    private string CANSUBMIT_LAYER = "drawSubmitterActive";

    void Awake()
    {
        animator = GetComponent<Animator>();
        SetSortingLayer(DEFAULT_LAYER);
    }
    public void SubmitObservee(Observee obsv)
    {
        if (!canSubmit)
        {
            return;
        }

        SetCanSubmit(false);

        // let drawing system know which one is submitted
        drawingSystem.SubmitToDrawing(obsv);

        // remove observee
        observeeManager.DissolveCollected();

        // visual change
        cursor.SetAnimationTrigger("default");

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (canSubmit && other.gameObject.CompareTag("Observee"))
        {
            other.gameObject.GetComponent<Observee>().SetSubmitting(true, this);
        }
        /**
        if (other.gameObject.CompareTag("DrawItem"))
        {
            other.gameObject.GetComponent<DrawItemObject>().SetAtDestination(true);
        }
        */
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (canSubmit && other.gameObject.CompareTag("Observee"))
        {
            other.gameObject.GetComponent<Observee>().SetSubmitting(false, this);
        }


        // if (other.gameObject.CompareTag("DrawItem"))
        // {
        //     other.gameObject.GetComponent<DrawItemObject>().SetAtDestination(false);
        // }
    }


    public void SetCanSubmit(bool b)
    {
        canSubmit = b;
        animator.SetBool("ready", b);
        observeeManager.SetCollectedCanSubmit();
        if (b == true)
        {
            // can't submit
            SetSortingLayer(CANSUBMIT_LAYER);
        }
        else
        {
            // can't submit, put it to default layer, so that it's above the observee
            SetSortingLayer(DEFAULT_LAYER);
        }
    }

    private void SetSortingLayer(string newLayerName)
    {
        boardRenderer.sortingLayerID = SortingLayer.NameToID(newLayerName);
        clipRenderer.sortingLayerID = SortingLayer.NameToID(newLayerName);
        backBorder.sortingLayerID = SortingLayer.NameToID(newLayerName);
    }

    public bool CanSubmit()
    {
        return canSubmit;
    }
}
