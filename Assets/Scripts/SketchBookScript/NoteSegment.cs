using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSegment : MonoBehaviour
{
    public string name; //format: 1_1_名字
    private string[] splitName;
    public bool unlocked = false;
    // public NotesManager manager;
    private bool visible = false;
    private SpriteRenderer sp;
    private Collider2D collider;

    void Awake()
    {
        splitName = name.Split("_");
        sp = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    public void Unlock()
    {
        unlocked = true;
        if (visible)
        {
            sp.enabled = true;
            collider.enabled = true;
        }
        UnityEngine.Debug.Log("unlock note: " + name);
    }

    public int PageNum()
    {
        int page = int.Parse(splitName[0]);
        return page;
    }

    public void SetVisible(bool b)
    {
        UnityEngine.Debug.Log("set visible！");
        visible = b;

        if (unlocked)
        {
            sp.enabled = b;
            collider.enabled = b;
        }
        else
        {
            sp.enabled = false;
            collider.enabled = false;
        }
    }
}
