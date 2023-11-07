using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaceFromDrawing : MonoBehaviour
{
    public Text inputText;
    public AccurateDepictionScriptableObject drawing;
    public GameManager gameManager;
    public GameObject drawingDisplay;

    

    public void DisplaceWithCurrentInput(){
        displaceWithInput(inputText.text);
    }

    private void displaceWithInput(string input){
        float inputAmount = float.Parse(input);

        if (inputAmount <= 0){
            UnityEngine.Debug.Log("You must input a positive number of money!");
            // UI hint that money is not enough
            return;
        }

        ItemScriptableObject item = getTargetItemWith(inputAmount);
        if (item == null){
            UnityEngine.Debug.Log("money is not enough or target is empty!");
            // UI hint that money is not enough
        }
        else {
            // actually displacing
            gameManager.AddMoney(-inputAmount);
            gameManager.AddItemToInventory(item);
            drawingDisplay.SetActive(false);
        }
        
    }

    ItemScriptableObject getTargetItemWith(float inputAmount){
        ItemScriptableObject matchItem = null;
        float matchMinMoney = 0f;

        foreach (DisplaceTargetItem targetItem in drawing.targetItems){
            if (matchItem==null){
                // simply check and maybe add
                if (inputAmount > targetItem.minMoney){
                    // can displace! 
                    matchItem = targetItem.item;
                    matchMinMoney = targetItem.minMoney;
                }
            } else {
                // compare current and the new one
                if (inputAmount > targetItem.minMoney && targetItem.minMoney > matchMinMoney){
                    // meaning the input fufil the next-level min requirement
                    matchItem=targetItem.item;
                    matchMinMoney=targetItem.minMoney;
                }
            }
        }

        return matchItem;
    }

}
