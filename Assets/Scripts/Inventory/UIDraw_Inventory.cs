using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDraw_Inventory : MonoBehaviour
{

    public static UIDraw_Inventory instance { get; private set; }
    [SerializeField] private DrawingSystem drawingSystem;

    private Inventory inventory;
    private List<Item> displayList = new List<Item>();
    private DrawItemSlot[] slots;
    private int currentSlotIndex;
    private DrawItemSlot appliedItemSlot;

    [Header("Scroll View")]
    [SerializeField] Transform itemContainer;
    [SerializeField] GameObject drawMatSlotTemplate;

    [Header("Current Item")]
    [SerializeField] Text currentItemDescription;
    [SerializeField] Text currentItemAttribute;
    [SerializeField] DrawItemObject drawItemObject;

    [Header("Draw Type Icon")]
    [SerializeField] Sprite canvasTypeIcon;
    [SerializeField] Sprite brushTypeIcon;
    [SerializeField] Sprite paintTypeIcon;
    [SerializeField] Sprite brushPaintTypeIcon;
    [SerializeField] Sprite notDrawTypeIcon;

    [Header("Draw Type Tab")]
    [SerializeField] DrawTypeTab canvasTab;
    [SerializeField] DrawTypeTab brushTab;
    [SerializeField] DrawTypeTab paintTab;
    [SerializeField] DrawTypeTab allTab;


    private int filterType = 1; // 1-canvas only; 2-brush only; 3-paint only; 4-all

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
        SetDrawTypeFilter(1);
    }
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


    public int GetCurrentSlotIndex()
    {
        return currentSlotIndex;
    }

    public DrawItemSlot GetCurrentSlot()
    {
        return slots[currentSlotIndex];
    }

    public void refreshInventoryItems()
    {
        // clear previous slots
        foreach (Transform child in itemContainer)
        {
            if (child == drawMatSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        List<Item> itemList = inventory.GetItemList();
        filterDisplayList(itemList);
        List<Item> appliedItems = GetTypeAppliedItems();

        slots = new DrawItemSlot[displayList.Count];
        int i = 0;
        foreach (Item item in displayList)
        {
            // instantiate item slot for that item
            DrawItemSlot itemSlot = Instantiate(drawMatSlotTemplate, itemContainer).GetComponent<DrawItemSlot>();
            itemSlot.gameObject.SetActive(true);

            // update item and UI display
            itemSlot.item = item;
            itemSlot.itemName.text = item.itemName;
            itemSlot.icon.sprite = GetDrawTypeIcon(item);

            // update applied item visual
            foreach (Item applied in appliedItems)
            {
                if (applied == item)
                {
                    itemSlot.ShowSelfApplied(true);
                }
            }
            // add slot to the new slot list
            slots[i] = itemSlot;
            itemSlot.uiIndex = i;

            i++;
        }

        refreshSelectionUI();

    }

    private List<Item> filterDisplayList(List<Item> itemList)
    {
        displayList.Clear();
        foreach (Item item in itemList)
        {
            if (getDrawTypeInt(item.drawType) == filterType || filterType == 4)
            {
                displayList.Add(item);
            }
            if (item.artMaterial.brushWithPaint && filterType == 3)
            {
                displayList.Add(item);
            }
        }
        return displayList;
    }
    private void refreshSelectionUI()
    {
        // if the list is empty, then don't bother making updates
        if (displayList.Count == 0)
        {
            drawItemObject.SetItem(null);
            currentItemDescription.text = "";
            return;
        }

        // if the current selection is the last item and has been removed, change current to current last item in array
        if (currentSlotIndex >= displayList.Count)
        {
            currentSlotIndex = displayList.Count - 1;
        }

        // display current slot according to the index
        for (int i = 0; i < displayList.Count; i++)
        {
            slots[i].ShowSelfSelected(false);
        }

        DrawItemSlot currentSlot = slots[currentSlotIndex];
        if (currentSlot)
        {
            currentSlot.ShowSelfSelected(true);

            // update item display UI
            currentItemDescription.text = currentSlot.item.drawDescription;
            drawItemObject.SetItem(currentSlot.item);
        }
    }

    public void UpdateCurrentSlotIndex(int index)
    {
        // update slot selection ui by its index
        currentSlotIndex = index;
        refreshSelectionUI();
    }

    public void ApplyCurrentItem()
    {
        // un-apply the previous slot if any
        if (appliedItemSlot != null)
        {
            appliedItemSlot.ShowSelfApplied(false);
        }

        // apply new slot
        appliedItemSlot = slots[currentSlotIndex];
        appliedItemSlot.ShowSelfApplied(true);

        // logically apply the item to drawing system
        drawingSystem.SetDrawItem(slots[currentSlotIndex].item);
    }


    public void SetDrawTypeFilter(int type)
    {
        filterType = type;
        if (type == 1)
        {
            canvasTab.SetSelfSelected(true);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(false);
        }
        else if (type == 2)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(true);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(false);
        }
        else if (type == 3)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(true);
            allTab.SetSelfSelected(false);
        }
        else if (type == 4)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(true);
        }
        refreshInventoryItems();
    }

    private int getDrawTypeInt(DrawType name)
    {
        switch (name)
        {
            case DrawType.notDraw:
                return 0;
            case DrawType.canvas:
                return 1;
            case DrawType.brush:
                return 2;
            case DrawType.paint:
                return 3;
            default:
                return 0;
        }
    }

    private Sprite GetDrawTypeIcon(Item item)
    {
        switch (item.drawType)
        {
            case DrawType.canvas:
                return canvasTypeIcon;
            case DrawType.brush:
                if (item.artMaterial.brushWithPaint)
                {
                    return brushPaintTypeIcon;
                }
                else
                {
                    return brushTypeIcon;
                }
                break;
            case DrawType.paint:
                return paintTypeIcon;
            default:
                break;
        }
        return null;
    }

    private List<Item> GetTypeAppliedItems()
    {
        List<Item> appliedItems = new List<Item>();
        switch (filterType)
        {
            case 1:
                appliedItems.Add(drawingSystem.GetCanvasItem());
                break;
            case 2:
                appliedItems.Add(drawingSystem.GetBrushItem());
                break;
            case 3:
                appliedItems.Add(drawingSystem.GetPaintItem());
                break;
            case 4:
                appliedItems.Add(drawingSystem.GetCanvasItem());
                appliedItems.Add(drawingSystem.GetBrushItem());
                appliedItems.Add(drawingSystem.GetPaintItem());
                break;
            default:
                break;

        }
        return appliedItems;
    }
}
