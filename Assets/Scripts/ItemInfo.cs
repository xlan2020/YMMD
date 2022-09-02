using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemInfo : MonoBehaviour
{
    public float price;
    public float storePrice;
    public string itemName;
    public string description;
    public Sprite spriteImage;
    public bool destroyOnInteract;
    public bool displaceable = true;
    public bool collectAfterDialogue = false;
    public bool collectOnInteract = false;
    public InkDialogueTrigger dialogueTrigger;
    public UnityEvent eventsOnInteract;
    public GameObject detailImage;

    Item item;
    private void Awake()
    {
        spriteImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        dialogueTrigger = GetComponent<InkDialogueTrigger>();
        item = new Item
        {
            price = price,
            storePrice = storePrice,
            itemName = itemName,
            description = description,
            spriteImage = spriteImage,
            destroyOnInteract = destroyOnInteract,
            displaceable = displaceable,
            collectAfterDialogue = collectAfterDialogue,
            collectOnInteract = collectOnInteract,
        };
    }
    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void SetInteractable(bool action)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = action;
    }

    public void TriggerDialogue()
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.StartDialogue();

        }
    }
    public void TriggerEventsOnInteract()
    {
        eventsOnInteract.Invoke();
    }

    public void ToggleDetailImageOnInteract()
    {
        detailImage.SetActive(!detailImage.activeSelf);
    }
}
