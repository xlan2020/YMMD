using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioPlayer : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        source.Play();
    }
}
