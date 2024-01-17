using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool active = false;

    private void Start()
    {
        UpdateLocaleToGame();
    }

    public void UpdateLocaleToGame()
    {

        if (active == true)
        {
            return;
        }
        StartCoroutine(SetLocale(GameEssential.localeId));

    }

    private IEnumerator SetLocale(int _localeID)
    {
        active = true;
        GameEssential.localeId = _localeID;
        UnityEngine.Debug.Log("changing locale to id: " + _localeID);
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }

    public void ToggleLocale()
    {
        if (active == true)
        {
            return;
        }

        GameEssential.localeId++;
        if (GameEssential.localeId > 1)
        {
            GameEssential.localeId = 0;
        }

        UpdateLocaleToGame();
    }

    public void SelectLocale(int i)
    {
        if (active == true)
        {
            return;
        }

        GameEssential.localeId = i;

        UpdateLocaleToGame();

    }
}
