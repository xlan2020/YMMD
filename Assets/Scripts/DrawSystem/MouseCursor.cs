using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    void FixedUpdate()
    {
        // Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = cursorPos;
    }

    public void SetAnimationTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void SetAnimationBool(string boolName, bool b)
    {
        animator.SetBool(boolName, b);
    }

}
