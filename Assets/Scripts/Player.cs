using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite; 
    private Animator animator;
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
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //speed *= 0.001f;
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
        // freeze player when playing dialogue
        if (InkDialogueManager.GetInstance().dialogueIsPlaying)
        {
            actionFreeze = true;
        }
        else
        {
            actionFreeze = false;
        }

            if (!actionFreeze)
        {

            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (animator != null)
            {
                if (Mathf.Abs(horizontalInput) > 0.01f)
                {
                    animator.SetBool("isWalking", true);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                }
            }

            if (horizontalInput < 0 && !sprite.flipX)
            {
                sprite.flipX = true;
            }
            if (horizontalInput > 0 && sprite.flipX)
            {
                sprite.flipX = false;
            }


            if (Input.GetKeyDown(KeyCode.I))
            {
                showInventory = !showInventory;
                uiInventory.gameObject.SetActive(showInventory);
            }
            if (enterInteractable && !InkDialogueManager.GetInstance().dialogueIsPlaying)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactItem)
                    {
                        
                        interactItem.TriggerDialogue();

                        if (interactItem.destroyOnInteract)
                        {
                            interactItem.DestroySelf();
                        }
                        //interactItem.SetInteractable(false);// disable object after interation
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

    private void FixedUpdate()
    {
        

            if (horizontalInput > 0.01f || horizontalInput < 0.01f)
            {
                rb.velocity = (new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y));
            }
        

    }
}
