using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public GameManager gameManager;
    public static SettingsMenu instance { get; private set; }
    public MapPlayer mapPlayer;
    [Header("Audio Setting")]
    // public AudioMixer audioMixer;
    public AudioMixer BgmMixer;
    public AudioMixer SfxMixer;

    [Header("Master Level Buttons")]
    public Button MenuButton;
    public Button MenuBackButton;
    public Button SettingPanelButton;
    public Button ControlPanelButton;
    public GameObject SettingMenuObject;
    public MouseCursor cursor;
    public GameObject ControlPanel;
    public GameObject SettingPanel;
    public GameObject FirstSelectedButton;

    [Header("Setting Button and Controls")]
    public Slider bgmSlider;
    public Slider sfxSlider;

    [Header("Button Audio SFX")]
    public AudioClip OpenAudio;
    private float MAX_MIXER_VOL = 20f;
    private float MIN_MIXER_VOL = -80f;
    private float DEFAULT_BGM_VAL = 0.8f;
    private float DEFAULT_SFX_VAL = 0.8f;

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
        //DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        initializeAudio();

        BackToGame();

    }

    private void initializeAudio()
    {
        bgmSlider.value = DEFAULT_BGM_VAL;
        sfxSlider.value = DEFAULT_SFX_VAL;
        UpdateMixerVolumeFromSlider();
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

    public void QuickSave()
    {
        gameManager.Save();
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
        UpdateMixerVolumeFromSlider();


        EventSystem.current.SetSelectedGameObject(null);

        if (mapPlayer != null)
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

    public void GoToMainMenu()
    {
        gameManager.sceneLoader.LoadScene("0_TitleScreen", autoSave: false);
    }

    public void OpenSaveLoadScreen()
    {

    }

    public void UpdateMixerVolumeFromSlider()
    {
        float bgmVol = mapSliderValToMixerVol(bgmSlider.value);
        float sfxVol = mapSliderValToMixerVol(sfxSlider.value);
        BgmMixer.SetFloat("MasterVolume", bgmVol);
        SfxMixer.SetFloat("MasterVolume", sfxVol);
    }


    private float mapSliderValToMixerVol(float sliderValue)
    {
        return map(sliderValue, 0f, 1f, MIN_MIXER_VOL, MAX_MIXER_VOL);
    }
    private float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
}
