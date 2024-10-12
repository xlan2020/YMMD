using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler onItemListChanged;
    public event EventHandler onNewItemAdded;
    private List<Item> _itemList;
    public ItemScriptableObject cashItem;
    private bool hasCashItem = false;


    public Inventory()
    {
        _itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
        if (item.isNew)
        {
            onNewItemAdded?.Invoke(this, EventArgs.Empty);
        }
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

    public int[] GetItemIdSaveArray()
    {

        int[] saveArray = new int[_itemList.Count];

        for (int i = 0; i < _itemList.Count; i++)
        {
            saveArray[i] = _itemList[i].id;
        }

        return saveArray;
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

    public void LoadItemListFromIdArray(int[] idArray, ItemScriptableObject[] allItemArray)
    {
        _itemList = new List<Item>();
        for (int i = 0; i < idArray.Length; i++)
        {
            int id = idArray[i];

            Item item = createItemFromScriptableObject(allItemArray[id]);
            item.isNew = false;
            // 目前版本的问题：item的价值、耐久……等等已经变化了，但是存的还是初始的这个item array，新的item变化没有保存
            _itemList.Add(item);
            onItemListChanged?.Invoke(this, EventArgs.Empty);
        }

    }

    public Item AddItemFromScriptableObject(ItemScriptableObject itemInfo)
    {
        Item item = createItemFromScriptableObject(itemInfo);
        AddItem(item);
        return item;
    }

    private Item createItemFromScriptableObject(ItemScriptableObject itemInfo)
    {
        Item item = new Item
        {
            id = itemInfo.id,
            value = itemInfo.value,
            storePrice = itemInfo.storePrice,
            itemName = itemInfo.itemName,
            itemName_EN = itemInfo.itemName_EN,
            description = itemInfo.description,
            description_EN = itemInfo.description_EN,
            storeTalk = itemInfo.storeTalk,
            storeTalk_EN = itemInfo.storeTalk_EN,

            spriteImage = itemInfo.spriteImage,
            destroyOnInteract = itemInfo.destroyOnInteract,
            displaceable = itemInfo.displaceable,
            isNew = itemInfo.IsNew(),

            durability = itemInfo.durability,
            drawType = itemInfo.drawType,

            artMaterial = itemInfo.artMaterial,
            drawDescription = itemInfo.drawDescription,
            drawDescription_EN = itemInfo.drawDescription_EN,
            drawAttribute = itemInfo.drawAttribute,
            drawAttribute_EN = itemInfo.drawAttribute_EN,
            draw_stable = itemInfo.draw_stable,
            draw_experimental = itemInfo.draw_experimental,
            draw_organic = itemInfo.draw_organic,
            draw_premium = itemInfo.draw_premium
        };
        return item;
    }
    public void TryAddCashItem()
    {
        if (!hasCashItem)
        {
            hasCashItem = true;
            Item cash = createItemFromScriptableObject(cashItem);
            // insert at first, since cash is different from other item
            _itemList.Insert(0, cash);
            onItemListChanged?.Invoke(this, EventArgs.Empty);
            onNewItemAdded?.Invoke(this, EventArgs.Empty);
        }
    }

    public void TryRemoveCashItem()
    {
        if (hasCashItem)
        {
            hasCashItem = false;
            RemoveItemAtIndex(0);
        }
    }
}
