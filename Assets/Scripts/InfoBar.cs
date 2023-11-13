using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBar : MonoBehaviour
{
    public Text infoText;

    public void SetInfoText(string s){
        infoText.text = s;
    }
}
