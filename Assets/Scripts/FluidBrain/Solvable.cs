using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solvable : MonoBehaviour
{

    private bool _inLeft;
    public bool interactive = false;
    private Animator animator;
    private Vector3 mOffset;
    private bool isDone = false;
    [SerializeField] private Solvable nextSolvable;
    public SolvableManager manager;
    private Collider2D collider;
    private DragDrop dragDrop;
    private AudioSource source;
    private bool _isPlayingSound = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        dragDrop = GetComponent<DragDrop>();
        source = GetComponent<AudioSource>();
        collider.enabled = false;
        dragDrop.enabled = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            if (!_isPlayingSound && dragDrop.IsOnDrag())
            {
                source.Play();
                _isPlayingSound = true;
                UnityEngine.Debug.Log("Play solvable audio!");
            }
            if (_isPlayingSound && dragDrop.IsOnDrop())
            {
                source.Stop();
                _isPlayingSound = false;
                UnityEngine.Debug.Log("Stop solvable audio!");
            }
        }
    }

    private void SendRight()
    {
        _inLeft = false;
        animator.SetBool("inLeft", false);
    }

    public void SendLeft()
    {
        _inLeft = true;
        animator.SetBool("inLeft", true);
    }

    public bool InLeft()
    {
        return _inLeft;
    }

    public bool Interactive()
    {
        return interactive;
    }

    public void SetInteractive(bool b)
    {
        collider.enabled = b;
        dragDrop.enabled = b;
        interactive = b;
    }

    public void DoneSolving()
    {
        isDone = true;
        gameObject.SetActive(false);
    }

    public Solvable GetNext()
    {
        return nextSolvable;
    }

    public bool IsDone()
    {
        return isDone;
    }

    public bool HasNext()
    {
        if (nextSolvable == null)
        {
            return false;
        }
        return true;
    }

}
