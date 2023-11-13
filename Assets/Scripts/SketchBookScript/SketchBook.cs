using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SketchBook : MonoBehaviour
{
    public static SketchBook instance { get; private set; }
    // public NotesManager notesManager;
    [Header("SketchBook Content")]
    public SketchBookSpritesScriptableObject sketchBookSprites;
    private int maxPage = 11;

    [Header("UI Elements")]
    public SketchBookButton icon;
    public GameObject assesories;
    public GameObject flipLeftButton;
    public GameObject flipRightButton;
    public GameObject noteDisplay;
    public SpriteRenderer[] notesContainer; // should only have 4
    public Text currentPageText;

    [Header("Audio")]
    public AudioClip OpenBookAudio;
    public AudioClip CloseBookAudio;
    public AudioClip[] FlipPageAudios;
    private AudioSource audio;

    [Header("Other Game Elements")]
    public InkDialogueManager dialogueManager;
    public InventoryButton inventoryButton;
    public MapPlayer mapPlayer;

    private bool isOpen = false;
    private bool hasNew;
    private int currPage = 0;


    void Awake()
    {
        gameObject.SetActive(true);
        audio = GetComponent<AudioSource>();

        /**
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        */

            // create book data structure
            BookNote[,] bookNotes2DArray = new BookNote[maxPage, 4];
            for (int i = 0; i < maxPage; i++){
                for (int j = 0; j < 4; j++) {

                        Sprite s = null;
                        bool exist = false;
                        bool unlocked = false;
                        if (i == 0 || i == 1){
                            // first two pages initially unlocked
                            unlocked = true;
                        }

                        if (sketchBookSprites.pages.Length > i && sketchBookSprites.pages[i].notes.Length > j){
                            s = sketchBookSprites.pages[i].notes[j];
                            exist = true;
                        }

                        bookNotes2DArray[i,j] = new BookNote {
                            sprite = s,
                            unlocked = unlocked,
                            exist = exist
                        };
                        UnityEngine.Debug.Log("create note at: " + i + ", " + j);
                }
            }
            SketchbookData.bookNotes2DArray = bookNotes2DArray;
            SketchbookData.maxPage = maxPage;

    }
    void Start()
    {
        isOpen = false;
        noteDisplay.SetActive(false);
        assesories.SetActive(false);
    }

    public void TurnToPage(int page)
    {
        currPage = page;
        // notesManager.TurnToPage(currPage);
        DisplayPageUnlockedNotes(page);
        currentPageText.text = currPage + " / 10";  // let's assume we have 10 page maximum! 
        if (page == 0){
            flipLeftButton.SetActive(false);
        } else{
            flipLeftButton.SetActive(true);
        }
        if (page == maxPage-1){
            flipRightButton.SetActive(false);
        }else {
            flipRightButton.SetActive(true);
        }
    }

    private void DisplayPageUnlockedNotes(int page){
        if (SketchbookData.bookNotes2DArray == null){
            return;
        }
        for (int i = 0; i < 4; i++){
            BookNote n = SketchbookData.bookNotes2DArray[page, i];
                if (n.unlocked){
                    // if the note is unlocked, display it
                    notesContainer[i].sprite = n.sprite;
                } else {
                    // if the note is not unlocked, don't display anything
                    notesContainer[i].sprite = null;
                }
        }
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
            if (inventoryButton != null)
            {
                inventoryButton.canOpen = true;
            }
        }
        else
        {
            isOpen = true;
            OpenBook();
            if (inventoryButton != null) inventoryButton.canOpen = false;
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

        // notesManager.gameObject.SetActive(true);
        noteDisplay.SetActive(true);
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

        //notesManager.gameObject.SetActive(false);
        noteDisplay.SetActive(false);

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
        if (currPage < maxPage)
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
        /**
        // LEGACY
        // if the note is already unlocked, then does nothing and return;
        if (notesManager.NoteIsUnlocked(name))
        {
            //UnityEngine.Debug.Log("The note '" + name + "' has already been unlocked! ");
            return;
        }
        */
        
        // interpret input
        int page = int.Parse(name.Split("_")[0]);
        int index = int.Parse(name.Split("_")[1])-1;

        // if the note is already unlocked, then does nothing and return;
        if (SketchbookData.bookNotes2DArray[page, index].unlocked){
            UnityEngine.Debug.Log("The note '" + name + "' has already been unlocked! ");
            return;
        }

        //change UI display
        ChangeUINew(true);

        //unlock note
        SketchbookData.bookNotes2DArray[page, index].unlocked = true;

        // make sure that the book will flip to the new content when new note is added
        TurnToPage(page);
    }

    public void ChangeUINew(bool b)
    {
        hasNew = b;
        icon.ChangeNewIcon(b);
    }

}

public struct BookNote {
    public Sprite sprite;
    public bool unlocked;
    public bool exist;
}