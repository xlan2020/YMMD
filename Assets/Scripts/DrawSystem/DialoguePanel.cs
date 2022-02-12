using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanel : MonoBehaviour
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

    void OnMouseEnter()
    {
        cursor.GetComponent<Animator>().SetTrigger("dialogue");
    }

    void OnMouseExit()
    {
        cursor.SetAnimationDefault();
    }


}
