using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TS_LocalizeTitleUpdate : MonoBehaviour
{
    public SpriteRenderer[] CH_titleSprites;
    public GameObject EN_titleObject;

    public void UpdateTitleDisplay()
    {
        switch (GameEssential.localeId)
        {
            case 0:
                EN_titleObject.SetActive(false);
                SetSpritesDisplay(CH_titleSprites, true);
                break;
            case 1:
                EN_titleObject.SetActive(true);
                SetSpritesDisplay(CH_titleSprites, false);
                break;
            default:
                break;
        }
    }

    private void SetSpritesDisplay(SpriteRenderer[] sprites, bool b)
    {
        foreach (SpriteRenderer sp in sprites)
        {
            sp.enabled = b;
        }
    }
}
