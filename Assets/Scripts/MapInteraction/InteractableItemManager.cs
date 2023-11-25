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
            item.interactiveSign.gameObject.GetComponent<Button>().onClick.AddListener(delegate { player.InteractWithItem(item); item.interactiveSign.showSelfFar(); currentItem = item; });
            item.interactiveSign.SetCursor(cursor);
        }

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
                if (!item.IsInteractable())
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
                if (!item.IsInteractable())
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

    public void ReactivateCurrentSign()
    {
        if (currentItem == null)
        {
            UnityEngine.Debug.LogWarning("there isn't a currently interactable item that is tracked!");
            return;
        }
        currentItem.interactiveSign.showSelfNear();
        currentItem = null;
    }

    private void onDialogueEnded_ReactivateCurrentSign(object sender, System.EventArgs e)
    {
        ReactivateCurrentSign();
    }
    public static InteractableItemManager GetInstance()
    {
        return instance;
    }
}
