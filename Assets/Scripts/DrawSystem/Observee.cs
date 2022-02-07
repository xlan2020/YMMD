using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Observee : MonoBehaviour
{
    public ObserveeManager manager;
    public string tagName;
    public int choiceIndex;
    public bool canSkip = false;
    public string description;
    private bool isCollected = false;
    private bool canMove = true;
    private bool hasAppeared = false;

    private Animator animator;

    void Awake()
    {
        gameObject.AddComponent<DragDrop>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void appearOnWorkStation()
    {

    }

    public bool CheckIsCollected()
    {
        return isCollected;
    }

    public void SetIsCollected(bool b)
    {
        isCollected = b;
    }

    public void SendRight()
    {
        animator.SetTrigger("sendRight");
    }

    public bool HasAppeared()
    {
        return hasAppeared;
    }

    public void SetHasAppeared(bool b)
    {
        hasAppeared = b;
    }

    public bool CanSkip()
    {
        return canSkip;
    }

    public void SetCanSkip(bool b)
    {
        canSkip = b;
    }

    private void OnMouseEnter()
    {
        if (!isCollected)
        {
            manager.SetCursorTrigger("observe");
        }
        else
        {
            manager.SetCursorTrigger("hand");
        }
    }
    private void OnMouseDown()
    {
        manager.SetCursorBool("grab", true);
    }

    private void OnMouseUp()
    {
        manager.SetCursorBool("grab", false);
        manager.SetDescription(description);
    }

    private void OnMouseExit()
    {
        manager.SetCursorTrigger("default");
    }

    public void ClearSelf()
    {
        gameObject.SetActive(false);
    }

}
