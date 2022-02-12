using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Solvable : MonoBehaviour
{

    private bool _inLeft;
    public bool interactive = false;
    private Animator animator;
    private Vector3 mOffset;
    private bool isDone = false;
    // [SerializeField] private Solvable nextSolvable;
    [SerializeField] private SolvableReceiver[] lowerSounds;
    public bool LowerSound = false;
    public SolvableManager manager;
    private Collider2D collider;
    private DragDrop dragDrop;
    private AudioSource source;
    private SpriteRenderer renderer;
    private bool _isPlayingSound = false;
    private MouseCursor cursor;

    [Header("Click Type Solvable")]
    public bool ClickType = false;
    [SerializeField] private SolvableReceiver TargetClickReceiver;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
        dragDrop = GetComponent<DragDrop>();
        renderer = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        if (dragDrop != null)
        {
            dragDrop.enabled = false;
        }
    }
    void Start()
    {
        cursor = manager.GetCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            if (!_isPlayingSound && !ClickType && dragDrop.IsOnDrag())
            {
                if (source.clip != null)
                {
                    source.Play();
                    _isPlayingSound = true;
                }
                ChangeLowerPreviousSound(true);
                UnityEngine.Debug.Log("Play solvable audio!");
            }
            if (_isPlayingSound && !ClickType && dragDrop.IsOnDrop())
            {
                source.Stop();
                _isPlayingSound = false;
                ChangeLowerPreviousSound(false);
                UnityEngine.Debug.Log("Stop solvable audio!");
            }
        }
    }

    public void Show()
    {
        if (animator != null)
        {
            animator.SetBool("hidden", false);
        }
        else if (renderer != null)
        {
            renderer.enabled = true;
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
        if (dragDrop != null)
        {
            dragDrop.enabled = b;
        }
        interactive = b;

    }

    public void DoneSolving()
    {
        isDone = true;
        gameObject.SetActive(false);
    }

    /**
        public Solvable GetNext()
        {
            return nextSolvable;
        }
        */

    public bool IsDone()
    {
        return isDone;
    }
    /**
        public bool HasNext()
        {
            if (nextSolvable == null)
            {
                return false;
            }
            return true;
        }
        */

    private void ChangeLowerPreviousSound(bool b)
    {
        if (lowerSounds != null && LowerSound)
        {
            foreach (SolvableReceiver r in lowerSounds)
            {
                r.ChangeLowerSound(b);
            }
        }
    }

    private void SolveSelf()
    {
        TargetClickReceiver.show();
        TargetClickReceiver.ClearOtherSound();
        DoneSolving();
    }
    private void OnMouseEnter()
    {
        if (ClickType)
        {
            cursor.SetAnimationTrigger("point");
        }
        else
        {
            cursor.SetAnimationTrigger("hand");
        }
    }

    private void OnMouseDown()
    {
        cursor.SetAnimationBool("grab", true);
    }

    private void OnMouseUp()
    {
        cursor.SetAnimationBool("grab", false);

        UnityEngine.Debug.Log("Click on solvable");
        if (ClickType)
        {
            SolveSelf();
        }
    }

    private void OnMouseExit()
    {
        cursor.SetAnimationDefault();
    }

}
