using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public SolvableReceiver[] NextReceivers;

    public bool ImmediateTrigger = false;

    private bool _hidden = true;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        animator = gameObject.GetComponent<Animator>();
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
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == TargetSolvable.gameObject)
        {
            if (other.GetComponent<DragDrop>().IsOnDrop() || ImmediateTrigger)
            {
                show();
                TargetSolvable.DoneSolving();
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    public void show()
    {
        ClearOtherSound();
        ClearOtherImages();

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

        EnableNextReceiver();

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
                s.GetComponent<AudioSource>().Stop();
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
            }
        }
    }

    public void EnableNextReceiver()
    {
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
