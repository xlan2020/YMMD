using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MouseCursor cursor;
    public SettingsMenu settingsMenu;
    private Button menuButton;
    private AudioSource audio;
    private AudioClip OpenAudio;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        audio = GetComponent<AudioSource>();
        OpenAudio = settingsMenu.GetOpenAudio();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audio.clip = OpenAudio;
        audio.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.SetAnimationTrigger("point");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.SetAnimationDefault();
    }
}
