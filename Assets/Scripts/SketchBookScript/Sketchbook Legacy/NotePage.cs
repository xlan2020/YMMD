using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePage : MonoBehaviour
{
    private int pageNum;
    private List<NoteSegment> notes = new List<NoteSegment>();

    void Awake()
    {
        // game object name format: Page_num
        // example: Page_1
        pageNum = int.Parse(gameObject.name.Split("_")[1]);
        foreach (Transform child in transform)
        {
            NoteSegment n = child.GetComponent<NoteSegment>();
            if (n != null)
            {
                notes.Add(n);
            }
        }
        //UnityEngine.Debug.Log("page " + pageNum + " notes count is: " + notes.Count);
    }

    public List<NoteSegment> Notes()
    {
        return notes;
    }

    public void SetNoteDisplay(bool b)
    {
        foreach (NoteSegment n in notes)
        {
            //UnityEngine.Debug.Log("set visible note" + n.name);
            n.SetVisible(b);
        }
    }
    public int PageNum()
    {
        return pageNum;
    }
}
