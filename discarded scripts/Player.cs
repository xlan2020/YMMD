using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] float speed = 1f;
    // [SerializeField] UI_Inventory uiInventory;
    public bool actionFreeze;
    public bool canMove;
    public PlayerUIManager uiManager;
    float horizontalInput;
    Rigidbody2D rb;
    bool showInventory = false;
    bool interactCommand;
    private bool enterInteractable;
    private ItemInfo interactItem;
    public GameManager gameManager;
    private bool collectItemAtDialogueEnd = false;
    private ItemInfo tempCollectItem;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //speed *= 100f;
        uiManager = GetComponent<PlayerUIManager>();

        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (!canMove)
        {
            return;
        }
        // freeze player when playing dialogue
        if (InkDialogueManager.GetInstance() != null && InkDialogueManager.GetInstance().dialogueIsPlaying)
        {
            actionFreeze = true;
            animator.SetBool("isWalking", false);
            return;
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

            if (enterInteractable && InkDialogueManager.GetInstance() != null && !InkDialogueManager.GetInstance().dialogueIsPlaying)
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

                        if (interactItem.collectOnInteract)
                        {
                            CollectItem(interactItem);
                        }

                        if (interactItem.collectAfterDialogue)
                        {
                            collectItemAtDialogueEnd = true;
                            tempCollectItem = interactItem;
                        }
                        //interactItem.SetInteractable(false);// disable object after interation
                        interactItem = null;
                        enterInteractable = false;
                    }
                    if (uiManager != null)
                    {
                        uiManager.HideInteractPrompt();
                    }

                }
            }
        }
    }


    public void InteractWithItem()
    {

    }
    private void CollectItem(ItemInfo item)
    {
        gameManager.inventory.AddItem(item.GetItem());
        item.DestroySelf();
    }

    public void CheckCollectItemAtDialogEnd()
    {
        if (collectItemAtDialogueEnd)
        {
            CollectItem(tempCollectItem);
            tempCollectItem = null;
            collectItemAtDialogueEnd = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        enterInteractable = true;
        ItemInfo item = collision.GetComponent<ItemInfo>();
        if (item != null)
        {
            if (uiManager != null && !uiManager.isInteractPromptActive())
            {
                uiManager.ShowInteractPrompt(item.itemName);
                uiManager.SetInteractiPromptTransformAboveItem(new Vector2(item.transform.position.x, item.transform.position.y));
            }
            interactItem = item;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enterInteractable = false;
        if (uiManager != null)
        {
            uiManager.HideInteractPrompt();
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        if (actionFreeze)
        {
            return;
        }
        if (horizontalInput > 0.01f || horizontalInput < 0.01f)
        {
            rb.velocity = (new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y));
        }
    }
}
