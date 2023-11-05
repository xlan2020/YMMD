using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;
using MH.Mumbler;
public class InkDialogueManager : MonoBehaviour
{
    // variable for the load_globals.ink JSON
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private TextAsset loadBookJSON;
   
    [Header("Game Essentials")]
    public GameManager gameManager; 
    [SerializeField] LoadingScene loadingScene;

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
    public GameObject autoIcon;
    public Animator portraitAnimator;
    public NameStyleScriptableObject nameStyle;
    public UnityEngine.Color ThoughtColor;
    public RandomSpeak randomSpeak;

    [Header("Choices UI")]
    // each choice container is an instance of the choice class
    private InkChoiceContainer[] choiceContainer;
    private Dictionary<string, GameObject[]> choicesDict;
    public GameObject[] choices;
    private Text[] choicesText;

    [Header("Drawing Interface Special")]
    [SerializeField] private DrawingSystem drawingSystem;
    [SerializeField] private bool DrawMode = false;
    [SerializeField] private DrawResultManager DrawResultManager;
    //[SerializeField] private DrawMaterialManager DrawMaterialManager;
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
    [SerializeField] private SceneEventManager sceneEventManager;
    [SerializeField] private MapPlayer mapPlayer;
    [SerializeField] private InteractableItemManager interactableItemManager;

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
    private const string SFX_TAG = "sfx";
    private const string SOLVE_TAG = "solve";
    private const string UNLOCK_NOTE_TAG = "unlockNote";
    private const string LOAD_SCENE_TAG = "loadScene";
    private const string ADD_MONEY_TAG = "addMoney";
    private const string TRIGGER_EVENT_TAG = "event";
    private const string DRAWING_SYSTEM_TAG = "drawingSystem";


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }


    private static InkDialogueManager instance;
    
    private AudioSource audioSource;

    private Coroutine typingLinesCoroutine;
    private Coroutine skippingLinesCoroutine;
    private Coroutine autoPlayingCoroutine;
    private string currentLine;
    private bool isTyping;
    private bool isFastSkipping = false;
    private bool canContinueToNextLine = true;
    private bool finishedRequiredOpera;

    private DialogueVariables dialogueVariables;
    private Dictionary<string, UnityEngine.Color> nameColorDict = new Dictionary<string, UnityEngine.Color>();
    private Dictionary<string, AudioClip> nameVoiceDict=new Dictionary<string, AudioClip>();


    // rich text handling
    bool richTextTyping = false;
    bool skippingSyntax = false;
    string beginningSyntax = "";
    string closingSyntax = "";
    string richText = "";
    int firstRichCharIndex = 0;
    string indentation = "";
    private void Awake()
    {
        initializeChoices();

        if (instance != null)
        {
            Debug.LogWarning("WARNING: keep only one ink dialogue manager per scene!");
        }
        instance = this;
        // pass that variable to the DIalogueVariables constructor in the Awake method
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        CreateNameStyleDict();

        audioSource=gameObject.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
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
            //DrawMaterialManager.SetMaterialsInteractive(false);
        }
    }

    private void Update()
    {
        // fast skip: left SHIFT
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFastSkipping = true;
            isTyping = false;
            if (skippingLinesCoroutine == null)
            {
                //UnityEngine.Debug.Log("start fast skipping");
                skippingLinesCoroutine = StartCoroutine(skippingLines());
            }
        }
        else
        { // when fast skip is released, stop current skipping mode
            isFastSkipping = false;
            if (skippingLinesCoroutine != null)
            {
                StopCoroutine(skippingLinesCoroutine);
                skippingLinesCoroutine = null;
            }
        }

        // skip: SPACE
        // if typing, skip typing effect; if already complete, then proceed to next linee
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (typingLinesCoroutine != null && isTyping)
            {
                // if is typing, then skip the typing effect
                StopCoroutine(typingLinesCoroutine);
                isTyping = false;
                dialogueText.text = indentation + currentLine;
                //UnityEngine.Debug.Log("complete current line");
                handleAfterLineComplete();
            }
            else
            {
                // if is not typing, then continue to next line
                //UnityEngine.Debug.Log("space continue");
                ContinueStory();
                return;
            }
        }

        // auto plays: CONTROL
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // toggle auto playing
            autoMode = !autoMode;
            autoIcon.SetActive(autoMode);
            if (autoPlayingCoroutine != null)
            {
                StopCoroutine(autoPlayingCoroutine);
            }
            if (autoMode)
            {
                ContinueStory();
            }
        }

    }

    private void CreateNameStyleDict()
    {
        foreach (NameColor nameColor in nameStyle.nameColors)
        {
            nameColorDict.Add(nameColor.name, nameColor.color);
            nameVoiceDict.Add(nameColor.name, nameColor.voiceBlip);
        }
    }

    private IEnumerator autoPlaying()
    {
        UnityEngine.Debug.Log("auto playing");
        while (currentStory.canContinue)
        {
            yield return new WaitForSeconds(autoPlayingTimeInterval);
            ContinueStory();
        }
    }

    private IEnumerator skippingLines()
    {
        for (int i = 0; i < 999; i++)
        { // keep skipping, maximam 999 to avoid infinite loop
            //UnityEngine.Debug.Log("try to fast skip one line");
            ContinueStory();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator typingLines(string line)
    {
        isTyping = true;

        dialogueText.text = indentation;
        hideChoices();
        continueIcon.SetActive(false);

        // voice.StartTalking(speakerName.text);
        if (randomSpeak)
        {
            randomSpeak.Speak();
        }

        string[] splitLines = line.Split(new char[] { ':', '：' }, 2);
        speakerName.text = splitLines[0];
        if (nameColorDict.ContainsKey(splitLines[0]))
        {
            speakerName.color = nameColorDict[splitLines[0]];
            audioSource.clip = nameVoiceDict[splitLines[0]];
        }
        line = splitLines[1];

        currentLine = line;

        yield return new WaitForSeconds(0.04f);

        /**
        // start typing effect
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        */

        char[] letterArray = line.ToCharArray();
        // iniitialize rich text typing needed info
        for (int i = 0; i < letterArray.Length; i++)
        {
            if (isFastSkipping)
            {
                dialogueText.text = currentLine;
                break;
            }

            if (!richTextTyping)
            {
                if (letterArray[i] == '<')
                {
                    richTextTyping = true;
                    firstRichCharIndex = i;
                    bool isFirstLessThan = true;
                    bool isSecondLessThan = false;
                    // check text until end of the line
                    for (int j = 0; j < letterArray.Length - i; j++)
                    {
                        if (isFirstLessThan && !isSecondLessThan)
                        {
                            skippingSyntax = true;
                            beginningSyntax += letterArray[i + j];
                            if (letterArray[i + j] == '>')
                            {
                                isFirstLessThan = false;
                            }
                        }
                        else if (!isFirstLessThan && !isSecondLessThan)
                        {
                            if (letterArray[i + j] == '<')
                            {
                                closingSyntax += '<';
                                isSecondLessThan = true;
                            }
                            else
                            {
                                richText += letterArray[i + j];
                            }
                        }
                        else if (!isFirstLessThan && isSecondLessThan)
                        {
                            closingSyntax += letterArray[i + j];
                            if (letterArray[i + j] == '>')
                            {
                                isFirstLessThan = true;
                                isSecondLessThan = false;
                                break; // second less than already found; 
                            }
                        }
                    }
                }
                else
                {
                    dialogueText.text += letterArray[i];
                    audioSource.Play();
                    yield return new WaitForSeconds(typingSpeed);
                }

            }
            else
            {
                //UnityEngine.Debug.Log("rich text typing! first rich char is: " + letterArray[firstRichCharIndex + beginningSyntax.Length]);
                if (skippingSyntax)
                {    // then doing nothing
                    if (i == firstRichCharIndex + beginningSyntax.Length - 1)
                    {
                        skippingSyntax = false;
                    }
                    if (i == firstRichCharIndex + beginningSyntax.Length + richText.Length + closingSyntax.Length - 1)
                    {
                        // current rich char typing ends, initialize all value
                        richTextTyping = false;
                        skippingSyntax = false;
                        beginningSyntax = "";
                        closingSyntax = "";
                        richText = "";
                    }
                }
                else
                {
                    if (i == firstRichCharIndex + beginningSyntax.Length + richText.Length - 1)
                    {
                        skippingSyntax = true;
                    }
                    dialogueText.text += beginningSyntax + letterArray[i] + closingSyntax;
                    audioSource.Play();
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
        }
        isTyping = false;   // typing is finished, line complete
        handleAfterLineComplete();
    }

    private void handleAfterLineComplete()
    {
        if (currentStory.canContinue)
        {
            continueIcon.SetActive(true);
        }
        handleChoiceType();
        // display observees and drawings if there is one
        displayVisualsAfterType();

        if (startSolving)
        {
            canContinueToNextLine = false;
            startSolving = false;
        }
        //voice.StopTalking();
        if (randomSpeak)
        {
            randomSpeak.Stop();
        }
        if (autoMode)
        {
            autoPlayingCoroutine = StartCoroutine(autoPlaying());
        }
    }

    public void ContinueStory()
    {
        TrySkipChoice();

        //UnityEngine.Debug.Log("InkDialogueManager: continue story is called. ");
        if (isTyping)
        {
            UnityEngine.Debug.Log("still typing, can't continue story. 这时候任何操作都不算数。");
            return;
        }

        // if there is a solving going on or other reason causing the next line can't continue, report and return
        if (!canContinueToNextLine)
        {
            UnityEngine.Debug.Log("try to continue story, but canContinueToNextLine == false");
            return;
        }

        if (currentStory.canContinue)
        {

            // might remove this later. This check if there're still observees uncollected
            if (observeeManager != null)
            {
                if (observeeManager.CheckFinishCollecting() == false)
                {
                    return;
                }
                observeeManager.ClearUncollected();
            }

            if (typingLinesCoroutine != null)
            {
                StopCoroutine(typingLinesCoroutine);
            }
            typingLinesCoroutine = StartCoroutine(typingLines(currentStory.Continue()));
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

        /**
        // instantiate the dictionary for choices, and store choices in
        choicesDict = new Dictionary<string, GameObject[]>();
        foreach (InkChoiceContainer container in choiceContainer)
        {
            choicesDict.Add(container.getName(), container.getChoices());
        }
        */
        // initialize the default choices
        // choices = choiceContainer[0].getChoices();

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

    public DialogueVariables GetDialogueVariables()
    {
        return dialogueVariables;
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
            //case "MATERIAL":
            //  DrawMaterialManager.SetMaterialsInteractive(true);
            //drawingSubmitter.CanSubmit(true);
            //choiceType = "BUTTON";
            //break;
            case "OBSERVEE":
                drawingSystem.HandleObserveeChoices();
                canSkipChoice = false;
                choiceType = "BUTTON";
                break;
            case "OBSERVEE_CANSKIP":
                drawingSystem.HandleObserveeChoices();
                canSkipChoice = true;
                choiceType = "BUTTON";
                break;
            /**
            case "DRAW_RESULT":
                canSkipChoice = true;
                DrawResultManager.SetCanShow(true);
                DrawResultManager.SetDrawingResultIndex(drawResultIndex);
                choiceType = "BUTTON";
                break;
            */
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
        string[] splitTag = tagValue.Split("_");
        if (splitTag.Length == 1)
        {
            BGM.ChangeBGM(splitTag[0], 0.1f);
        }
        else if (splitTag.Length == 2)
        {
            BGM.ChangeBGM(splitTag[0], float.Parse(splitTag[1], CultureInfo.InvariantCulture));
            // UnityEngine.Debug.Log("changing bgm " + splitTag[0] + " to fade in time " + float.Parse(splitTag[1], CultureInfo.InvariantCulture));
        }
        else if (splitTag.Length == 3 && splitTag[0] == "fade")
        {   // format: fade_duration_volume
            BGM.FadeCurrentBGM(float.Parse(splitTag[1], CultureInfo.InvariantCulture), float.Parse(splitTag[2], CultureInfo.InvariantCulture));
        }

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
        autoIcon.SetActive(autoMode);

        dialogueVariables.StartListening(currentStory);

        //reset default Names, Portraits if no tags detected
        speakerName.text = "???";
        if (portraitAnimator!=null){
            portraitAnimator.Play("default");
        }
        ContinueStory();

        if (mapPlayer)
        {
            mapPlayer.UpdateCanMove();
            UnityEngine.Debug.Log("updating player can move!");
        }


    }

    private IEnumerator ExitDialogueMode()
    {
        dialogueIsPlaying = false;

        if (mapPlayer)
        {
            mapPlayer.CheckCollectItemAtDialogEnd();
            mapPlayer.UpdateCanMove();
        }
        if (interactableItemManager)
        {
            interactableItemManager.RefreshInteractableSigns();
        }
        yield return new WaitForSeconds(.2f);

        dialogueVariables.StopListening(currentStory);
        //dialoguePanel.gameObject.SetActive(false);
        //dialogueText.text = "";

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
                    loadingScene.LoadScene(tagValue);
                    break;
                case ADD_MONEY_TAG:
                    gameManager.AddMoney(float.Parse(tagValue));
                    break;
                case TRIGGER_EVENT_TAG:
                    sceneEventManager.TriggerEvent(tagValue);
                    break;
                case DRAWING_SYSTEM_TAG:
                    handleDrawingSystemTag(tagValue);
                    break;
                default:
                    Debug.LogWarning("Unexpected tag from InkJSON");
                    break;
            }
        }
    }

    private void handleDrawingSystemTag(string tagValue)
    {
        drawingSystem.HandleInkDialogueTagValue(tagValue);
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



    private void hideChoices()
    {
        if (choices.Length > 0)
        {
            foreach (GameObject choiceButton in choices)
            {
                choiceButton.SetActive(false);
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
        UnityEngine.Debug.Log("making choice at index: " + choiceIndex);
        
        // in case this is a 'CANSKIP' choice
        // when a choice is already made
        // then won't be skipping to the default [0] choice again
        canSkipChoice=false; 

        currentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }


    public void TrySkipChoice()
    {
        if (canSkipChoice)
        {
            // the following actually skips choice
            canSkipChoice = false;
            canContinueToNextLine=true;
            currentStory.ChooseChoiceIndex(0);
            if (DrawMode)
            {
                drawingSubmitter.SetCanSubmit(false);
                // delete uselss observee
                observeeManager.DissolveCollected();
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

