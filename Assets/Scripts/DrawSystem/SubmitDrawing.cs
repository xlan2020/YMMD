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
        if (g.CompareTag("Observee") && canSubmit && g.GetComponent<DragDrop>().IsOnDrop())
        {
            Observee ob = g.GetComponent<Observee>();
            dialogueManager.MakeChoice(ob.choiceIndex);
            canSubmit = false;
            observeeManager.ClearAll();
            cursor.SetAnimationTrigger("default");
        }

        if (g.CompareTag("DrawMaterial") && canSubmit && g.GetComponent<DragDrop>().IsOnDrop())
        {
            UnityEngine.Debug.Log("draw material drop");
            DrawMaterial mat = g.GetComponent<DrawMaterial>();
            int choiceIndex = mat.GetChoiceIndex();
            dialogueManager.MakeChoice(choiceIndex);
            mat.SubmitSelf();
            progressAnimator.SetInteger("material", choiceIndex);
            canSubmit = false;
            cursor.SetAnimationTrigger("default");

        }
    }

    public void CanSubmit(bool b)
    {
        canSubmit = b;
    }
}
