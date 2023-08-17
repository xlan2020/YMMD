using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
public static class FadeMixerGroup
{
    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0f;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10f, currentVol / 20f);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1f);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20f);
            yield return null;
        }
        yield break;
    }
}