using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaceButton : MonoBehaviour
{
    private Animator animator;
    public UI_Inventory uiInventory;
    public GameManager gameManager;
    private Button button;
    private bool interactive;

    void Start()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
        button.interactable = interactive;
    }

    private void DisplaceCurrentItem()
    {
        gameManager.DisplaceItemAtSlot(uiInventory.GetCurrentSlot());
    }

    public void SetInteractive(bool b)
    {
        interactive = b;
        if (button)
        {
            button.interactable = b;
        }
    }
}