using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitDrawing : MonoBehaviour
{
    public InkDialogueManager dialogueManager;
    public ObserveeManager observeeManager;
    private bool canSubmit = false;
    public MouseCursor cursor;
    public Animator progressAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject g = other.gameObject;
        Debug.Log("something stays in the submitted drawing");
        if (canSubmit && g.GetComponent<DragDrop>().IsOnDrop())
        {
            if (g.CompareTag("Observee"))
            {
                canSubmit = false;
                Observee ob = g.GetComponent<Observee>();
                dialogueManager.MakeChoice(ob.choiceIndex);
                observeeManager.DissolveCollected();
                cursor.SetAnimationTrigger("default");
            }

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
        }
    }

    public void CanSubmit(bool b)
    {
        canSubmit = b;
    }
}
