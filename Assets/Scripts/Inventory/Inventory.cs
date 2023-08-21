using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler onItemListChanged;
    public event EventHandler onNewItemAdded;
    private List<Item> _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
        onNewItemAdded?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        _itemList.Remove(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    public void RemoveItemAtIndex(int index)
    {
        _itemList.RemoveAt(index);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return _itemList;
    }

    public int Count()
    {
        return _itemList.Count;
    }

    public void SetItemList(List<Item> itemList)
    {
        if (itemList != null && itemList.Capacity > 0)
        {
            _itemList = itemList;
            onItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public Item AddItemFromScriptableObject(ItemScriptableObject itemInfo)
    {
        Item item = new Item
        {
            value = itemInfo.value,
            storePrice = itemInfo.storePrice,
            itemName = itemInfo.itemName,
            description = itemInfo.description,
            spriteImage = itemInfo.spriteImage,
            destroyOnInteract = itemInfo.destroyOnInteract,
            displaceable = itemInfo.displaceable,
            isNew = itemInfo.IsNew(),

            durability = itemInfo.durability,
            drawType = itemInfo.drawType,
            // legacy int: 0 - not draw 1-  画布; 2 - 画笔; 3 - 颜料; 
            artMaterial = itemInfo.artMaterial,
            drawDescription = itemInfo.drawDescription,
            drawAttribute = itemInfo.drawAttribute,
            draw_stable = itemInfo.draw_stable,
            draw_experimental = itemInfo.draw_experimental,
            draw_organic = itemInfo.draw_organic,
            draw_premiere = itemInfo.draw_premiere
        };
        AddItem(item);
        return item;
    }
}
