using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitDrawing : MonoBehaviour
{
    [SerializeField] private DrawingSystem drawingSystem;
    [SerializeField] InkDialogueManager dialogueManager;
    [SerializeField] ObserveeManager observeeManager;
    [SerializeField] private UIDraw_Inventory uiDraw_Inventory;
    [SerializeField] private bool canSubmit = false;
    public MouseCursor cursor;
    public Animator progressAnimator;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        GameObject g = other.gameObject;
        // Debug.Log("something stays in the submitted drawing");
        if (canSubmit && g.GetComponent<DragDrop>().IsOnDrop())
        {
            if (g.CompareTag("Observee"))
            {
                SetCanSubmit(false);

                // let drawing system know which one is submitted
                Observee obsv = g.GetComponent<Observee>();
                drawingSystem.SubmitToDrawing(obsv);

                // visual change
                observeeManager.DissolveCollected();
                cursor.SetAnimationTrigger("default");
            }
            /**
            if (g.CompareTag("DrawMaterial"))
            {
                canSubmit = false;
                UnityEngine.Debug.Log("draw material drop");
                DrawMaterial mat = g.GetComponent<DrawMaterial>();
                int choiceIndex = mat.GetChoiceIndex();
                dialogueManager.MakeChoice(choiceIndex);
                mat.SubmitSelf();
                progressAnimator.SetInteger("material", choiceIndex);
                cursor.SetAnimationTrigger("default");
            }
            */

            if (g.CompareTag("DrawItem"))
            {
                DrawItemObject drawItem = g.GetComponent<DrawItemObject>();
                //UnityEngine.Debug.Log("submit draw item, name: " + drawItem.GetItem().itemName);

                // change ui draw inventory slot display 
                uiDraw_Inventory.ApplyCurrentItem();

                // change ui draw inventory tab complete state

                // change submitter visual display

                // reset item 
                drawItem.ResetSelf();

                // check if all material is selected and ready
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DrawItem"))
        {
            other.gameObject.GetComponent<DrawItemObject>().SetAtDestination(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DrawItem"))
        {
            other.gameObject.GetComponent<DrawItemObject>().SetAtDestination(false);
        }
    }


    public void SetCanSubmit(bool b)
    {
        canSubmit = b;
        animator.SetBool("ready", b);
    }

}
