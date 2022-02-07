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
    private Animator descriptionAnimator;
    public MouseCursor cursor;

    private Dictionary<string, Observee> observeeDict;

    // Start is called before the first frame update
    void Start()
    {
        currLeft = new List<Observee>();

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

    public void ClearAll()
    {
        foreach (Observee o in observees)
        {
            o.ClearSelf();
            //Destroy(o.gameObject);
        }
    }

    public void MarkAsCollected(string name)
    {
        Observee o = observeeDict[name];
        o.SendRight();
        o.SetIsCollected(true);

    }
    public void ClearUncollected()
    {
        foreach (Observee o in currLeft)
        {
            if (o.CheckIsCollected() == false)
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
            if (o.CheckIsCollected() == false && o.CanSkip() == false)
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
