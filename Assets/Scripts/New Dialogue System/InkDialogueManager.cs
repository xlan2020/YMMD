using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.EventSystems;
using System;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Params")]

    public float typingSpeed = 0.04f;

    [Header("Global Ink File")]
    public InkFile globalInkFile;

    [Header("Dialogue UI")]
    public GameObject dialoguePanel;
    public Text speakerName;
    public Text dialogueText;
    public GameObject continueIcon;
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

    private Coroutine typingLinesCorotine;
    private bool canContinueToNextLine;

    private DialogueVariables dialogueVaribles;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one ink dialogue manager per scene!");
        }
        instance = this;
        dialogueVaribles = new DialogueVariables(globalInkFile.filePath);
    }

    private void Start()
    {
        canContinueToNextLine = true;

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
        // skip the typing effect
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();

        }
    }

    private IEnumerator typingLines(string line)
    {
        dialogueText.text = "";
        hideChoices();
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
        yield return new WaitForSeconds(0.2f);
        foreach (char letter in line.ToCharArray())
        {
            // skip the typing effect
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueIcon.SetActive(true);
        displayChoices();
        canContinueToNextLine = true;
    }



    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVaribles.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink variable was found to be null: " + variableName);
        
        }
        return variableValue;
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);


        dialogueVaribles.StartListening(currentStory);
        //reset default Names, Portraits if no tags detected
        speakerName.text = "???";
        portraitAnimator.Play("default");

        ContinueStory();
    }



    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(.2f);

        dialogueVaribles.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    public void ContinueStory()
    {

        if (canContinueToNextLine&&currentStory.canContinue)
        {
            if (typingLinesCorotine != null)
            {
                StopCoroutine(typingLinesCorotine);
            }
            typingLinesCorotine = StartCoroutine(typingLines(currentStory.Continue()));
            handleTags(currentStory.currentTags);
        }
        else if (!canContinueToNextLine || currentStory.currentChoices.Count > 0)
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
                    speakerName.text = tagValue;
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
    private void hideChoices()
    {
        foreach(GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
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

        if (canContinueToNextLine)
        {

            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }

    }
}
