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
    bool observing;

    private InteractableItem currentItem;

    private static InteractableItemManager instance;

    private List<InteractiveSign> tempDisabledSigns = new List<InteractiveSign>();
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one ink dialogue manager per scene!");
        }
        instance = this;


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
            if (item.autoTrigger == false)
            {
                item.interactiveSign.gameObject.GetComponent<Button>().onClick.AddListener(delegate { this.interactWithItem(item); });
                item.interactiveSign.SetCursor(cursor);
            }
            else
            {
                item.SetEventsOnAutoEnter(delegate { this.interactWithItem(item); });
            }
        }

    }

    private void interactWithItem(InteractableItem item)
    {
        player.InteractWithItem(item);
        currentItem = item;
        deactivateAllSigns();
    }

    void Start()
    {
        InkDialogueManager.GetInstance().onDialogueEnded += onDialogueEnded_ReactivateCurrentSign;
        HideAllFarSigns();
        observeModeOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { // observe mode on
            observing = true;
            ShowAllFarSigns();
            observeModeOverlay.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        { // observe mode off
            observing = false;
            HideAllFarSigns();
            observeModeOverlay.SetActive(false);
        }
    }
    void ShowAllFarSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (item != null)
            {
                if (!item.IsInteractable() && item.interactiveSign != null)
                {
                    item.interactiveSign.showSelfFar();
                }
            }
        }

    }

    void HideAllFarSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (item != null)
            {
                if (!item.IsInteractable() && item.interactiveSign != null)
                {
                    item.interactiveSign.hideSelf();
                }
            }
        }
    }

    public void RefreshInteractableSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (item != null)
            {
                if (item.interactiveSign != null)
                {
                    if (item.IsInteractable())
                    {
                        item.interactiveSign.showSelfNear();
                    }
                    else if (observing)
                    {
                        item.interactiveSign.showSelfFar();
                    }
                    else
                    {
                        item.interactiveSign.hideSelf();
                    }
                }
            }
        }
    }

    public void ReactivateCurrentSign()
    {
        foreach (InteractiveSign sign in tempDisabledSigns)
        {
            if (sign != null)
            {
                sign.showSelfNear();
            }
        }
        tempDisabledSigns = new List<InteractiveSign>();
        /*
        if (currentItem == null)
        {
            UnityEngine.Debug.LogWarning("there isn't a currently interactable item that is tracked!");
            return;
        }
        currentItem.interactiveSign.showSelfNear();
        currentItem = null;
        */
    }

    private void onDialogueEnded_ReactivateCurrentSign(object sender, System.EventArgs e)
    {
        ReactivateCurrentSign();
    }
    public static InteractableItemManager GetInstance()
    {
        return instance;
    }

    private void deactivateAllSigns()
    {
        foreach (InteractableItem item in interactableItems)
        {
            if (item != null && currentItem.dialogueTrigger != null)
            {
                if (item.interactiveSign != null)
                {
                    // deactivate only for dialogue type, but not collect and event trigger type
                    if (item.interactiveSign.IsNear())
                    {
                        item.interactiveSign.showSelfFar();
                        tempDisabledSigns.Add(item.interactiveSign);
                    }
                }
            }
        }
    }
}
