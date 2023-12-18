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
    public Text[] resetFontSize;
    public int fontSize_CH = 12;
    public int fontSize_EN = 10;


    public void UpdateAllFont()
    {
        Font newFont;
        int fontSize = 12;

        switch (GameEssential.localeId)
        {
            case 0:
                newFont = CH_FONT;
                fontSize = fontSize_CH;
                break;
            case 1:
                newFont = EN_FONT;
                fontSize = fontSize_EN;
                break;
            default:
                newFont = CH_FONT;
                fontSize = fontSize_CH;
                break;
        }

        foreach (Text text in resetTexts)
        {
            text.font = newFont;
        }

        foreach (Text text in resetFontSize)
        {
            text.fontSize = fontSize;
        }

    }
}
