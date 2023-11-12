using System.Net.Mime;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class NotesManager : MonoBehaviour
{
    public List<NoteSegment> notes = new List<NoteSegment>();
    public Dictionary<string, NoteSegment> notesDict = new Dictionary<string, NoteSegment>();
    private NotePage[] pages = new NotePage[100];
    public bool StartOfTheGame = false;
    private int currPage;
    private int maxPage = 0;
    private string bookSavedJSON;
    public SketchBook sketchBook;

    void Awake()
    {

    }

    void Start()
    {
        // first add all notes segment to the notes list
        foreach (Transform child in transform)
        {
            NotePage page = child.GetComponent<NotePage>();
            if (page != null)
            {
                int num = page.PageNum();
                UnityEngine.Debug.Log("adding page num to list: " + num);
                pages[num] = page;

                notes.AddRange(page.Notes());

                if (num > maxPage)
                {
                    maxPage = num;
                }
            }
        }
        // initialize book saved data, just place it here for 
        // 暂时凑合的对策，之后必须改，本质是save system还没做好
        if (StartOfTheGame)
        {
            InitializeBookForGameStart();
        }

        // Initialize Dictionary
        foreach (NoteSegment note in notes)
        {
            notesDict.Add(note.name, note);
            UnityEngine.Debug.Log("Add to NotesManager dictionary, key as: " + note.name);
        }
        currPage = sketchBook.CurrentPage();
        sketchBook.CloseBook();
    }

    public void UnlockNote(string name)
    {
        NoteSegment n = notesDict[name];
        n.Unlock();
    }

    public bool NoteIsUnlocked(string name)
    {
        return notesDict[name].unlocked;
    }

    public void TurnToPage(int i)
    {
        NotePage prevPage = pages[currPage]; // store the prev page
        currPage = i;

        if (prevPage != null)
        {
            prevPage.SetNoteDisplay(false);
        }

        if (pages[currPage] != null)
        {
            pages[currPage].SetNoteDisplay(true);
        }
    }


    void InitializeBookForGameStart()
    {
        /**
        bookSavedJSON = "";
        bookSavedJSON = JsonUtility.ToJson(notes);
        File.WriteAllText(Application.dataPath + "saveFile_book.json", bookSavedJSON);
        UnityEngine.Debug.Log("Initialize Book Json: " + bookSavedJSON);
*/
        foreach (NoteSegment n in notes)
        {
            n.gameObject.GetComponent<Collider2D>().enabled = n.unlocked;
            n.gameObject.GetComponent<SpriteRenderer>().enabled = n.unlocked;
        }
    }

    public int MaxPage()
    {
        return maxPage;
    }

}
