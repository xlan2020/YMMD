using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocaleSelectPageDefault : MonoBehaviour
{
    public Button defaultButton;

    void Start()
    {
        defaultButton.gameObject.GetComponent<AudioSource>().enabled = false;
        defaultButton.onClick.Invoke();
        StartCoroutine(LateStart());
    }

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.04f);
        defaultButton.gameObject.GetComponent<AudioSource>().enabled = true;
    }
}
