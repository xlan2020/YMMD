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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("something enters the submitted drawing");
        if (other.gameObject.CompareTag("Observee") && canSubmit)
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
