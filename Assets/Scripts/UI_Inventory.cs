using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    
    private Inventory inventory;
    [SerializeField] Transform itemContainer;
    [SerializeField] Transform itemSlotTemplate;
    [SerializeField] float itemSlotCellSize = 80f;
    [SerializeField] int itemsPerLine = 4;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onItemListChanged += Inventory_OnItemListChanged;
        refreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        refreshInventoryItems();
    }
    public void refreshInventoryItems()
    {
        foreach(Transform child in itemContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.spriteImage;
            TextMeshProUGUI name = itemSlotRectTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            name.text = item.itemName;
            TextMeshProUGUI price = itemSlotRectTransform.Find("Price").GetComponent<TextMeshProUGUI>();
            price.text = "$"+item.price;
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            x++;
            if (x > itemsPerLine)
            {
                x = 0;
                y++;
            }
        }
    }
}
