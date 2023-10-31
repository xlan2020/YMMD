using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class observee_moneyAmount : MonoBehaviour
{
    public GameObject moneyText;
    public void DuplicateMoneyText()
    {
        GameObject obj = Instantiate(moneyText, this.gameObject.transform);
        obj.GetComponent<Text>().color = Color.yellow;
    }
}
