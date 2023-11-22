using System;
using System.Collections;
using UnityEngine;

public class GlitchController : MonoBehaviour
{

    public AudioClip[] TVGlitchSounds;
    public AudioClip[] ShortGlitchSounds;
    public float GlitchIntervalMin = 1f;
    public float GlitchIntervalMax = 4f;
    public float ShortGlitchRate = 0.5f;
    private float timer;
    private float currInterval;
    private AudioSource source;
    public bool auto = true;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        GenerateRandomGlitchInterval();
    }

    void Update()
    {
        if (auto)
        {
            timer += Time.deltaTime;
            if (timer > currInterval)
            {
                PlayRandomGlitch();
                GenerateRandomGlitchInterval();
                timer = 0;
            }
        }
    }

    public void SetAuto(bool b)
    {
        auto = b;
    }
    public void SetIntervalMin(float newInterval)
    {
        GlitchIntervalMin = newInterval;
        GenerateRandomGlitchInterval();
    }

    public void SetIntervalMax(float newInterval)
    {
        GlitchIntervalMax = newInterval;
        GenerateRandomGlitchInterval();
    }

    public void SetShortGlitchRate(float newRate)
    {
        ShortGlitchRate = newRate;
    }
    /**
    If the passing value is negative, then nothing will be changed. 
    */
    public void SetGlitchAmount(float minInterval, float maxInterval, float shortGlitchRate)
    {
        if (minInterval > 0f)
        {
            GlitchIntervalMin = minInterval;
        }
        if (maxInterval > 0f)
        {
            GlitchIntervalMax = maxInterval;
        }
        if (shortGlitchRate > 0f)
        {
            ShortGlitchRate = shortGlitchRate;
        }
    }

    public void PlayRandomGlitch()
    {
        float dice = UnityEngine.Random.Range(0f, 1f);
        if (dice <= ShortGlitchRate)
        {
            PlayRandomShortGlitch();
        }
        else
        {
            PlayRandomTVGlitch();
        }
    }
    private float GenerateRandomGlitchInterval()
    {
        currInterval = UnityEngine.Random.Range(GlitchIntervalMin, GlitchIntervalMax);
        return currInterval;
    }
    public void PlayRandomTVGlitch()
    {
        source.Pause();
        int rand = UnityEngine.Random.Range(0, TVGlitchSounds.Length - 1);
        source.clip = TVGlitchSounds[rand];
        source.Play();
    }

    public void PlayRandomShortGlitch()
    {

        source.Pause();
        int rand = UnityEngine.Random.Range(0, ShortGlitchSounds.Length - 1);
        source.clip = ShortGlitchSounds[rand];
        source.Play();
    }
}
