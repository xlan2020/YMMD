using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio Setting")]
    // public AudioMixer audioMixer;
    public AudioMixer BgmMixer;
    public AudioMixer SfxMixer;

    [Header("Button & GameObjects")]
    public Button MenuButton;
    public Button MenuBackButton;
    public GameObject SettingMenuObject;
    public MouseCursor cursor;
    public GameObject ControlPanel;
    public GameObject SettingPanel;

    [Header("Button Audio SFX")]
    public AudioClip OpenAudio;

    private bool _isOpen = false;
    // Change volume of mixer

    public void Awake()
    {

    }

    private void Start()
    {
        BackToGame();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOpen)
            {
                BackToGame();
            }
            else
            {
                OpenSettingMenu();
            }
        }
    }
    /**
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    */
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void ToggleFullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettingMenu()
    {
        _isOpen = true;
        // enable objects & buttons
        MenuButton.enabled = false;
        MenuButton.gameObject.GetComponent<Image>().enabled = false;
        MenuBackButton.enabled = true;
        MenuBackButton.gameObject.GetComponent<Image>().enabled = true;
        SettingMenuObject.SetActive(true);

        // cursor animation
        cursor.SetInGameMode(false);

        // sound
        BgmMixer.SetFloat("MasterVolume", -20f);

    }

    public void BackToGame()
    {
        _isOpen = false;
        // enable objects & buttons
        MenuBackButton.enabled = false;
        MenuBackButton.gameObject.GetComponent<Image>().enabled = false;
        MenuButton.enabled = true;
        MenuButton.gameObject.GetComponent<Image>().enabled = true;
        SettingMenuObject.SetActive(false);

        // cursor animation
        cursor.SetInGameMode(true);

        //sound
        BgmMixer.SetFloat("MasterVolume", 0f);

    }

    public AudioClip GetOpenAudio()
    {
        return OpenAudio;
    }

    public void SwitchPanel(string panelName)
    {
        switch (panelName)
        {
            case "settings":
                ControlPanel.SetActive(false);
                SettingPanel.SetActive(true);
                break;
            case "controls":
                SettingPanel.SetActive(false);
                ControlPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}
