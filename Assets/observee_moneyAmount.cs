using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class observee_moneyAmount : MonoBehaviour
{
    public Text realMoneyText;
    public Text observeeMoneyText;
    public void DuplicateMoneyText()
    {
        observeeMoneyText.text=realMoneyText.text;
    }
}
