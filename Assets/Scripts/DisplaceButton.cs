using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaceButton : MonoBehaviour
{
    private Animator animator;
    public UI_Inventory uiInventory;
    public GameManager gameManager;
    private Button button;
    private bool interactive;
    [SerializeField] Animator displaceEffect;
    [SerializeField] bool displaceOutFromDrawing = false;
    [SerializeField] DisplaceFromDrawing displaceFromDrawing;

    void Start()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
        button.interactable = interactive;
    }

    private void DisplaceCurrentItem()
    {
        if(!displaceOutFromDrawing){
            gameManager.DisplaceItem(uiInventory.GetCurrentSlot().item);
        }else{
            displaceFromDrawing.DisplaceWithCurrentInput();
        }
    }

    private void turnOnDisplaceEffect(){
        displaceEffect.SetBool("displacing", true);
    }

    private void turnOffDisplaceEffect(){
        displaceEffect.SetBool("displacing", false);
    }
    
    public void SetInteractive(bool b)
    {
        interactive = b;
        if (button)
        {
            button.interactable = b;
        }
    }
}
