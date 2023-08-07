using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    //[SerializeField] private AudioClip openAudio;
    [SerializeField] UI_Inventory uiInventory;
    private bool showInventory;
    private Animator animator;

    private AudioSource audio;
    public bool canOpen = true;
    void Awake()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        SetOpen(false);
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
}

