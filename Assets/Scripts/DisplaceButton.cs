using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum DisplaceButtonType
{
    CurrentItem,
    FromDrawing,
    Custom
}
public class DisplaceButton : MonoBehaviour
{
    private Animator animator;
    public UI_Inventory uiInventory;
    public GameManager gameManager;
    [SerializeField] Button button;
    private bool interactive;
    [SerializeField] Text buttonText;
    [SerializeField] DisplaceFromDrawing displaceFromDrawing;
    [SerializeField] DisplaceButtonType buttonType = DisplaceButtonType.CurrentItem;
    private UnityEvent customEvent;
    private string customButtonText;
    private bool hasCustomAction;

    void Awake()
    {
        if (buttonType == DisplaceButtonType.FromDrawing)
        {
            interactive = true;
        }
        else
        {
            interactive = false;
        }
        animator = button.GetComponent<Animator>();
        button.interactable = interactive;
    }

    public void ShowButton(bool b)
    {
        button.gameObject.SetActive(b);
    }
    public void ExecuteDisplaceAction()
    {
        switch (buttonType)
        {
            case DisplaceButtonType.CurrentItem:
                gameManager.DisplaceItem(uiInventory.GetCurrentSlot().item);
                break;
            case DisplaceButtonType.FromDrawing:
                displaceFromDrawing.DisplaceWithCurrentInput();
                break;
            case DisplaceButtonType.Custom:
                customEvent.Invoke();
                break;
            default:
                break;
        }
    }

    public void SetInteractive(bool b)
    {
        interactive = b;
        if (button)
        {
            button.interactable = b;
        }
    }

    public void SetButtonTypeCurrentItem()
    {
        buttonType = DisplaceButtonType.CurrentItem;
        buttonText.text = "置换!";
        animator.SetBool("Blink", false);
    }

    public void ActivateButtonTypeCustom()
    {
        UnityEngine.Debug.Log("button custom mode activated!");
        buttonType = DisplaceButtonType.Custom;
        buttonText.text = customButtonText;
        button.interactable = true;
        animator.SetBool("Blink", true);
    }

    public void StoreButtonCustomAction(UnityEvent newEvent, string uiText)
    {
        UnityEngine.Debug.Log("button custom action is stored! potential to have custom action.");
        hasCustomAction = true;
        customEvent = newEvent;
        customEvent.AddListener(this.RemoveCustomAction); // one-time custom action, remove once it's done
        customButtonText = uiText;
    }

    public void RemoveCustomAction()
    {
        hasCustomAction = false;
        customEvent = null;
    }

    public bool HasCustomAction()
    {
        return hasCustomAction;
    }
}
