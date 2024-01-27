using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocaleSelectPageDefault : MonoBehaviour
{
    public LocaleSelector localeSelector;

    void Start()
    {
        localeSelector.SelectLocale(0);
    }
}
