using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_DisplaceSuccess : MonoBehaviour
{
    [SerializeField] Image displaceInItemImage;
    [SerializeField] private Text displaceInAmount;
    [SerializeField] Image displaceOutItemImage;
    [SerializeField] private Text displaceGainAmount;

    public void HideResultWindow()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowResultWindow_itemToMoney(Item displacedItem)
    {

        this.gameObject.SetActive(true);

        // in image
        displaceInItemImage.gameObject.SetActive(true);
        displaceInItemImage.sprite = displacedItem.spriteImage;

        // in money
        displaceInAmount.gameObject.SetActive(false);

        // out image
        displaceOutItemImage.gameObject.SetActive(false);

        // out money
        displaceGainAmount.gameObject.SetActive(true);
        if (displacedItem.value >= 0)
        {
            // if the money value is positive, than add the "+" sign to specify gain
            displaceGainAmount.text = "+" + displacedItem.value;
        }
        else
        {
            // if less than 0, the "-" sign is already with the number
            displaceGainAmount.text = displacedItem.value.ToString();
        }
    }

    public void ShowResultWindow_moneyToItem(Item item)
    {

        this.gameObject.SetActive(true);

        // in image
        displaceInItemImage.gameObject.SetActive(false);

        // in money
        displaceInAmount.gameObject.SetActive(true);
        displaceInAmount.text = "-" + item.value;

        // out image
        displaceOutItemImage.gameObject.SetActive(true);
        displaceOutItemImage.sprite = item.spriteImage;

        // out money
        displaceGainAmount.gameObject.SetActive(false);
    }

    public void ShowResultWindow_moneyToItem_SO(ItemScriptableObject item)
    {

        this.gameObject.SetActive(true);

        // in image
        displaceInItemImage.gameObject.SetActive(false);

        // in money
        displaceInAmount.gameObject.SetActive(true);
        displaceInAmount.text = "-" + item.value;

        // out image
        displaceOutItemImage.gameObject.SetActive(true);
        displaceOutItemImage.sprite = item.spriteImage;

        // out money
        displaceGainAmount.gameObject.SetActive(false);
    }

}
