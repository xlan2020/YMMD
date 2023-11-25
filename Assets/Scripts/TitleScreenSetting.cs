using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TitleScreenSetting : MonoBehaviour
{
    public AudioMixer bgmMixer;

    void Start()
    {
        bgmMixer.SetFloat("MasterVolume", 0f);
    }
}
