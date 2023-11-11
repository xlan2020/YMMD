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
    public InkDialogueManager dialogueManager;
    

    public void DisplaceWithCurrentInput(){
        displaceWithInput(inputText.text);
    }

    private void displaceWithInput(string input){

        if (!float.TryParse(input, out float inputAmount)){
            // input not a number
            this.handleInputNotNum();
            return;
        }

        if (inputAmount <= 0){
            UnityEngine.Debug.Log("You must input a positive number of money!");
            // UI hint that money is not enough
            this.handleInputIsZero();
            return;
        }

        ItemScriptableObject item = getTargetItemWith(inputAmount);
        
        if (inputAmount > gameManager.GetMoney()){
            this.handleMoneyNotEnough();
            return;
        }

        if (item == null){
            UnityEngine.Debug.Log("money is not enough for item or target is empty!");
            // UI hint that money is not enough
        }
        else {
            // actually displacing
            gameManager.DisplaceItemFromDrawing(inputAmount, item);
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

    private void handleMoneyNotEnough(){
        dialogueManager.MakeChoice(1);
    }

    private void handleInputIsZero(){
        dialogueManager.MakeChoice(2);
    }

    public void handleInputNotNum(){
        dialogueManager.MakeChoice(3);
    }

    public void displaceSuccessProceedDialogue(){
        UnityEngine.Debug.Log("displace success! continue dialogue");
        dialogueManager.MakeChoice(0);
        dialogueManager.ContinueStory();
    }



}
