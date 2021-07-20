using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public ImageSwitcher imageSwitcher;
    public GameObject image;
    [SerializeField] Button printer;
    private bool trRunning = false;
    private string prevSentence;
    private string prevSpeakerName;
    private Queue<string> sentences;
    private Queue<string> names;

    // Start is called before the first frame update
    void Start()
    {
        // FIFO Q that stores sentence as strings.
        sentences = new Queue<string>();
        names = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        //nameText.text = dialogue.name;

        // Deletes sentences in previous dialogue from the queue
        sentences.Clear();

        // enqueue the sentences from current dialogue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    // Displays next sentence
    public void DisplayNextSentence()
    {
        // stores the current sentence on display;
        string currentSentence;
        string currentSpeakerName;

        // if nothing's left in the queue, end the dialogue.
        if (sentences.Count == 0)
        {
            // stops typewritter animation and print the last sentence
            StopAllCoroutines();
            dialogueText.text = prevSentence;
            nameText.text = prevSpeakerName;
            EndDialogue();
            return;
        }

        // Speeding-up effect - double click shows the full sentence without typewriter animation
        if (trRunning == true)
        {
            // if TypeSentence is running, stop it and show full sentence from last call
            StopAllCoroutines();
            dialogueText.text = prevSentence;
            nameText.text = prevSpeakerName;

            // sets running to false
            trRunning = false;
        }
        else
        {
            imageSwitcher.Switch();
            currentSentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(currentSentence));
            currentSpeakerName = names.Dequeue();
            nameText.text = currentSpeakerName;
            // updates prevSentence to the most recently dequeued one
            prevSentence = currentSentence;
            prevSpeakerName = currentSpeakerName;

            trRunning = true;
        }


    }
    // animates the typewriter effect
    IEnumerator TypeSentence (string sentence)
    {
        trRunning = true;
        // sets text to be displayed to ""
        dialogueText.text = "";

        // display one by one
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            // waits for 3 frames; still working on Deltatime
            yield return StartCoroutine(WaitFor.FramesNum(3));
        }
        trRunning = false;

    }

    void EndDialogue()
    {
        sentences.Clear();
        image.SetActive(true);
        if (printer)
        {
            printer.enabled =true;
        }
    }




}
