using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public static UI_Inventory instance { get; private set; }
    private Inventory inventory;
    private ItemSlot[] slots;
    private int currentSlotIndex;

    public InventoryButton inventoryButton;
    [SerializeField] Transform itemContainer;
    [SerializeField] GameObject itemSlotTemplate;
    //[SerializeField] float itemSlotCellSize = 80f;
    //[SerializeField] int itemsPerLine = 6;
    //[SerializeField] int itemsPerPage = 24;

    [SerializeField] Text currentItemName;
    [SerializeField] Text currentItemDescription;

    public DisplaceButton displaceButton;
    public Image displacedItemImage;
    public GameObject displaceResult;
    [SerializeField] private Text displaceGainAmount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        HideDisplaceResultWindow();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onItemListChanged += Inventory_OnItemListChanged;
        inventory.onNewItemAdded += Inventory_OnNewItemAdded;
        refreshInventoryItems();
    }


    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        refreshInventoryItems();
    }

    private void Inventory_OnNewItemAdded(object sender, System.EventArgs e)
    {
        inventoryButton.ShowHasNew();
    }

    public int GetCurrentSlotIndex()
    {
        return currentSlotIndex;
    }

    public ItemSlot GetCurrentSlot()
    {
        return slots[currentSlotIndex];
    }

    public void refreshInventoryItems()
    {
        List<Item> itemList = inventory.GetItemList();
        foreach (Transform child in itemContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        slots = new ItemSlot[inventory.Count()];

        int i = 0;
        foreach (Item item in itemList)
        {
            // instantiate item slot for that item
            ItemSlot itemSlot = Instantiate(itemSlotTemplate, itemContainer).GetComponent<ItemSlot>();
            itemSlot.gameObject.SetActive(true);

            // update UI display
            itemSlot.item = item;
            itemSlot.itemImage.sprite = item.spriteImage;
            itemSlot.SetSlotNew(item.isNew);

            // add slot to the new slot list
            slots[i] = itemSlot;
            itemSlot.uiIndex = i;

            i++;
        }

        refreshSelectionUI();

        // UnityEngine.Debug.Log("current item count: " + inventory.Count());
    }

    private void refreshSelectionUI()
    {
        // if the list is empty, then don't bother making updates
        if (inventory.Count() == 0)
        {
            currentItemName.text = "";
            currentItemDescription.text = "";
            displaceButton.SetInteractive(false);
            return;
        }

        // if the current selection is the last item and has been removed, change current to current last item in array
        if (currentSlotIndex >= inventory.Count())
        {
            currentSlotIndex = inventory.Count() - 1;
        }

        // display current slot according to the index
        for (int i = 0; i < inventory.Count(); i++)
        {
            slots[i].ShowSelfSelected(false);
        }

        ItemSlot currentSlot = slots[currentSlotIndex];
        if (currentSlot)
        {
            currentSlot.ShowSelfSelected(true);

            // update item display UI
            currentItemName.text = currentSlot.item.itemName;
            currentItemDescription.text = currentSlot.item.description;
            displaceButton.SetInteractive(currentSlot.item.displaceable);
        }
    }

    public void UpdateCurrentSlotIndex(int index)
    {
        // update slot selection ui by its index
        currentSlotIndex = index;
        refreshSelectionUI();
    }

    public void ShowDisplaceResultWindow(Item displacedItem)
    {
        displaceResult.gameObject.SetActive(true);
        displacedItemImage.sprite = displacedItem.spriteImage;
        if (displacedItem.price >= 0)
        {
            // if the price is positive, than add the "+" sign to specify gain
            displaceGainAmount.text = "+" + displacedItem.price;
        }
        else
        {
            // if less than 0, the "-" sign is already with the number
            displaceGainAmount.text = displacedItem.price.ToString();
        }
    }

    public void HideDisplaceResultWindow()
    {
        displaceResult.gameObject.SetActive(false);
    }

}

/**
// legacy
public void refreshInventoryItems()
{

foreach (Transform child in itemContainer)
{
    if (child == itemSlotTemplate) continue;
    Destroy(child.gameObject);
}
int x = 0;
int y = 0;

List<Item> itemList = inventory.GetItemList();
slots = new ItemSlot[itemsPerPage];

foreach (Item item in itemList)
{
    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemContainer).GetComponent<RectTransform>();
    itemSlotRectTransform.gameObject.SetActive(true);

    ItemSlot itemSlot = itemSlotRectTransform.Find("ItemSlot").GetComponent<ItemSlot>();
    itemSlot.item = item;

    Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
    image.sprite = item.spriteImage;

    itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

    slots[x] = itemSlot;
    itemSlot.uiIndex = x;
    x++;

    if (x == itemsPerLine)
    {
        x = 0;
        y++;
    }
}
RefreshSelectionUI();
}

public void UpdateCurrentSlot(ItemSlot slot)
{
// update slot selection ui by its index
currentSlotIndex = slot.uiIndex;
currentSlot = slots[currentSlotIndex];
UpdateCurrentSlotDisplay();
}

private void RefreshSelectionUI()
{
displaceButton.SetInteractive(false);

// if the list is empty, then don't bother making updates
if (inventory.Count() == 0)
{
    currentItemName.text = "";
    currentItemDescription.text = "";
    currentSlotIndex = 0;
    currentSlot = null;
    return;
}

// if the current selection is the last item and has been removed, change current to current last item in array
if (currentSlotIndex >= inventory.Count())
{
    currentSlotIndex = inventory.Count() - 1;
    currentSlot = slots[currentSlotIndex];
}

UpdateCurrentSlotDisplay();

}

private void UpdateCurrentSlotDisplay()
{
for (int i = 0; i < inventory.Count(); i++)
{
    slots[i].ShowSelfSelected(false);
}
if (currentSlot)
{
    currentSlot.ShowSelfSelected(true);
    // update item display UI
    currentItemName.text = currentSlot.item.itemName;
    currentItemDescription.text = currentSlot.item.description;
    displaceButton.SetInteractive(currentSlot.item.displaceable);
}
}
*/
