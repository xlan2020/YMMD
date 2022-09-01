using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePage : MonoBehaviour
{
    private int pageNum;
    private List<NoteSegment> notes = new List<NoteSegment>();

    void Awake()
    {
        foreach (Transform child in transform)
        {
            NoteSegment n = child.GetComponent<NoteSegment>();
            if (n != null)
            {
                notes.Add(n);
                //UnityEngine.Debug.Log("adding note to note page: " + n.name);
                pageNum = n.PageNum();
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
