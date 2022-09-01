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
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
        if (canOpen)
        {
            showInventory = !showInventory;
            uiInventory.gameObject.SetActive(showInventory);
            animator.SetBool("isOpen", showInventory);
            audio.Play();

            if (showInventory)
            {
                uiInventory.refreshInventoryItems();
            }
        }
    }

    public void SetOpen(bool b)
    {
        if (canOpen || b == false)
        {
            showInventory = b;
            uiInventory.gameObject.SetActive(showInventory);
            animator.SetBool("isOpen", showInventory);
            audio.Play();
        }
    }

}
