using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct NameColor
{
    public string name;
    public UnityEngine.Color color;
    public AudioClip voiceBlip;
}
[CreateAssetMenu(fileName = "NameStyleObject", menuName = "ScriptableObjects/nameStyle")]
public class NameStyleScriptableObject : ScriptableObject
{
    public NameColor[] nameColors;

}