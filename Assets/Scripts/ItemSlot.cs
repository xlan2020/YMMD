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
    public bool isNew = false;

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
        animator.SetBool("isNew", false);
    }
    public void ShowSelfSelected(bool b)
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetBool("Selected", b);
        selected = b;
    }

    public void SetSelfNew(bool b)
    {
        isNew = b;
        animator.SetBool("isNew", b);
    }

    public void SelectSelf()
    {
        ui_Inventory.UpdateCurrentSlotIndex(uiIndex);
    }
}
