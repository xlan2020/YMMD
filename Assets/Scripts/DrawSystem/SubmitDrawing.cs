using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitDrawing : MonoBehaviour
{
    public InkDialogueManager dialogueManager;
    public ObserveeManager observeeManager;
    private bool canSubmit = false;

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
        Debug.Log("something stays in the submitted drawing");
        if (other.gameObject.CompareTag("Observee") && canSubmit && other.gameObject.GetComponent<DragDrop>().IsOnDrop())
        {
            Observee ob = other.gameObject.GetComponent<Observee>();
            dialogueManager.MakeChoice(ob.choiceIndex);
            canSubmit = false;
            observeeManager.ClearAll();
        }
    }

    public void CanSubmit(bool b)
    {
        canSubmit = b;
    }
}
