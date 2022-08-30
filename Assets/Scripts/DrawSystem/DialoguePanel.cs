using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialoguePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MouseCursor cursor;
    private bool interactive = true;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (interactive)
        {
            cursor.GetComponent<Animator>().SetTrigger("dialogue");
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (interactive)
        {
            cursor.SetAnimationDefault();
        }
    }

    public void SetInteractive(bool b)
    {
        interactive = b;
    }


}
