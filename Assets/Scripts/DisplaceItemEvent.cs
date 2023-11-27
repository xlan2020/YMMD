using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceItemEvent : MonoBehaviour
{
    public GameManager gameManager;
    public InventoryButton inventoryButton;
    private int displaceTime = 0;
    private int opnIvtrWhileCanDsplcTime = 0;
    private bool canNowDisplace = false;

    public InkDialogueTrigger howToDisplace;
    public InkDialogueTrigger itemDisplaced;
    void Awake()
    {
        gameManager.onItemDisplaced += onItemDisplaced_firstDisplaceDialogueTrigger;
        inventoryButton.onInventoryOpened += onInventoryOpened_canDisplaceDialogueTrigger;
    }

    public void onItemDisplaced_firstDisplaceDialogueTrigger(object sender, System.EventArgs e)
    {
        if (displaceTime == 0)
        {
            displaceTime++;
            itemDisplaced.StartDialogue();
        }
    }

    public void onInventoryOpened_canDisplaceDialogueTrigger(object sender, System.EventArgs e)
    {
        if (canNowDisplace)
        {
            if (opnIvtrWhileCanDsplcTime == 0)
            {
                opnIvtrWhileCanDsplcTime++;
                howToDisplace.StartDialogue();
            }
        }
    }

    public void SetCanNowDisplace(bool b)
    {
        canNowDisplace = b;
    }

}
