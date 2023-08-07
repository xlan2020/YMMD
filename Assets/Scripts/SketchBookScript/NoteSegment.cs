using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSegment : MonoBehaviour
{
    private string name; //format: 1_1_名字
    private string[] splitName;
    public bool unlocked = false;
    // public NotesManager manager;
    private bool visible = false;
    private SpriteRenderer sp;
    private Collider2D collider;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        if (!unlocked)
        {
            sp.enabled = false;
            collider.enabled = false;
        }

        name = gameObject.name;
        splitName = name.Split("_");
        //UnityEngine.Debug.Log("split name:" + splitName[0] + ", " + splitName[1] + ", " + splitName[2]);
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
