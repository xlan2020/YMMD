using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] float speed = 16000f;
    // [SerializeField] UI_Inventory uiInventory;
    public bool actionFreeze;
    public bool canMove;
    public PlayerUIManager uiManager;
    float horizontalInput;
    Rigidbody2D rb;
    bool showInventory = false;
    bool interactCommand;
    private bool enterInteractable;
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


                }
            }
        }
    }


    public void InteractWithItem(InteractableItem item)
    {
        item.TriggerDialogue();
        item.TriggerEvents();

        if (item.destroyOnInteract)
        {
            item.DestroySelf();
        }

        if (item.collectOnInteract)
        {
            CollectItem(item.GetComponent<ItemInfo>());
            item.DestroySelf();
        }

        if (item.collectAfterDialogue)
        {
            collectItemAtDialogueEnd = true;
            tempCollectItem = item.GetComponent<ItemInfo>();
        }
    }

    private void CollectItem(ItemInfo itemInfo)
    {
        gameManager.inventory.AddItem(itemInfo.GetItem());
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
        UnityEngine.Debug.Log("fixed update called, horizontal input: " + horizontalInput);

        if (horizontalInput > 0.01f || horizontalInput < 0.01f)
        {
            rb.velocity = (new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y));
        }
    }
}
