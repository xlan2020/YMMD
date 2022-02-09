using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public MouseCursor cursor;
    private Button menuButton;
    private AudioSource audio;
    public AudioClip OpenAudio;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
        cursor.SetAnimationTrigger("point");
    }

    void OnMouseExit()
    {
        cursor.SetAnimationTrigger("default");
    }

    void OnMouseUp()
    {
        audio.clip = OpenAudio;
        audio.Play();
    }
}
