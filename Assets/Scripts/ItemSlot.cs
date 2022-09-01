using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    public UI_Inventory ui_Inventory;
    public int uiIndex = -1;
    private Animator animator;
    private bool selected = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (selected)
        {
            animator.SetBool("Selected", true);
        }
    }
    public void ShowSelfSelected(bool b)
    {
        GetComponent<Animator>().SetBool("Selected", b);
        selected = b;
    }

    public void SelectSelf()
    {
        ui_Inventory.UpdateCurrentSlot(this);
    }
}
