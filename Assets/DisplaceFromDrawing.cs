using System;
//using System.Collections;
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


    public void DisplaceWithCurrentInput()
    {
        displaceWithInput(inputText.text);
    }

    private void displaceWithInput(string input)
    {

        if (!float.TryParse(input, out float inputAmount))
        {
            // input not a number
            this.handleInputNotNum();
            return;
        }

        inputAmount = (float)(System.Math.Round(inputAmount, 2));
        ItemScriptableObject item = getTargetItemWith(inputAmount);

        if (inputAmount < 0.01f)
        {
            UnityEngine.Debug.Log("You must input a positive number of money!");
            // UI hint that money is not enough
            this.handleInputIsZero();
            return;
        }
        else if (inputAmount > gameManager.GetMoney())
        {
            this.handleMoneyNotEnough();
            return;
        }
        else if (item == null)
        {
            UnityEngine.Debug.Log("money is not enough for item or target is empty!");
            return;
        }
        else
        {
            UnityEngine.Debug.Log("money enough! preparing to displace...");
            // actually displacing
            gameManager.DisplaceItemFromDrawing(inputAmount, item);
            drawingDisplay.SetActive(false);
            displaceSuccessProceedDialogue();
        }

    }

    ItemScriptableObject getTargetItemWith(float inputAmount)
    {
        ItemScriptableObject matchItem = null;
        float matchMinMoney = 0f;

        foreach (DisplaceTargetItem targetItem in drawing.targetItems)
        {
            if (matchItem == null)
            {
                // simply check and maybe add
                if (inputAmount > targetItem.minMoney)
                {
                    // can displace! 
                    matchItem = targetItem.item;
                    matchMinMoney = targetItem.minMoney;
                }
            }
            else
            {
                // compare current and the new one
                if (inputAmount > targetItem.minMoney && targetItem.minMoney > matchMinMoney)
                {
                    // meaning the input fufil the next-level min requirement
                    matchItem = targetItem.item;
                    matchMinMoney = targetItem.minMoney;
                }
            }
        }

        return matchItem;
    }

    private void handleMoneyNotEnough()
    {
        dialogueManager.MakeChoice(1);
    }

    private void handleInputIsZero()
    {
        dialogueManager.MakeChoice(2);
    }

    public void handleInputNotNum()
    {
        dialogueManager.MakeChoice(3);
    }

    public void displaceSuccessProceedDialogue()
    {
        UnityEngine.Debug.Log("displace success! continue dialogue");
        dialogueManager.MakeChoice(0);
        dialogueManager.ContinueStory();
    }



}
