using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceItemEvent : MonoBehaviour
{
    public GameManager gameManager;
    private int displaceTime = 0;
    void Awake()
    {
        gameManager.onItemDisplaced += onItemDisplaced_firstDisplaceDialogueTrigger;
    }

    public void onItemDisplaced_firstDisplaceDialogueTrigger(object sender, System.EventArgs e)
    {
        if (displaceTime == 0)
        {
            displaceTime++;
            GetComponent<InkDialogueTrigger>().StartDialogue();
        }
    }

}
