using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SketchBookScriptableObject", menuName = "ScriptableObjects/sketchbook")]
public class SketchBookSpritesScriptableObject : ScriptableObject
{
    public PageSprites[] pages;
}

[System.Serializable]
public struct PageSprites
{
    public Sprite[] notes;
    public Sprite[] notes_EN;
}

