using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent ClickEvents;
    public MouseCursor cursor;
    private bool stay = false;
    void Update()
    {
        if (stay && Input.GetKeyUp(KeyCode.Mouse0))
        {
            ClickEvents.Invoke();
        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        cursor.SetAnimationTrigger("point");
        stay = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursor.SetAnimationDefault();
        stay = false;
    }
}
