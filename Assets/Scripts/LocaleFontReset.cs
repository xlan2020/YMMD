using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocaleFontReset : MonoBehaviour
{
    [Header("Asset Info")]
    public Font CH_FONT;
    public Font EN_FONT;

    [Header("Scene Specific")]
    public Text[] resetTexts;


    public void UpdateAllFont()
    {
        Font newFont;
        switch (GameEssential.localeId)
        {
            case 0:
                newFont = CH_FONT;
                break;
            case 1:
                newFont = EN_FONT;
                break;
            default:
                newFont = CH_FONT;
                break;
        }

        foreach (Text text in resetTexts)
        {
            text.font = newFont;
        }
    }
}
