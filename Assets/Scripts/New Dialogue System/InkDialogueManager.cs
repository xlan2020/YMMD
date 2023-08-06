using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using MH.Mumbler;
public class InkDialogueManager : MonoBehaviour
{
    // variable for the load_globals.ink JSON
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private TextAsset loadBookJSON;

    [Header("Params")]

    public float typingSpeed = 0.04f;
    public float autoPlayingTimeInterval = 1.5f;
    public bool autoMode = false;

    [Header("Sound")]
    public BGMPlayer BGM;
    public CharacterVoice voice;

    [Header("Dialogue UI")]
    public DialoguePanel dialoguePanel;
    public Text speakerName;
    public Text dialogueText;
    public ProfileSwitcher speakerProfile;
    public GameObject continueIcon;
    public Animator portraitAnimator;
    public UnityEngine.Color ThoughtColor;
    public RandomSpeak randomSpeak;

    [Header("Choices UI")]
    // each choice container is an instance of the choice class
    public InkChoiceContainer[] choiceContainer;
    private Dictionary<string, GameObject[]> choicesDict;
    private GameObject[] choices;
    private Text[] choicesText;

    [Header("Drawing Interface Special")]
    [SerializeField] private bool DrawMode = false;
    [SerializeField] private DrawResultManager DrawResultManager;
    [SerializeField] private DrawMaterialManager DrawMaterialManager;
    [SerializeField] private ObserveeManager observeeManager;
    [SerializeField] private SubmitDrawing drawingSubmitter;
    private List<string> currObserveeNames = new List<string>();
    private string choiceType = "BUTTON";
    private int drawResultIndex;
    private bool canSkipChoice = false;
    private bool startSolving = false;

    [Header("Other Functions")]
    [SerializeField] private SolvableManager solvableManager;
    [SerializeField] private SketchBook sketchBook;
    public Player player;
    public GameManager gameManager;

