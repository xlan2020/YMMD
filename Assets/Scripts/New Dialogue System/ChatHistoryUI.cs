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

    private List<string> allChatHistory;
    private int maxCharacterLimit = 10000;
    private int currentChatIndex = 0;


    private static string SEE_NEXT_PAGE = "<color=green>[→] 查看下一页</color>";
    private static string SEE_PREV_PAGE = "<color=green>[←] 查看前一页</color>";
    private static string SEE_NEXT_PAGE_EN = "<color=green>[→] see next page</color>";
    private static string SEE_PREV_PAGE_EN = "<color=green>[←] see previous page</color>";

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

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            DisplayPreviousChatHistory();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            DisplayNextChatHistory();
        }
    }

    private void initializeChatHistory()
    {
        allChatHistory = new List<string>();
        allChatHistory.Add("");
    }

    private void updateChatHistoryDisplay()
    {
        // automatically show the most recent part of chat history
        UIObject.SetActive(displaying);
        if (displaying)
        {
            //UnityEngine.Debug.Log("CHAT HISTORY: update scroll bar value");
            DisplayRecentChat();
        }
    }

    private IEnumerator ScrollingToBottom()
    {
        yield return new WaitForSeconds(0.04f);
        scrollbar.value = 0f;
    }

    private IEnumerator ScrollingToTop()
    {
        yield return new WaitForSeconds(0.04f);
        scrollbar.value = 1f;
    }

    private void DisplayRecentChat()
    {
        if (allChatHistory != null && allChatHistory.Count > 0)
        {
            currentChatIndex = allChatHistory.Count - 1;
            chatHistoryText.text = GetChatStringAtIndex(currentChatIndex);
        }

        // Scroll to the bottom of the new text after loading
        StartCoroutine(ScrollingToBottom());
    }

    private void DisplayPreviousChatHistory()
    {
        if (currentChatIndex > 0)
        {
            currentChatIndex--; // Move to the previous chat string
            string previousChat = GetChatStringAtIndex(currentChatIndex);
            chatHistoryText.text = previousChat;

            // Scroll to the bottom of the new text after loading
            StartCoroutine(ScrollingToBottom());
        }
    }

    private void DisplayNextChatHistory()
    {
        if (currentChatIndex < allChatHistory.Count - 1)
        {
            currentChatIndex++; // Move to the next chat string
            string nextChat = GetChatStringAtIndex(currentChatIndex);
            chatHistoryText.text = nextChat;

            // Scroll to the top of the new text after loading
            StartCoroutine(ScrollingToTop());
        }
    }

    // Method to get a specific string segment from the chat history by index
    private string GetChatStringAtIndex(int index)
    {
        if (index >= 0 && index < allChatHistory.Count)
        {
            return allChatHistory[index];
        }
        return string.Empty; // Return empty string if the index is invalid
    }

    /**
    *****PUBLIC METHODS*****
    */

    public void DisplayUI(bool b)
    {
        displaying = b;
        updateChatHistoryDisplay();
    }

    public void AddLine(string newLine)
    {
        //LEGACY: 
        //chatHistoryText.text += line + "\n";

        // only add line to logic data
        // ui display change is a private method within this class
        if (allChatHistory == null)
        {
            initializeChatHistory();
        }
        else if (allChatHistory.Count == 0)
        {
            initializeChatHistory();
        }

        string addedLine = newLine + "\n";

        int lastIndex = allChatHistory.Count - 1; // Get the last string in the history
        // Check if adding the new line exceeds the current string's character limit
        if (allChatHistory[lastIndex].Length + newLine.Length > maxCharacterLimit)
        {
            // Add it to a new string index

            // update UI helper text
            switch (GameEssential.localeId)
            {
                case 0:
                    allChatHistory[lastIndex] += SEE_NEXT_PAGE;
                    addedLine = SEE_PREV_PAGE + "\n" + addedLine;
                    break;
                case 1:
                    allChatHistory[lastIndex] += SEE_NEXT_PAGE_EN;
                    addedLine = SEE_PREV_PAGE_EN + "\n" + addedLine;
                    break;
                default:
                    allChatHistory[lastIndex] += SEE_NEXT_PAGE;
                    addedLine = SEE_PREV_PAGE + "\n" + addedLine;
                    break;
            }
            allChatHistory.Add(addedLine);
        }
        else
        {
            // If not exceeding the limit, append to the last string
            allChatHistory[lastIndex] += addedLine;
        }

        // Update UI
        if (displaying)
        {
            DisplayRecentChat(); // this includes scrolling to bottom
        }
    }


    private void appendSceneDivisionLine()
    {
        if (allChatHistory != null && allChatHistory.Count > 0)
        {
            int lastIndex = allChatHistory.Count - 1;
            string divisionLine = "\n" + "-----------------------" + "\n" + "\n";
            allChatHistory[lastIndex] += divisionLine;
        }
    }

    // Method to retrieve the entire chat history as save object
    public List<string> GetAllChatHistoryForSave()
    {
        if (allChatHistory == null)
        {
            initializeChatHistory();
        }
        else
        {
            appendSceneDivisionLine();
        }
        return allChatHistory;
    }

    public void LoadAllChatHistory(List<string> saveObject)
    {
        allChatHistory = saveObject;
    }
}

