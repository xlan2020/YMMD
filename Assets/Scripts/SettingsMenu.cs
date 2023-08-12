using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance { get; private set; }
    public MapPlayer mapPlayer;
    [Header("Audio Setting")]
    // public AudioMixer audioMixer;
    public AudioMixer BgmMixer;
    public AudioMixer SfxMixer;

    [Header("Button & GameObjects")]
    public Button MenuButton;
    public Button MenuBackButton;
    public Button SettingPanelButton;
    public Button ControlPanelButton;
    public GameObject SettingMenuObject;
    public MouseCursor cursor;
    public GameObject ControlPanel;
    public GameObject SettingPanel;
    public GameObject FirstSelectedButton;

    [Header("Button Audio SFX")]
    public AudioClip OpenAudio;

    private bool _isOpen = false;
    // Change volume of mixer

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
                MenuBackButton.onClick.Invoke();
            }
            else
            {
                MenuButton.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SettingPanelButton.Select();
            SettingPanelButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ControlPanelButton.Select();
            ControlPanelButton.onClick.Invoke();
        }

        if (!EventSystem.current.alreadySelecting)
        {
            // EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
        }


    }
    /**
public void SetVolume(float volume)
{
        audioMixer.SetFloat("volume", volume);
}
*/

    public bool IsOpen()
    {
        return _isOpen;
    }
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

        EventSystem.current.SetSelectedGameObject(FirstSelectedButton);

        if (mapPlayer)
        {
            mapPlayer.UpdateCanMove();
        }



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


        EventSystem.current.SetSelectedGameObject(null);

        if (mapPlayer)
        {
            mapPlayer.UpdateCanMove();
        }


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
