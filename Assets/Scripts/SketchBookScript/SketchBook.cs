using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SketchBook : MonoBehaviour
{
    public static SketchBook instance { get; private set; }
    public NotesManager notesManager;
    public SketchBookButton icon;
    public AudioClip OpenBookAudio;
    public AudioClip CloseBookAudio;
    public AudioClip[] FlipPageAudios;
    private AudioSource audio;
    private bool isOpen = false;
    private bool hasNew;
    private int currPage = 0;
    public GameObject assesories;
    public InkDialogueManager dialogueManager;
    public InventoryButton inventoryButton;
    public Text currentPageText;
    public MapPlayer mapPlayer;


    void Awake()
    {
        audio = GetComponent<AudioSource>();

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
    void Start()
    {
        isOpen = false;
        notesManager.gameObject.SetActive(isOpen);
        assesories.SetActive(isOpen);
    }

    public void TurnToPage(int i)
    {
        currPage = i;
        notesManager.TurnToPage(currPage);
        currentPageText.text = currPage + " / 10";  // let's assume we have 10 page maximum! 
    }

    public int CurrentPage()
    {
        return currPage;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
    public void ToggleOpen()
    {
        if (isOpen)
        {
            isOpen = false;
            CloseBook();
            inventoryButton.canOpen = true;
        }
        else
        {
            isOpen = true;
            OpenBook();
            inventoryButton.canOpen = false;
        }

        if (mapPlayer)
        {
            // UnityEngine.Debug.Log("book is toggled, update can move");
            mapPlayer.UpdateCanMove();
        }

    }
    private void OpenBook()
    {
        audio.clip = OpenBookAudio;
        audio.Play();
        if (hasNew)
        {
            ChangeUINew(false);
        }

        notesManager.gameObject.SetActive(true);
        assesories.SetActive(true);
        if (dialogueManager != null)
        {
            dialogueManager.FreezeDialogue();
        }

        TurnToPage(currPage);
        UnityEngine.Debug.Log("Current page is: " + currPage);
    }

    public void CloseBook()
    {
        audio.clip = CloseBookAudio;
        audio.Play();

        notesManager.gameObject.SetActive(false);

        assesories.SetActive(false);
        if (dialogueManager != null)
        {
            dialogueManager.UnfreezeDialogue();
        }
    }

    public void FlipLeft()
    {
        if (currPage > 0)
        {
            currPage--;
            TurnToPage(currPage);
            PlayFlipPageAudio();
        }
    }

    public void FlipRight()
    {
        if (currPage < notesManager.MaxPage())
        {
            currPage++;
            TurnToPage(currPage);
            PlayFlipPageAudio();
        }
    }

    private void PlayFlipPageAudio()
    {
        int i = UnityEngine.Random.Range(0, FlipPageAudios.Length - 1);
        audio.clip = FlipPageAudios[i];
        audio.Play();
    }
    public void UnlockNewNote(string name)
    {
        // if the note is already unlocked, then does nothing and return;
        if (notesManager.NoteIsUnlocked(name))
        {
            //UnityEngine.Debug.Log("The note '" + name + "' has already been unlocked! ");
            return;
        }

        //change UI display
        ChangeUINew(true);

        //unlock note
        notesManager.UnlockNote(name);

        // make sure that the book will flip to the new content when new note is added
        int pageNum = int.Parse(name.Split("_")[0]);
        TurnToPage(pageNum);
    }

    public void ChangeUINew(bool b)
    {
        hasNew = b;
        icon.ChangeNewIcon(b);
    }
}
