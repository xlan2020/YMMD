using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBook : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;
    public MouseCursor cursor;
    public AudioClip OpenBookAudio;
    public AudioClip CloseBookAudio;
    public AudioClip[] FlipPageAudios;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        animator.SetBool("MouseOn", true);
        cursor.SetAnimationTrigger("hand");
    }


    private void OnMouseDown()
    {
        cursor.SetAnimationBool("grab", true);
    }


    private void OnMouseUp()
    {
        cursor.SetAnimationBool("grab", false);
        OpenBook();
    }


    private void OnMouseExit()
    {
        animator.SetBool("MouseOn", false);
        cursor.SetAnimationTrigger("default");
    }

    private void OpenBook()
    {
        audio.clip = OpenBookAudio;
        audio.Play();
    }

    private void CloseBook()
    {
        audio.clip = CloseBookAudio;
        audio.Play();
    }

}
