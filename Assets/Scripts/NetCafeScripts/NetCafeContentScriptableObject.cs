using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NetCafeContentSO_", menuName = "ScriptableObjects/NetCafe/netCafeContent")]
public class NetCafeContentScriptableObject : ScriptableObject
{
    public NewsDetailScriptableObject headline;
    public NewsDetailScriptableObject[] newsArray; // all news to be displayed in this scene
    public PostScriptableObject[] postArray; // all posts available to view in this scene
    [TextAreaAttribute(5, 3)] public string newsAnnounce;
    [TextAreaAttribute(5, 3)] public string newsAnnounce_EN;
    [TextAreaAttribute(5, 3)] public string forumAnnounce;
    [TextAreaAttribute(5, 3)] public string forumAnnounce_EN;
}
