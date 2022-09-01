using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Money : MonoBehaviour
{
    private Money money;
    public Text moneyDisplay;

    public void SetMoney(Money money)
    {
        this.money = money;
        money.onMoneyChanged += Money_OnMoneyChanged;
        RefreshMoneyDisplay();
    }


    private void Money_OnMoneyChanged(object sender, System.EventArgs e)
    {
        RefreshMoneyDisplay();
    }

    public void RefreshMoneyDisplay()
    {
        moneyDisplay.text = money.GetMoney().ToString();
    }

}
