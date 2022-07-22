using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeChannelText : MonoBehaviour
{

    private bool readyToType = false;
    private Text t;

    private string[] currLines;
    private int currLineIndex = 0;
    private bool holdingDown = false;
    public ThreeChannelManager manager;

    public int attemptTimeLimit = 10;
    private int attemptTime = 0;

    private Animator animator;
    private bool attempting = false;
    private bool changingNextLine = false;

    public float textChangeInterval = 0.2f;
    private float textChangeTimer;

    public AudioClip attemptTypingSFX;
    public AudioClip decideTypingSFX;
    private AudioSource audioSource;
    void Start()
    {
        t = GetComponent<Text>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (readyToType)
        {
            textChangeTimer += Time.deltaTime;
            if (textChangeTimer > textChangeInterval)
            {
                textChangeTimer = 0; //reset timer

                // check key input
                if (Input.anyKey)
                {
                    // Debug.Log("A key is being pressed");
                    holdingDown = true;

                    if (!changingNextLine)
                    { // can't keep attempting if one line is just decided
                        AttemptTyping();
                    }
                }

                if (!Input.anyKey && holdingDown)
                {
                    // Debug.Log("A key was released");
                    holdingDown = false;

                    if (changingNextLine)
                    {
                        changingNextLine = false; //lift key up, then we can re-press the key and attempt typing again
                    }
                }
            }
        }
    }


    private void OnMouseEnter()
    {
        readyToType = true;
    }

    private void OnMouseExit()
    {
        readyToType = false;
    }

    private void TypeNextLine()
    {
        //string nextLine = "默认文字";

        string nextLine = currLines[currLineIndex];

        // type next line
        audioSource.clip = decideTypingSFX;
        audioSource.Play();
        ChangeText(nextLine);


        // loop through the current available lines
        if (currLineIndex < currLines.Length - 1)
        {
            changingNextLine = true;
            currLineIndex++;

        }
        else
        {
            // currLineIndex = 0;

            // just try this for now, once each word is seen proceed to next
            manager.NextLineUnit();
        }
    }

    private void ChangeText(string newText)
    {
        t.text = newText;
    }

    private void AttemptTyping()
    {
        if (currLines.Length > 0)
        {
            // only reset the animator to attempting animation state at the first time to avoid unneccessary runtime
            if (!attempting)
            {
                attempting = true;
                animator.SetBool("attempting", true);
            }

            if (attemptTime < attemptTimeLimit)
            {
                string randLine = manager.GenerateRandomString(currLines[currLineIndex].Length);
                audioSource.clip = attemptTypingSFX;
                audioSource.Play();
                ChangeText(randLine);
                attemptTime++;
            }
            else
            { //already reach the point to generate a right line
                attempting = false;
                attemptTime = 0; // reset attempting time
                animator.SetBool("attempting", false); // reset animator
                TypeNextLine();
            }
        }
    }
    public void SetCurrLines(string[] lines)
    {
        currLineIndex = 0;
        currLines = lines;
    }

    public void SetAttemptLimit(int newLimit)
    {
        if (newLimit >= 0)
        {
            attemptTimeLimit = newLimit;
        }
    }

    public void SetTextChangeInterval(float newInterval)
    {
        if (newInterval >= 0)
        {
            textChangeInterval = newInterval;
        }
    }

}
