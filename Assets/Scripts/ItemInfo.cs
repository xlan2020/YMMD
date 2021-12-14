using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public float price;
    public string itemName;
    public string description;
    public Sprite spriteImage;
    public bool destroyOnInteract;
    public InkDialogueTrigger dialogueTrigger;

    Item item;
    private void Awake()
    {
        spriteImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        dialogueTrigger = GetComponent<InkDialogueTrigger>();
        item = new Item { price = price, itemName = itemName, description = description, spriteImage = spriteImage, destroyOnInteract = destroyOnInteract };
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
}
