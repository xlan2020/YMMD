using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler onItemListChanged;
    private List<Item> _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
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
}
