using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneEventManager : MonoBehaviour
{
    public Dictionary<string, SceneEvent> eventsDict;

    void Awake()
    {
        eventsDict = new Dictionary<string, SceneEvent>();
        foreach (Transform child in transform)
        {
            eventsDict.Add(child.gameObject.GetComponent<SceneEvent>().name, child.gameObject.GetComponent<SceneEvent>());
        }
    }


    public void TriggerEvent(string eventName)
    {
        if (eventsDict[eventName] == null)
        {
            UnityEngine.Debug.LogWarning("can't trigger event because event name: " + eventName + "doesn't exist!");
            return;
        }

        eventsDict[eventName].TriggerEvent();
    }

}
