using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Animator animator;
    private bool _inGameMode = true;
    private bool _inFluidBrain = false;
    public Camera positionReferenceCamera; // has to be a camera that's overlay / doesn't move

    void Awake()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        // animator.SetBool("inGame", true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = positionReferenceCamera.ScreenToWorldPoint(Input.mousePosition);
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

    public bool InGameMode()
    {
        return _inGameMode;
    }

    public void SetInGameMode(bool b)
    {
        _inGameMode = b;
        animator.SetBool("inGame", b);
    }

    public void SetAnimationDefault()
    {
        animator.SetBool("grab", false);
        if (_inGameMode)
        {
            animator.SetTrigger("default");
        }
        else
        {
            animator.SetTrigger("arrow");
        }
        if (_inFluidBrain)
        {
            animator.SetTrigger("observe");
        }
    }

    public void SetInFluidBrain(bool b)
    {
        _inFluidBrain = b;
        animator.SetTrigger("observe");
    }

}
