using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomizeDisplaceButton : MonoBehaviour
{
    [Header("Custom Event Info")]
    public ItemScriptableObject targetCustomizeItem;
    public UnityEvent customEvent;
    public string customButtonText;
    public string customButtonText_EN;

    [Header("UI Element")]
    public DisplaceButton displaceButton;
    public UI_Inventory ui_Inventory;

    public void EnableCustomizeDisplaceButton()
    {
        string buttonText = "";
        switch (GameEssential.localeId)
        {
            case 0:
                buttonText = customButtonText;
                break;
            case 1:
                buttonText = customButtonText_EN;
                break;
            default:
                break;
        }
        displaceButton.StoreButtonCustomAction(customEvent, buttonText);
        ui_Inventory.SetCustomButtonState(targetCustomizeItem.id);
    }
}
