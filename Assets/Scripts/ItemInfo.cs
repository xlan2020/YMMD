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
    Item item;
    private void Awake()
    {
        spriteImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        item = new Item
        {
            price = price,
            storePrice = storePrice,
            itemName = itemName,
            description = description,
            spriteImage = spriteImage,
            destroyOnInteract = destroyOnInteract,
            displaceable = displaceable,
        };
    }
    public Item GetItem()
    {
        return item;
    }
}
