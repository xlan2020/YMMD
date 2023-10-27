using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] float speed = 16000f;
    // [SerializeField] UI_Inventory uiInventory;
    private bool canMove = true;
    public PlayerUIManager uiManager;
    float horizontalInput;
    Rigidbody2D rb;
    bool showInventory = false;
    bool interactCommand;
    public GameManager gameManager;
    private bool collectItemAtDialogueEnd = false;
    private InteractableItem tempCollectItem;

    public InkDialogueManager inkDialogueManager;
    public SketchBook sketchBook;
    public SettingsMenu settingsMenu;
    public InventoryButton inventoryButton;

    private void Awake()
    {


        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //speed *= 100f;
        uiManager = GetComponent<PlayerUIManager>();

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        UpdateCanMove();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            if (Mathf.Abs(horizontalInput) > 0.01f)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            if (horizontalInput < 0 && !sprite.flipX)
            {
                sprite.flipX = true;
            }
            if (horizontalInput > 0 && sprite.flipX)
            {
                sprite.flipX = false;
            }
        }

    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            if (horizontalInput > 0.01f || horizontalInput < 0.01f)
            {
                rb.velocity = (new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y));
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
            CollectItem(item.itemScriptableObject);
            item.DestroySelf();
        }

        if (item.collectAfterDialogue)
        {
            collectItemAtDialogueEnd = true;
            tempCollectItem = item;
        }
    }

    private void CollectItem(ItemScriptableObject itemScriptableObject)
    {
        if (itemScriptableObject != null)
        {
            gameManager.AddItemToInventory(itemScriptableObject);
        }
        else
        {
            UnityEngine.Debug.LogWarning("try to collect item, but ItemScriptableObject is null!");
        }
    }

    public void CheckCollectItemAtDialogEnd()
    {
        if (collectItemAtDialogueEnd)
        {
            collectItemAtDialogueEnd = false;
            CollectItem(tempCollectItem.itemScriptableObject);
            tempCollectItem.DestroySelf();
            tempCollectItem = null;
        }
    }

    private void SetCanMove(bool b)
    {
        canMove = b;

        if (!canMove)
        {
            animator.SetBool("isWalking", false);
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    public void UpdateCanMove()
    {
        if (inkDialogueManager.dialogueIsPlaying || sketchBook.IsOpen() || inventoryButton.ShowingInventory() || SettingsMenu.instance.IsOpen())
        {
            SetCanMove(false);
        }
        else
        {
            SetCanMove(true);
        }
    }
}