    //tags
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string PROFILE_TAG = "profile";
    private const string CHOICECONTAIN_TAG = "choiceBox";
    private const string SHOW_OBSERVEE_TAG = "showObservee";
    private const string CHOICE_TYPE = "choiceType";
    private const string DRAW_RESULT = "hidden";
    private const string SPEAKER_MODE_TAG = "speakerMode";
    private const string BGM_TAG = "bgm";
    private const string SOLVE_TAG = "solve";
    private const string UNLOCK_NOTE_TAG = "unlockNote";
    private const string LOAD_SCENE_TAG = "loadScene";
    private const string ADD_MONEY_TAG = "addMoney";


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }


    private static InkDialogueManager instance;

    private Coroutine typingLinesCorotine;
    private Coroutine skippingLinesCorotine;
    private Coroutine autoPlayingCorotine;
    private string currentLine;
    private bool isTyping;
    private bool canContinueToNextLine = true;
    private bool finishedRequiredOpera;

    private DialogueVariables dialogueVariables;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one ink dialogue manager per scene!");
        }
        instance = this;
        // pass that variable to the DIalogueVariables constructor in the Awake method
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        initializeChoices();
    }

    private void Start()
    {

        canContinueToNextLine = true;
        finishedRequiredOpera = true;

        dialogueIsPlaying = false;

        // I add these lines because I don't know how to do with cross scene and the project is due tomorrow
        // might delete that sometimes

        // initialize draw mode specials
        if (DrawMode)
        {
            DrawMaterialManager.SetMaterialsInteractive(false);
        }
    }

    private void Update()
    {
        // fast skip: left SHIFT
        if (Input.GetKey(KeyCode.LeftShift)){
            isTyping = false;
            if (skippingLinesCorotine == null){
                UnityEngine.Debug.Log("start fast skipping");
                skippingLinesCorotine = StartCoroutine(skippingLines());
            }
        } else { // when fast skip is released, stop current skipping mode
            if (skippingLinesCorotine != null){
                StopCoroutine(skippingLinesCorotine);
                skippingLinesCorotine = null;
            }
        }
        
        // skip: SPACE
        // if typing, skip typing effect; if already complete, then proceed to next linee
        if (Input.GetKeyDown(KeyCode.Space)){
            if (typingLinesCorotine != null && isTyping){
                // if is typing, then skip the typing effect
                StopCoroutine(typingLinesCorotine);
                isTyping = false;
                dialogueText.text = currentLine;
                UnityEngine.Debug.Log("complete current line");
            } else 
            { 
                // if is not typing, then continue to next line
                UnityEngine.Debug.Log("space continue");
                canContinueToNextLine = true;
                ContinueStory();
                SkipChoice();
                return;
            } 
        }

        // auto plays: CONTROL
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            // toggle auto playing
            autoMode = !autoMode;
            if (autoMode){
                autoPlayingCorotine = StartCoroutine(autoPlaying());
            } else {
                StopCoroutine(autoPlayingCorotine);
            }
        }

    }

    private IEnumerator autoPlaying(){
        UnityEngine.Debug.Log("auto playing");
        while (currentStory.canContinue){
            yield return new WaitForSeconds(autoPlayingTimeInterval);
            ContinueStory();
            SkipChoice();
        }
    }

    private IEnumerator skippingLines(){
        for (int i = 0; i < 999; i++) { // keep skipping, maximam 999 to avoid infinite loop
            UnityEngine.Debug.Log("try to fast skip one line");
            ContinueStory();
            SkipChoice();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator typingLines(string line)
    {
        isTyping = true;

        dialogueText.text = "";
        hideChoices();
        continueIcon.SetActive(false);

        // voice.StartTalking(speakerName.text);
        if (randomSpeak)
        {
            randomSpeak.Speak();
        }
        // fast skip
        string[] splitLines = line.Split(new char[] { ':', '：' }, 2);
        speakerName.text = splitLines[0];
        line = splitLines[1];
        
        currentLine = line;

        yield return new WaitForSeconds(0.04f);
        
        // start typing effect
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;   // typing is finished, line complete
        continueIcon.SetActive(true);
        handleChoiceType();
        // display observees and drawings if there is one
        displayVisualsAfterType();

        if (!startSolving)
        {
            canContinueToNextLine = true;
        }
        else
        {
            canContinueToNextLine = false;
            startSolving = false;
        }
        //voice.StopTalking();
        if (randomSpeak)
        {
            randomSpeak.Stop();
        }
    }

    public void ContinueStory()
    {
        //UnityEngine.Debug.Log("continue story");

        // might remove this later. This check if there're still observees uncollected
        if (observeeManager != null)
        {
            if (observeeManager.CheckFinishCollecting() == false)
            {
                return;
            }
            observeeManager.ClearUncollected();
        }

        // if there is a solving going on or other reason causing the next line can't continue, report and return
        if (!canContinueToNextLine)
        {
            UnityEngine.Debug.Log("try to continue story, but canContinueToNextLine == false");
            return;
        } 

        if (isTyping){
            UnityEngine.Debug.Log("still typing, can't continue story. ");
            return; 
        }

        if (currentStory.canContinue)
        {
            if (typingLinesCorotine != null)
            {
                StopCoroutine(typingLinesCorotine);
            }
            typingLinesCorotine = StartCoroutine(typingLines(currentStory.Continue()));
            handleTags(currentStory.currentTags);
        }
        else if (currentStory.currentChoices.Count > 0)
        {
            return;
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    private void initializeChoices()
    {
        if (choiceContainer.Length > 0)
        {
            // instantiate the dictionary for choices, and store choices in
            choicesDict = new Dictionary<string, GameObject[]>();
            foreach (InkChoiceContainer container in choiceContainer)
            {
                choicesDict.Add(container.getName(), container.getChoices());
            }
            // initialize the default choices
            choices = choiceContainer[0].getChoices();

            choicesText = new Text[choices.Length];
            int i = 0;
            foreach (GameObject choice in choices)
            {
                Text t = choice.GetComponentInChildren<Text>();
                t.text = "对话选项" + i;
                choicesText[i] = t;
                int choiceIndex = i;
                choice.GetComponent<Button>().onClick.AddListener(delegate { MakeChoice(choiceIndex); }); // attach each choice with the correct index
                i++;
            }
        }
    }
    private void displayVisualsAfterType()
    {
        if (observeeManager != null)
        {
            observeeManager.DisplayCurrObservees();
        }

        if (DrawResultManager != null && DrawResultManager.gameObject.activeSelf)
        {
            DrawResultManager.DisplayDrawing();
            DrawResultManager.SetCanShow(false);
        }

    }
    private void handleChoiceType()
    {
        switch (choiceType)
        {
            case "BUTTON":
                displayChoices();
                break;
            case "MATERIAL":
                DrawMaterialManager.SetMaterialsInteractive(true);
                drawingSubmitter.CanSubmit(true);
                choiceType = "BUTTON";
                break;
            case "OBSERVEE":
                handleObserveeChoices();
                choiceType = "BUTTON";
                break;
            case "OBSERVEE_CANSKIP":
                handleObserveeChoices();
                canSkipChoice = true;
                choiceType = "BUTTON";
                break;
            case "DRAW_RESULT":
                canSkipChoice = true;
                DrawResultManager.SetCanShow(true);
                DrawResultManager.SetDrawingResultIndex(drawResultIndex);
                choiceType = "BUTTON";
                break;
            case "AUTO":
                canSkipChoice = true;
                choiceType = "BUTTON";
                break;
            case "SOLVE_OR_LOOP":
                canSkipChoice = true;
                solvableManager.SetSolveToBeChoice(1);
                choiceType = "BUTTON";
                break;
            default:
                break;
        }
    }

    private void handleBGM(string tagValue)
    {
        if (tagValue == "pause")
        {
            BGM.Pause();
            return;
        }
        if (tagValue == "play")
        {
            BGM.Play();
            return;
        }
        BGM.ChangeBGM(tagValue);
    }
    private void handleSpeakerMode(string tagValue)
    {
        switch (tagValue)
        {
            case "thought":
                dialogueText.color = ThoughtColor;
                break;
            case "norm":
                dialogueText.color = UnityEngine.Color.white;
                break;
            default:
                break;
        }
    }
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink variable was found to be null: " + variableName);

        }
        return variableValue;
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.gameObject.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        //reset default Names, Portraits if no tags detected
        speakerName.text = "???";
        portraitAnimator.Play("default");
        if (player)
        {
            player.canMove = false;
        }

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {

        if (player)
        {
            player.canMove = true;
            player.CheckCollectItemAtDialogEnd();
        }
        yield return new WaitForSeconds(.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        //dialoguePanel.gameObject.SetActive(false);
        //dialogueText.text = "";

        //SceneManager.LoadScene(1);

    }


    private void handleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                splitTag = tag.Split('：'); // try again with Chinese character
                if (splitTag.Length != 2)
                { // if still doesn't work
                    Debug.LogError("tag split fault, there're" + splitTag.Length + "tags.");
                }
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
                case CHOICECONTAIN_TAG:
                    // change the choice container
                    choices = choicesDict[tagValue];
                    break;
                case SHOW_OBSERVEE_TAG:
                    // pop up the observee
                    observeeManager.AddToCurrLeft(tagValue);
                    break;
                case CHOICE_TYPE:
                    choiceType = tagValue;
                    break;
                case DRAW_RESULT:
                    drawResultIndex = Int32.Parse(tagValue);
                    UnityEngine.Debug.Log("The result drawing index is: " + drawResultIndex);
                    DrawResultManager.SetDrawingResultIndex(drawResultIndex);
                    DrawResultManager.DisplayDrawing();
                    break;
                case SPEAKER_MODE_TAG:
                    handleSpeakerMode(tagValue);
                    break;
                case BGM_TAG:
                    handleBGM(tagValue);
                    break;
                case SOLVE_TAG:
                    handleSolveTag(tagValue);
                    break;
                case UNLOCK_NOTE_TAG:
                    if (sketchBook != null)
                    {
                        sketchBook.UnlockNewNote(tagValue);
                    }
                    break;
                case PROFILE_TAG:
                    speakerProfile.ChangeProfile(tagValue);
                    break;
                case LOAD_SCENE_TAG:
                    SceneManager.LoadScene(tagValue);
                    break;
                case ADD_MONEY_TAG:
                    gameManager.AddMoney(float.Parse(tagValue));
                    break;
                default:
                    Debug.LogWarning("Unexpected tag from InkJSON");
                    break;
            }
        }
    }

    private void handleSolveTag(string tagValue)
    {
        switch (tagValue)
        {
            case "none":
                return;
            case "hold":
                solvableManager.SetCanSolve(false);
                break;
            case "next":
                solvableManager.SetCanSolve(true);
                startSolving = true;
                break;
            default:
                break;
        }
    }

    private void handleObserveeChoices()
    {
        drawingSubmitter.CanSubmit(true);

    }



    private void hideChoices()
    {
        if (choiceContainer.Length > 0 && choices.Length > 0)
        {
            foreach (GameObject choiceButton in choices)
            {
                choiceButton.SetActive(false);
            }
        }

    }
    private void displayChoices()
    {
        if (choiceContainer.Length > 0)
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
            UnityEngine.Debug.Log("making choice at index: " + choiceIndex);
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    public void SkipChoice()
    {
        if (canSkipChoice)
        {
            canSkipChoice = false;
            MakeChoice(0);
            if (DrawMode)
            {
                drawingSubmitter.CanSubmit(false);
            }
        }
    }

    public void SetCanContinueToNextLine(bool b)
    {
        canContinueToNextLine = b;
    }

    public void FreezeDialogue()
    {
        canContinueToNextLine = false;
        dialoguePanel.SetInteractive(false);
        //dialoguePanel.GetComponent<Collider2D>().enabled = false;
    }

    public void UnfreezeDialogue()
    {
        canContinueToNextLine = true;
        dialoguePanel.SetInteractive(true);
        //dialoguePanel.GetComponent<Collider2D>().enabled = true;
    }
}

