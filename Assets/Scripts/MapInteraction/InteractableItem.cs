using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableItem : MonoBehaviour
{
    public InteractiveSign interactiveSign;
    public UnityEvent eventsOnInteraction;
    private bool isInteractable;
    public bool collectAfterDialogue = false;
    public bool collectOnInteract = false;
    public bool destroyOnInteract = false;
    public InkDialogueTrigger dialogueTrigger;


    void Awake()
    {
        dialogueTrigger = GetComponent<InkDialogueTrigger>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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
        if (other.gameObject.CompareTag("Player"))
        {
            interactiveSign.hideSelf();
            isInteractable = false;
        }
    }

    public ItemInfo GetitemInfo()
    {
        return gameObject.GetComponent<ItemInfo>();
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
