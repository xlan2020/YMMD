using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public string changeTo = "point";
    public string backTo = "default";
    public void OnPointerEnter(PointerEventData pointerEventData)
    {

        MouseCursor.instance.SetAnimationTrigger(changeTo);

    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        MouseCursor.instance.SetAnimationTrigger(backTo);
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MouseCursor.instance.SetAnimationTrigger("changeTo");
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        MouseCursor.instance.SetAnimationTrigger(backTo);
    }

}
