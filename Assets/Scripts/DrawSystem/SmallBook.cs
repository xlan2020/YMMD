using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBook : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        animator.SetBool("MouseOn", true);
        UnityEngine.Debug.Log("mouse on book!");
    }

    private void OnMouseExit()
    {
        animator.SetBool("MouseOn", false);
    }
}
