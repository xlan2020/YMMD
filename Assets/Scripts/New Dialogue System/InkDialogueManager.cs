using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialoguePanel;
    public Text speakerName;
    public Text dialogueText;
    public Animator portraitAnimator;

    [Header("Choices UI")]
    public GameObject[] choices;
    private Text[] choicesText;


    //tags
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";


    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static InkDialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one ink dialogue manager per scene!");
        }
        instance = this;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new Text[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<Text>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }


    }

    public static InkDialogueManager GetInstance()
    {
        return instance;
    }
    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            displayChoices();
            handleTags(currentStory.currentTags);
        }
        else if (currentStory.currentChoices.Count>0)
        {
            return;
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void handleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("tag split fault, there're" + splitTag.Length + "tags.");

            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    speakerName.text= tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Unexpected tag from InkJSON");
                    break;
            }
        }
    }

    private void displayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Choices overflow what UI can support, it's" + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        // hide leftover choices 
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);

        }
        StartCoroutine(selectFirstChoice());
    }

    private IEnumerator selectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }

    public void MakeChoice(int choiceIndex)
    {
        //Debug.Log(choiceIndex);
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
