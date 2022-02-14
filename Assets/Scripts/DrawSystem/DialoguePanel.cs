using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialoguePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MouseCursor cursor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        cursor.GetComponent<Animator>().SetTrigger("dialogue");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursor.SetAnimationDefault();
    }


}
