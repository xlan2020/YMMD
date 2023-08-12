using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public static InventoryButton instance { get; private set; }
    //[SerializeField] private AudioClip openAudio;
    [SerializeField] UI_Inventory uiInventory;
    private bool showInventory;
    private Animator animator;
    private MapPlayer mapPlayer;

    private AudioSource audio;
    public bool canOpen = true;
    void Awake()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetOpen(false);
        mapPlayer = MapPlayer.instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleOpen();
        }
    }
    public void ToggleOpen()
    {
        if (!canOpen)
        {
            return;
        }

        showInventory = !showInventory;
        RefreshDisplayState();
        audio.Play();

        if (showInventory)
        {
            uiInventory.refreshInventoryItems();
        }

        if (mapPlayer)
        {
            mapPlayer.UpdateCanMove();
        }

    }

    public void SetOpen(bool b)
    {
        if (!canOpen)
        {
            return;
        }

        showInventory = b;
        RefreshDisplayState();
        audio.Play();
    }

    private void RefreshDisplayState()
    {
        uiInventory.gameObject.SetActive(showInventory);
        animator.SetBool("isOpen", showInventory);
        if (!showInventory)
        {
            uiInventory.displaceResult.gameObject.SetActive(false);
        }
    }

    public bool ShowingInventory()
    {
        return showInventory;
    }
}

