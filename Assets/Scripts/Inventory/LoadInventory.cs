using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInventory : MonoBehaviour
{
    private Inventory inventory;
    public ItemScriptableObject[] inventoryLoadList;

    public void AppendListToInventory(Inventory inventory)
    {
        this.inventory = inventory;
        foreach (ItemScriptableObject itemInfo in inventoryLoadList)
        {
            inventory.AddItemFromScriptableObject(itemInfo);
        }
    }
    /**
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        foreach (ItemScriptableObject itemInfo in inventoryLoadList)
        {
            inventory.AddItemFromScriptableObject(itemInfo);
        }
    }
    */
    /**
        private void AddChildrenToInventory()
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<ItemInfo>() != null)
                {
                    inventory.AddItem(child.GetComponent<ItemInfo>().GetItem());
                }
            }
        }
    */
}
