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

    [Header("UI Element")]
    public DisplaceButton displaceButton;
    public UI_Inventory ui_Inventory;

    public void EnableCustomizeDisplaceButton(){
        displaceButton.StoreButtonCustomAction(customEvent, customButtonText);
        ui_Inventory.SetCustomButtonState(targetCustomizeItem.id);
    }
}
