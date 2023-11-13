using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignDrawingDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SignBrush signBrush;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        signBrush.canSign = true;


    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        signBrush.canSign = false;
    }
}
