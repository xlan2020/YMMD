using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObserveeManager : MonoBehaviour
{
    public InkDialogueManager dialogueManager;
    public Observee[] observees;
    public Text descriptionText;
    public GameObject descriptionBox;
    public SubmitDrawing submitter;
    private List<Observee> currLeft;
    private List<Observee> currCollected;

    private Animator descriptionAnimator;
    public MouseCursor cursor;
    [Header("Observee Speak Text")]
    public Animator speakTextAnimator;
    public Text speakTextBox;

    private Dictionary<string, Observee> observeeDict;

    // Start is called before the first frame update
    void Awake()
    {
        currLeft = new List<Observee>();
        currCollected = new List<Observee>();

        observeeDict = new Dictionary<string, Observee>();
        foreach (Observee o in observees)
        {
            observeeDict.Add(o.tagName, o);
            //Debug.Log("Observee add: " + o.tagName);
        }

        descriptionAnimator = descriptionBox.GetComponent<Animator>();
    }


    public void SetDescription(string description)
    {
        if (description == descriptionText.text)
        {
            return;
        }
        int rand = 0;
        do
        {
            rand = UnityEngine.Random.Range(0, 3);
            UnityEngine.Debug.Log("The current page generated is: " + rand);
        } while (rand == descriptionAnimator.GetInteger("Page"));

        descriptionAnimator.SetInteger("Page", rand);

        AudioSource source = descriptionBox.GetComponent<AudioSource>();
        source.Play();
        descriptionText.text = description;
    }


    public Observee GetObservee(string name)
    {
        return observeeDict[name];
    }

    public void ShowObservee(string name)
    {
        observeeDict[name].show();
        observeeDict[name].SetHasAppeared(true);
    }

    /**
    When it's ready to submit drawing, this adds the Drag/Drop callbacks to observee in order to display speak text. 
    */
    public void UpdateCollectedObserveeWhenCanSubmit()
    {
        foreach (Observee o in currCollected)
        {
            string submitSpeak = "";
            switch (GameEssential.localeId)
            {
                case 0:
                    submitSpeak = o.submitSpeak;
                    break;
                case 1:
                    submitSpeak = o.submitSpeak_EN;
                    break;
                default:
                    submitSpeak = o.submitSpeak;
                    break;
            }
            // add show text to drag callback
            o.GetComponent<DragDrop>().dragCallback += delegate { ShowObserveeSpeakText(submitSpeak); };

            // add hide text to drop callback
            o.GetComponent<DragDrop>().dropCallback += delegate { HideObserveeSpeakText(); };
        }
    }

    public void ShowObserveeSpeakText(string text)
    {
        speakTextBox.text = text;
        speakTextAnimator.SetBool("show", true);
    }

    public void HideObserveeSpeakText()
    {
        speakTextAnimator.SetBool("show", false);
    }

    public void DissolveCollected()
    {
        UnityEngine.Debug.Log("dissolve collected observee");
        List<GameObject> dissolveObjects = new List<GameObject>();
        List<GameObject> directDestroyObjects = new List<GameObject>();
        foreach (Observee o in currCollected)
        {
            if (o.canDissolve)
            {
                dissolveObjects.Add(o.gameObject);
            }
            else
            {
                directDestroyObjects.Add(o.gameObject);
            }
            o.SetCanGrab(false);
        }
        // clear list for manager to know
        currCollected.Clear();

        // handle cases that can't be dissolved
        foreach (GameObject o in directDestroyObjects)
        {
            GameObject.Destroy(o);
        }

        // dissolve if you can
        if (dissolveObjects.Count > 0)
        {
            DissolveEffect dissolveEffect = GetComponent<DissolveEffect>();
            dissolveEffect.StartDissolve(2f);
            dissolveEffect.SetDestroyObjects(dissolveObjects);
        }
    }


    public void MarkAsCollected(Observee o)
    {
        o.SetIsCollected(true);
        currCollected.Add(o);
        if (CheckFinishCollecting() == true)
        {
            dialogueManager.SetCanContinueToNextLine(true);
            dialogueManager.ContinueStory();
        }
    }

    public void ClearUncollected()
    {
        foreach (Observee o in currLeft)
        {
            if (o.IsCollected() == false)
            {
                o.gameObject.SetActive(false);
            }
        }
        currLeft.Clear();
    }

    public void AddToCurrLeft(string name)
    {
        Debug.Log("Adding " + name + " to Current Left");
        currLeft.Add(observeeDict[name]);
    }

    public void DisplayCurrObservees()
    {
        if (currLeft.Count > 0)
        {
            foreach (Observee o in currLeft)
            {
                Debug.Log("Displaying current observee" + o.tagName);
                this.ShowObservee(o.tagName);
            }
        }
    }

    public bool CheckFinishCollecting()
    {
        foreach (Observee o in currLeft)
        {
            if (o.IsCollected() == false && o.CanSkip() == false)
            {
                return false;
            }
        }
        return true;
    }

    public void SetCursorTrigger(string triggerType)
    {
        cursor.SetAnimationTrigger(triggerType);
    }

    public void SetCursorBool(string name, bool b)
    {
        cursor.SetAnimationBool(name, b);
    }

    // update the order of observee when can submit
    public void SetCollectedCanSubmit()
    {
        foreach (Observee o in currCollected)
        {
            o.SetCanSubmit(true);
            o.SetSortingLayer(SortingLayer.NameToID("drawSubmitterActive"), 6);
        }
    }
}
