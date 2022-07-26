using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoice : MonoBehaviour
{
    private AudioSource source;
    public AudioClip 默认;

    public AudioClip 画家;
    public AudioClip 巴简二;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = true;

    }
    void Update()
    {

    }
    public void StartTalking(string name)
    {
        switch (name)
        {
            case "8-2":
                source.clip = 巴简二;
                break;
            case "我":
                source.clip = 画家;
                break;
            default:
                source.clip = 默认;
                break;
        }
        source.Play();
    }

    public void StopTalking()
    {
        source.Stop();
    }
}