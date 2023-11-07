using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money
{
    public event EventHandler onMoneyChanged;
    private float money;

/**
    public void ChangeMoney(float amount)
    {
        money += amount;
        onMoneyChanged?.Invoke(this, EventArgs.Empty);
    }
*/

    public float GetMoney()
    {
        return money;
    }

    public void SetMoney(float amount)
    {
        money = amount;
        onMoneyChanged?.Invoke(this, EventArgs.Empty);
    }

}
