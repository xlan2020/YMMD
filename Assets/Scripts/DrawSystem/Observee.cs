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

    private Vector3 mOffset;
    private float mZCoord;

    private Text descriptionBox;
    private bool isCollected = false;
    private bool canMove = true;
    private bool hasAppeared = false;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        animator = gameObject.GetComponent<Animator>();
        descriptionBox = manager.GetDescriptionBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CanMove(bool b)
    {
        canMove = b;
    }

    void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up on " + tagName);
        typeDescription(description);
    }

    private void typeDescription(string d)
    {
        d = description;
        descriptionBox.text = d;
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }

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


}
