using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableItem : MonoBehaviour
{
    [Header("Interaction")]
    public bool autoTrigger = false;
    private UnityEvent eventsOnAutoEnter;
    public InteractiveSign interactiveSign;
    public InkDialogueTrigger dialogueTrigger;
    public UnityEvent eventsOnInteraction;

    [Header("Item")]
    public ItemScriptableObject itemScriptableObject;
    public bool collectAfterDialogue = false;
    public bool collectOnInteract = false;
    public bool destroyOnInteract = false;

    private bool isInteractable;

    void Awake()
    {
        dialogueTrigger = GetComponent<InkDialogueTrigger>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && autoTrigger)
        {
            // trigger all event
            eventsOnAutoEnter.Invoke();
        }
    }

    public void SetEventsOnAutoEnter(UnityEngine.Events.UnityAction call)
    {
        eventsOnAutoEnter = new UnityEvent();
        eventsOnAutoEnter.AddListener(call);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !autoTrigger)
        {
            if (interactiveSign.IsHidden())
            {
                interactiveSign.showSelfNear();
                isInteractable = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !autoTrigger)
        {
            interactiveSign.hideSelf();
            isInteractable = false;
        }
    }

    public bool IsInteractable()
    {
        return isInteractable;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void TriggerDialogue()
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.StartDialogue();
        }
    }

    public void TriggerEvents()
    {
        eventsOnInteraction.Invoke();
    }

}
