using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ThreeChannelText : MonoBehaviour
{
    private bool readyToType = false;
    private Text t;

    private string[] currLines;
    private int currLineIndex = 0;
    public bool doneLines = false;
    private bool holdingDown = false;
    public ThreeChannelManager manager;
    public ThreeChannelManagerEN managerEN;
    public Animator screenAnimator;

    public int attemptTimeLimit = 10;
    private int attemptTime = 0;

    private Animator animator;
    private bool attempting = false;
    private bool changingNextLine = false;

    public float textChangeInterval = 0.2f;
    private float textChangeTimer = 0f;
    private float AcceleratingInterval = 0f;
    public float textConfirmTimeLimit = 0.8f;
    private float textConfirmTimer = 0f;

    public AudioClip attemptTypingSFX;
    public AudioClip decideTypingSFX;
    private AudioSource audioSource;

    // POST EFFECT Volume
    private bool changingPostFX = false;
    private Volume postFXVolume;
    private float targetVolumeWeight;
    private float volumeWeightIncrement;

    void Awake()
    {
        t = GetComponent<Text>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (readyToType)
        {
            textChangeTimer += Time.deltaTime;
            // check key input
            if (Input.anyKey)
            {
                // Debug.Log("A key is being pressed");
                holdingDown = true;

                if (textChangeTimer > textChangeInterval)
                {
                    textChangeTimer = 0; //reset timer

                    if (!changingNextLine)
                    { // can't keep attempting if one line is just decided
                        AttemptTyping();
                    }

                    screenAnimator.SetBool("typing", true);

                    // handle accelerating attempting time
                    UpdateTextChangeInterval();
                }
            }
            else if (holdingDown)
            {
                // Debug.Log("A key was released");
                holdingDown = false;

                if (!changingNextLine)
                { // can't keep attempting if one line is just decided
                    AttemptTyping();
                }
                screenAnimator.SetBool("typing", true);

                // handle accelerating attempting time
                UpdateTextChangeInterval();
                textChangeTimer = 0; //reset timer

            }
            else
            {
                screenAnimator.SetBool("typing", false);
            }

        }

        if (changingNextLine)
        {
            textConfirmTimer += Time.deltaTime;
            if (textConfirmTimer > textConfirmTimeLimit)
            {
                changingNextLine = false;
                textConfirmTimer = 0;
            }
        }
    }

    private float UpdateTextChangeInterval()
    {
        textChangeInterval += AcceleratingInterval;
        if (textChangeInterval < 0)
        {
            UnityEngine.Debug.LogWarning("incorrect accelerating input: the text change interval can't be negative!");
        }
        return textChangeInterval;

    }
    private void OnMouseOver()
    {
        readyToType = true;
        screenAnimator.SetBool("pointerOver", true);
    }

    private void OnMouseExit()
    {
        readyToType = false;
        screenAnimator.SetBool("pointerOver", false);
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

            // mark its lines to be done and check if everyline is done.
            // if so, the manager will proceed to next line unit. 
            doneLines = true;
            if (manager != null)
            {
                manager.CheckDoneLineUnit();
            }
            else if (managerEN != null)
            {
                managerEN.CheckDoneLineUnit();
            }


            screenAnimator.SetBool("isNext", false);
        }
    }

    public void ChangeText(string newText)
    {
        t.text = newText;
    }


    public void ClearText()
    {
        ChangeText("-");
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
                if (changingPostFX)
                {
                    volumeWeightIncrement = (targetVolumeWeight - postFXVolume.weight) / attemptTimeLimit;
                }
            }

            if (attemptTime < attemptTimeLimit)
            {
                string randLine = "";
                if (manager != null)
                {
                    randLine = manager.GenerateRandomString(currLines[currLineIndex].Length);
                }
                else if (managerEN != null)
                {
                    randLine = managerEN.GenerateRandomString(currLines[currLineIndex].Length);
                }
                audioSource.clip = attemptTypingSFX;
                audioSource.Play();
                ChangeText(randLine);
                attemptTime++;

                if (changingPostFX)
                {
                    postFXVolume.weight += volumeWeightIncrement;
                }
            }
            else
            { //already reach the point to generate a right line
                attempting = false;
                attemptTime = 0; // reset attempting time
                animator.SetBool("attempting", false); // reset animator

                if (changingPostFX)
                {
                    // end changing post FX volume
                    changingPostFX = false;
                    postFXVolume.weight = targetVolumeWeight;
                }

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

    public void SetAcceleratingInterval(float newAcceleration)
    {
        AcceleratingInterval = newAcceleration;
    }

    public void MatchVolumeWeightToCurrentTyping(float targetWeight)
    {
        changingPostFX = true;
        targetVolumeWeight = targetWeight;
    }

    public void SetPostFXVolume(Volume volume)
    {
        postFXVolume = volume;
    }

    public void SetInteractive(bool b)
    {
        GetComponent<Collider2D>().enabled = b;
        if (b == false)
        {
            readyToType = false;
        }
        // otherwise, not necessarily true
    }
}
