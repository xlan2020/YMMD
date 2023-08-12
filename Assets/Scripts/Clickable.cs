using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent ClickEvents;
    private MouseCursor cursor;
    public string animationType = "point";
    private bool stay = false;

    void Start()
    {
        cursor = MouseCursor.instance;
    }
    void Update()
    {
        if (stay)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ClickEvents.Invoke();
                if (animationType == "hand")
                {
                    cursor.SetAnimationBool("grab", false);
                }
            }
            if (animationType == "hand" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                cursor.SetAnimationBool("grab", true);
            }

        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        cursor.SetAnimationTrigger(animationType);
        stay = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursor.SetAnimationDefault();
        stay = false;
    }
}
