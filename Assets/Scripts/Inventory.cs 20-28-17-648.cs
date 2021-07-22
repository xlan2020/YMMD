using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        Debug.Log("inventory");
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
