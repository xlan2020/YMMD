using UnityEngine;

[CreateAssetMenu(fileName = "ResDraw_", menuName = "ScriptableObjects/resultDrawing")]
public class ResultDrawingScriptableObject : ScriptableObject
{
    [Header("Drawing Info")]
    public string title;
    public string subject;
    public string themeDescription;
    public int themeScore;

    [Header("Reactions")]
    public Sprite clientProfile;
    [TextArea] public string clientReaction;
    [TextArea] public string painterReaction;

    [Header("Visuals")]
    public Sprite image;
    public Sprite fillLayer;
    public Sprite pointColorLayer;
    public Sprite strokeLayer;

}
