using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawResultManager : MonoBehaviour
{
    public Sprite[] FinalDrawings;
    private int _resultIndex = -1;
    private Animator animator;
    private bool _canShow = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        DisplayDrawing();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDrawingResultIndex(int i)
    {
        _resultIndex = i;
    }

    public int GetDrawingResultIndex()
    {
        return _resultIndex;
    }

    public void DisplayDrawing()
    {
        animator.SetInteger("Index", _resultIndex);
    }

    public void SetCanShow(bool b)
    {
        _canShow = b;
    }

    public bool CanShow()
    {
        return _canShow;
    }
}
