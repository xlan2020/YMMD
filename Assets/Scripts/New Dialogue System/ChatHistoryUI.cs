using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatHistoryUI : MonoBehaviour
{
    public GameObject UIObject;
    public Text chatHistoryText;
    public Scrollbar scrollbar;
    private bool displaying = false;

    void Start()
    {
        displaying = false;
        updateChatHistoryDisplay();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            displaying = !displaying;
            updateChatHistoryDisplay();
        }
    }

    private void updateChatHistoryDisplay()
    {
        UIObject.SetActive(displaying);
        if (displaying)
        {
            scrollbar.value = 0f;
        }
    }

    public void AddLine(string line)
    {
        chatHistoryText.text += line + "\n";
        scrollbar.value = 0f;
    }

}
