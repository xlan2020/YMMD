using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public NoteSegment[] notes;
    public Dictionary<NoteSegment, int> GetId = new Dictionary<NoteSegment, int>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<NoteSegment, int>();
        for (int i = 0; i < notes.Length; i++)
        {
            GetId.Add(notes[i], i);
        }
    }

    public void OnBeforeSerialize()
    {

    }
}
