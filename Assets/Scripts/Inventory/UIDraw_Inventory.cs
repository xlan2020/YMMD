using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum FilterType
{
    canvas = 1,
    brush = 2,
    paint = 3,
    all = 5,
}
public class UIDraw_Inventory : MonoBehaviour
{

    public static UIDraw_Inventory instance { get; private set; }
    public GameObject UIObject;
    [SerializeField] private DrawingSystem drawingSystem;

    private Inventory inventory;
    private List<Item> displayList = new List<Item>();
    private DrawItemSlot[] slots;
    private int currentSlotIndex;
    private List<DrawItemSlot> appliedItemSlots;

    [Header("Scroll View")]
    [SerializeField] Transform itemContainer;
    [SerializeField] GameObject drawMatSlotTemplate;

    [Header("Current Item")]
    [SerializeField] Text currentItemDescription;
    [SerializeField] Text currentItemAttribute;
    [SerializeField] Text currentItemDurability;
    [SerializeField] DrawItemObject drawItemObject;
    [SerializeField] Button applyButton;
    [SerializeField] Text applyButtonText;
    [SerializeField] string applyText;
    [SerializeField] string appliedText;


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


    private FilterType filterType;

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
        SetDrawTypeFilter(FilterType.canvas);
        initializeTabButton();
    }

    public void ShowSelf(bool b)
    {
        UIObject.SetActive(b);
    }
    private void initializeTabButton()
    {
        //UnityEngine.Debug.Log("ui inventory initialize button onclick action");
        canvasTab.GetComponent<Button>().onClick.AddListener(delegate { SetDrawTypeFilter(FilterType.canvas); });
        brushTab.GetComponent<Button>().onClick.AddListener(delegate { SetDrawTypeFilter(FilterType.brush); });
        paintTab.GetComponent<Button>().onClick.AddListener(delegate { SetDrawTypeFilter(FilterType.paint); });
        allTab.GetComponent<Button>().onClick.AddListener(delegate { SetDrawTypeFilter(FilterType.all); });

        applyButton.onClick.AddListener(delegate { ApplyCurrentItem(); });
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
            if ((int)item.drawType == (int)filterType || filterType == FilterType.all)
            {
                displayList.Add(item);
            }
            if (item.drawType == DrawType.brushPaint)
            {
                if (filterType == FilterType.brush || filterType == FilterType.paint)
                {
                    displayList.Add(item);
                }

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
            currentItemAttribute.text = "";
            currentItemDurability.text = "";
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
            currentItemAttribute.text = currentSlot.item.drawAttribute;
            currentItemDurability.text = "耐久：" + currentSlot.item.durability;
            if (currentSlot.item.durability == 1)
            {
                currentItemDurability.color = Color.red;
            }
            else
            {
                currentItemDurability.color = Color.green;
            }
            SetApplyButtonAlreadyApplied(drawingSystem.GetItemByDrawType(currentSlot.item.drawType) == currentSlot.item);
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
        UnityEngine.Debug.Log("ui inventory apply current item");
        drawingSystem.SetDrawItem(slots[currentSlotIndex].item);
        refreshInventoryItems();
    }

    public void SetDrawTypeFilter(FilterType type)
    {
        filterType = type;
        if (type == FilterType.canvas)
        {
            canvasTab.SetSelfSelected(true);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(false);
        }
        else if (type == FilterType.brush)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(true);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(false);
        }
        else if (type == FilterType.paint)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(true);
            allTab.SetSelfSelected(false);
        }
        else if (type == FilterType.all)
        {
            canvasTab.SetSelfSelected(false);
            brushTab.SetSelfSelected(false);
            paintTab.SetSelfSelected(false);
            allTab.SetSelfSelected(true);
        }
        refreshInventoryItems();
    }



    private Sprite GetDrawTypeIcon(Item item)
    {
        switch (item.drawType)
        {
            case DrawType.canvas:
                return canvasTypeIcon;
            case DrawType.brush:
                return brushTypeIcon;
            case DrawType.paint:
                return paintTypeIcon;
            case DrawType.brushPaint:
                return brushPaintTypeIcon;
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
            case FilterType.canvas:
                appliedItems.Add(drawingSystem.GetCanvasItem());
                break;
            case FilterType.brush:
                appliedItems.Add(drawingSystem.GetBrushItem());
                break;
            case FilterType.paint:
                appliedItems.Add(drawingSystem.GetPaintItem());
                break;
            case FilterType.all:
                appliedItems.Add(drawingSystem.GetCanvasItem());
                appliedItems.Add(drawingSystem.GetBrushItem());
                appliedItems.Add(drawingSystem.GetPaintItem());
                break;
            default:
                break;

        }
        return appliedItems;
    }

    private void SetApplyButtonAlreadyApplied(bool applied)
    {
        if (applied)
        {
            applyButton.interactable = false;
            applyButtonText.text = appliedText;
        }
        else
        {
            applyButton.interactable = true;
            applyButtonText.text = applyText;
        }
    }
}
