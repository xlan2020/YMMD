using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactPrompt;
    string originPrompt = "";
   
    public void ShowInteractPrompt(string text)
    {
        originPrompt = interactPrompt.text;
        interactPrompt.gameObject.SetActive(true);
        interactPrompt.text += " "+text;
    }
    public void HideInteractPrompt()
    {
        interactPrompt.text = originPrompt;
        interactPrompt.gameObject.SetActive(false);
    }
    public bool isInteractPromptActive()
    {
        return interactPrompt.gameObject.activeSelf;
    }
}
