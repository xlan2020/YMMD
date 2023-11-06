using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
The content in the receiver will not be hidden anymore if a solvable enters. 
*/
public class SolvableReceiver : MonoBehaviour
{
    public Solvable TargetSolvable;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource source;
    public GameObject[] AdditionalReceivers;
    public SolvableReceiver[] ClearSound;
    public GameObject[] ClearImage;
    public GameObject[] ClearObjects;
    public UnityEvent events;
    public SolvableReceiver[] NextReceivers;

    public bool ImmediateTrigger = false;

    private bool _hidden = true;
    private Collider2D collider;
    public bool DisableColliderAfterUse = true;
    public bool HasSecondCollider = false;


    void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (collider != null)
        {
            collider.enabled = false;
        }

        if (animator == null)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
        else
        {
            animator.SetBool("hidden", true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == TargetSolvable.gameObject)
        {
            other.gameObject.GetComponent<Solvable>().SetAtDestination(true);
            if (other.GetComponent<DragDrop>().IsOnDrop() || ImmediateTrigger)
            {
                TargetSolvable.DoneSolving();
                ReceiveSolve();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == TargetSolvable.gameObject)
        {
            if (other.GetComponent<DragDrop>().IsOnDrop() || ImmediateTrigger)
            {
                TargetSolvable.DoneSolving();
                ReceiveSolve();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == TargetSolvable.gameObject)
        {
            other.gameObject.GetComponent<Solvable>().SetAtDestination(false);
        }

    }

    public void ReceiveSolve()
    {
        // UnityEngine.Debug.Log("Receive Solve");
        ClearOtherSound();
        ClearOtherImages();
        ClearOtherObjects();
        events.Invoke();

        Show();
        ShowAdditionalReceivers();

        EnableNextReceiver();

        if (collider != null && HasSecondCollider && animator != null)
        {
            animator.SetTrigger("secondCollider");
        }
        if (DisableColliderAfterUse && collider != null)
        {
            collider.enabled = false;
        }
        this.enabled = false;
    }
    private void ShowAdditionalReceivers()
    {
        foreach (GameObject o in AdditionalReceivers)
        {
            o.SetActive(true);
            Animator a = o.GetComponent<Animator>();
            SpriteRenderer s = o.GetComponent<SpriteRenderer>();
            if (a != null)
            {
                a.SetBool("hidden", false);
            }
            else if (s != null)
            {
                s.enabled = true;
            }
        }
    }

    private void Show()
    {
        // visually show
        if (animator != null)
        {
            animator.SetBool("hidden", false);
        }
        else if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        // play audio
        if (source != null)
        {
            source.Play();
        }

    }
    public void ChangeLowerSound(bool b)
    {
        animator.SetBool("lowSound", b);
        UnityEngine.Debug.Log("lowering sound" + b);
    }

    public void ClearOtherSound()
    {
        if (ClearSound != null)
        {
            foreach (SolvableReceiver s in ClearSound)
            {
                if (s!=null){
                    s.GetComponent<AudioSource>().Stop();
                }
            }
        }
    }

    public void ClearOtherImages()
    {
        if (ClearImage != null)
        {
            foreach (GameObject g in ClearImage)
            {
                SpriteRenderer gRenderer = g.GetComponent<SpriteRenderer>();
                if (gRenderer != null)
                {
                    gRenderer.enabled = false;
                }
                Animator gAnimator = g.GetComponent<Animator>();
                if (gAnimator != null)
                {
                    gAnimator.SetBool("hidden", true);
                }
            }
        }
    }

    public void ClearOtherObjects()
    {
        if (ClearImage != null)
        {
            foreach (GameObject g in ClearObjects)
            {
                g.SetActive(false);
            }
        }
    }

    public void EnableNextReceiver()
    {
        UnityEngine.Debug.Log("try to enable next receiver");
        if (NextReceivers == null)
        {
            UnityEngine.Debug.Log("doesn't have next receiver.");
            return;
        }
        foreach (SolvableReceiver r in NextReceivers)
        {
            Collider2D collider = r.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
    }

}
