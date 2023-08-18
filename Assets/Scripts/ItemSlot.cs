using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    public Item item;
    private UI_Inventory ui_Inventory;
    public int uiIndex = -1;
    private Animator animator;
    private bool selected = false;
    public Image itemImage;
    public Button selectButton;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        if (selected)
        {
            animator.SetBool("Selected", true);
        }
        ui_Inventory = UI_Inventory.instance;
        selectButton.onClick.AddListener(delegate { SelectSelf(); });
    }
    public void ShowSelfSelected(bool b)
    {
        GetComponent<Animator>().SetBool("Selected", b);
        selected = b;
    }

    public void SelectSelf()
    {
        ui_Inventory.UpdateCurrentSlotIndex(uiIndex);
    }
}
