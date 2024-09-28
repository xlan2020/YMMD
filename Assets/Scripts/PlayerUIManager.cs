using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI interactPrompt;
    //[SerializeField] Text interactPrompt;

    [SerializeField] int interactPromptYOffset = 10;
    string originPrompt = "";

    void Start()
    {
        //interactPrompt.gameObject.SetActive(false);
    }
    /**
    public void ShowInteractPrompt(string text)
    {
        originPrompt = interactPrompt.text;
        interactPrompt.gameObject.SetActive(true);
        interactPrompt.text = text;
    }

    public void SetInteractiPromptTransformAboveItem(Vector2 itemTransform)
    {
        RectTransform rect = interactPrompt.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(itemTransform.x, itemTransform.y + interactPromptYOffset);
    }
    public void HideInteractPrompt()
    {
        if (interactPrompt)
        {
            interactPrompt.text = originPrompt;
            interactPrompt.gameObject.SetActive(false);
        }
    }
    public bool isInteractPromptActive()
    {
        return interactPrompt.gameObject.activeSelf;
    }
    */
}
