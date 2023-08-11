using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItemManager : MonoBehaviour
{
    private List<InteractableItem> interactableItems = new List<InteractableItem>();
    public MapPlayer player;
    public MouseCursor cursor;
    public GameObject observeModeOverlay;

    void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<InteractableItem>())
            {
                interactableItems.Add(child.GetComponent<InteractableItem>());
            }
        }

        foreach (InteractableItem item in interactableItems)
        {
            // add interactive function to each interactive sign from script, no need to do it through inspector
            // whenever the interaction starts, show interactive sign as if it's faraway and non-interatable
            item.interactiveSign.gameObject.GetComponent<Button>().onClick.AddListener(delegate { player.InteractWithItem(item); item.interactiveSign.showSelfFar(); });
            item.interactiveSign.SetCursor(cursor);
        }
    }

    void Start()
    {
        HideAllFarSigns();
        observeModeOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { // observe mode on
            ShowAllFarSigns();
            observeModeOverlay.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        { // observe mode off
            HideAllFarSigns();
            observeModeOverlay.SetActive(false);
        }
    }
    void ShowAllFarSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (!item.IsInteractable())
            {
                item.interactiveSign.showSelfFar();
            }
        }
    }

    void HideAllFarSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (!item.IsInteractable())
            {
                item.interactiveSign.hideSelf();
            }
        }
    }
}
