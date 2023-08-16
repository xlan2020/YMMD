using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip 日常;
    [SerializeField] private AudioClip 黄昏;
    [SerializeField] private AudioClip 戏谑;
    [SerializeField] private AudioClip 紧张;
    [SerializeField] private AudioClip 悬疑;
    [SerializeField] private AudioClip 柴柴;
    [SerializeField] private AudioClip 房间;

    public AudioMixer bgmMixer;
    public AudioSource bgm1;
    public AudioSource bgm2;
    public string StartingBgm;
    private float targetVolume = 1f;

    bool isOn1 = true;

    void Start()
    {
        if (StartingBgm != "")
        {
            ChangeBGM(StartingBgm, 0.04f);
        }
    }

    public void ChangeBGM(string musicName, float fadeDuration)
    {
        if (musicName == "pause" || musicName == "暂停")
        {
            Pause();
            return;
        }
        if (musicName == "play" || musicName == "继续" || musicName == "播放" || musicName == "continue")
        {
            Play();
            return;
        }

        if (GetClipByName(musicName) == null)
        {
            UnityEngine.Debug.LogWarning("try to change music, but BGM name '" + musicName + "' doesn't exist! ");
            return;
        }

        // start changing
        if (isOn1)
        { // fade out 1, make it on 2
            isOn1 = false;
            bgm2.clip = GetClipByName(musicName);
            StartCoroutine(FadeMixerGroup.StartFade(bgmMixer, "vol_bgm1", fadeDuration, 0f));
            StartCoroutine(FadeMixerGroup.StartFade(bgmMixer, "vol_bgm2", fadeDuration, targetVolume));
            bgm2.Play();
        }
        else
        { // fade out 2, make it on 1
            isOn1 = true;
            bgm1.clip = GetClipByName(musicName);
            StartCoroutine(FadeMixerGroup.StartFade(bgmMixer, "vol_bgm2", fadeDuration, 0f));
            StartCoroutine(FadeMixerGroup.StartFade(bgmMixer, "vol_bgm1", fadeDuration, targetVolume));
            bgm1.Play();
        }

    }

    public void Pause()
    {
        bgm1.Pause();
        bgm2.Pause();
    }

    public void Play()
    {
        bgm1.Play();
        bgm2.Play();
    }

    public void SetVolume(float volume)
    {
        targetVolume = Mathf.Clamp(volume, 0, 1);
    }

    private AudioClip GetClipByName(string musicName)
    {
        switch (musicName)
        {
            case "日常":
                return 日常;

            case "黄昏":
                return 黄昏;

            case "戏谑":
                return 戏谑;

            case "紧张":
                return 紧张;

            case "悬疑":
                return 悬疑;

            case "柴柴":
                return 柴柴;

            case "房间":
                return 房间;

            default:
                return null;
        }
    }
}
