using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] UI_Inventory uiInventory;
    public bool actionFreeze;
    public PlayerUIManager uiManager;
    float horizontalInput;
    Inventory inventory;
    Rigidbody2D rb;
    bool showInventory = false;
    bool interactCommand;
    private bool enterInteractable;
    private ItemInfo interactItem;

    private void Awake()
    {
        speed *= 0.001f;
        uiManager = GetComponent<PlayerUIManager>();
        inventory = new Inventory();
        if (uiInventory)
        {
            uiInventory.SetInventory(inventory);
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
        inventory.SetItemList(StaticInventory.ItemArry);
    }
    private void Update()
    {
        if (!actionFreeze)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector2(horizontalInput * speed, 0));

            if (Input.GetKeyDown(KeyCode.I))
            {
                showInventory = !showInventory;
                uiInventory.gameObject.SetActive(showInventory);
            }
            if (enterInteractable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactItem)
                    {
                        if (interactItem.destroyOnInteract)
                        {
                            interactItem.DestroySelf();
                        }
                        interactItem.SetInteractable(false);
                        interactItem = null;
                        enterInteractable = false;
                    }

                    uiManager.HideInteractPrompt();

                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        enterInteractable = true;
        ItemInfo item = collision.GetComponent<ItemInfo>();
        if (item != null)
        {
            if (!uiManager.isInteractPromptActive())
            {
                uiManager.ShowInteractPrompt(item.itemName);
            }
            interactItem = item;
            //inventory.AddItem(item.GetItem());

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enterInteractable = false;
        uiManager.HideInteractPrompt();
    }
    public void SaveInventory()
    {
        StaticInventory.ItemArry = inventory.GetItemList();
    }
}
