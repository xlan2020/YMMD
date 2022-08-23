using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchBook : MonoBehaviour
{
    public NotesManager notesManager;
    public SketchBookButton icon;
    public AudioClip OpenBookAudio;
    public AudioClip CloseBookAudio;
    public AudioClip[] FlipPageAudios;
    private AudioSource audio;
    private bool isOpen = false;
    private bool hasNew;
    private int currPage = 0;
    public GameObject cover;
    public InkDialogueManager dialogueManager;

    void Awake()
    {
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        cover.SetActive(false);
    }

    public void TurnToPage(int i)
    {
        currPage = i;
        notesManager.TurnToPage(currPage);
    }

    public int CurrentPage()
    {
        return currPage;
    }
    public void ToggleOpen()
    {
        if (isOpen)
        {
            isOpen = false;
            CloseBook();
        }
        else
        {
            isOpen = true;
            OpenBook();
        }
    }
    private void OpenBook()
    {
        GetComponent<AudioSource>().clip = OpenBookAudio;
        GetComponent<AudioSource>().Play();
        if (hasNew)
        {
            ChangeUINew(false);
        }

        notesManager.gameObject.SetActive(true);
        cover.SetActive(true);
        if (dialogueManager != null)
        {
            dialogueManager.FreezeDialogue();
        }

        TurnToPage(currPage);
        UnityEngine.Debug.Log("Current page is: " + currPage);
    }

    private void CloseBook()
    {
        GetComponent<AudioSource>().clip = CloseBookAudio;
        GetComponent<AudioSource>().Play();

        notesManager.gameObject.SetActive(false);

        cover.SetActive(false);
        if (dialogueManager != null)
        {
            dialogueManager.UnfreezeDialogue();
        }
    }

    public void UnlockNewNote(string name)
    {
        // if the note is already unlocked, then does nothing and return;
        if (notesManager.NoteIsUnlocked(name))
        {
            return;
            UnityEngine.Debug.Log("The note '" + name + "' has already been unlocked! ");
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
