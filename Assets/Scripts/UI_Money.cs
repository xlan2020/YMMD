using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UI_Money : MonoBehaviour
{
    private Money money;
    public Text moneyDisplay;
    private float displayMoney;
    private float displayMoneyTarget;
    private float displayChangeUnit = 1f;

    public void SetMoney(Money money)
    {
        this.money = money;
        money.onMoneyChanged += Money_OnMoneyChanged;
    }

    private void Money_OnMoneyChanged(object sender, System.EventArgs e)
    {
        StartCoroutine(changingMoneyDisplay(money.GetMoney()));
    }

    private IEnumerator changingMoneyDisplay(float targetMoney)
    {
        // take consideration of the case if money is not an integer
        // the display animation increase / decrease money by 1 unit
        // if the the difference between the target and current display is less than 1 unit
        // increasing and decreasing might never meet the target
        // so we are calculating the difference but not only increasing and decreasing
        // difference is absolute, so actually <-1 unit or >1 unit
        while (displayMoney - targetMoney < -displayChangeUnit)
        {
            displayMoney += displayChangeUnit;
            moneyDisplay.text = displayMoney.ToString("0.00");
            yield return new WaitForSeconds(0.04f);    // animation interval
        }
        while (displayMoney - targetMoney > displayChangeUnit)
        {
            displayMoney -= displayChangeUnit;
            moneyDisplay.text = displayMoney.ToString("0.00");
            yield return new WaitForSeconds(0.04f);    // animation interval
        }
        // else: 
        // -1 unit < displayMoney - targetMoney < 1 unit
        displayMoney = targetMoney;
        moneyDisplay.text = displayMoney.ToString("0.00");

    }
}

