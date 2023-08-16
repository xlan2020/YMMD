using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip 日常;
    [SerializeField] private AudioClip 黄昏;
    [SerializeField] private AudioClip 戏谑;
    [SerializeField] private AudioClip 紧张;
    [SerializeField] private AudioClip 悬疑;
    [SerializeField] private AudioClip 柴柴;
    [SerializeField] private AudioClip 房间;

    public string StartingBgm;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Start()
    {
        ChangeBGM(StartingBgm);
    }

    public void ChangeBGM(string musicName)
    {
        switch (musicName)
        {
            case "日常":
                source.clip = 日常;
                break;
            case "黄昏":
                source.clip = 黄昏;
                break;
            case "戏谑":
                source.clip = 戏谑;
                break;
            case "紧张":
                source.clip = 紧张;
                break;
            case "悬疑":
                source.clip = 悬疑;
                break;
            case "柴柴":
                source.clip = 柴柴;
                break;
            case "房间":
                source.clip = 房间;
                break;
            default:
                break;
        }
        if (musicName == "pause" || musicName == "暂停")
        {
            Pause();
        }
        else
        {
            Play();
        }

    }

    public void Pause()
    {
        source.Pause();
    }

    public void Play()
    {
        source.Play();
    }
}
