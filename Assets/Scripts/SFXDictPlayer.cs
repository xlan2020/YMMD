using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDictPlayer : MonoBehaviour
{
    [Header("Corresponding Name and Audio")]
    [Tooltip("names and audios at the same index must be corresponding!")]
    public string[] names;
    public AudioClip[] audios;
    public Dictionary<string, AudioClip> dict = new Dictionary<string, AudioClip>();
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (names.Length != audios.Length)
        {
            UnityEngine.Debug.LogWarning("Number of Names and Audios in SFX Dict doesn't match, please reload Names and Audio array!");
            return;
        }
        for (int i = 0; i < names.Length; i++)
        {
            dict.Add(names[i], audios[i]);
        }
    }

    void StopPlaying()
    {
        source.Stop();
    }

    void SetLoop(bool b)
    {
        source.loop = b;
    }
    void PlaySFXOnce(string name)
    {
        if (!dict.ContainsKey(name))
        {
            UnityEngine.Debug.LogWarning("SFX name doesn't exist!");
            return;
        }
        source.loop = false;
        source.clip = dict[name];
        source.Play();
    }
    void PlaySFXLoop(string name)
    {
        if (!dict.ContainsKey(name))
        {
            UnityEngine.Debug.LogWarning("SFX name doesn't exist!");
            return;
        }
        source.loop = true;
        source.clip = dict[name];
        source.Play();
    }

}
