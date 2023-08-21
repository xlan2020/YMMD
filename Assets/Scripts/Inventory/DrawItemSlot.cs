using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawItemSlot : MonoBehaviour
{
    public Item item;
    private UIDraw_Inventory ui_Inventory;
    public int uiIndex = -1;
    private Animator animator;
    private bool selected = false;
    public Image icon;
    public Text itemName;
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
        ui_Inventory = UIDraw_Inventory.instance;
        selectButton.onClick.AddListener(delegate { SelectSelf(); });
    }
    public void ShowSelfSelected(bool b)
    {
        selected = b;
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("Selected", b);
    }

    public void ShowSelfApplied(bool b)
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("Applied", b);
    }

    public void SelectSelf()
    {
        ui_Inventory.UpdateCurrentSlotIndex(uiIndex);
    }


}
