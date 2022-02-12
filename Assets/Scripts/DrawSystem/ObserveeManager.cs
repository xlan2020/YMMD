using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObserveeManager : MonoBehaviour
{
    public Observee[] observees;
    public Text descriptionText;
    public GameObject descriptionBox;
    private List<Observee> currLeft;
    private List<Observee> currCollected;

    private Animator descriptionAnimator;
    public MouseCursor cursor;

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

    // Update is called once per frame
    void Update()
    {

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

    public void DissolveCollected()
    {
        DissolveEffect dissolveEffect = GetComponent<DissolveEffect>();
        dissolveEffect.StartDissolve(2f);
        List<GameObject> objects = new List<GameObject>();
        foreach (Observee o in currCollected)
        {
            objects.Add(o.gameObject);
            o.SetCanGrab(false);
        }
        dissolveEffect.SetDestroyObjects(objects);
        currCollected.Clear();
    }


    public void MarkAsCollected(Observee o)
    {
        o.SetIsCollected(true);
        currCollected.Add(o);

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
}
