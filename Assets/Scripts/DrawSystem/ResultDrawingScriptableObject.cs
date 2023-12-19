using UnityEngine;

[CreateAssetMenu(fileName = "ResDraw_", menuName = "ScriptableObjects/resultDrawing")]
public class ResultDrawingScriptableObject : ScriptableObject
{
    [Header("Drawing Info")]
    public string title;
    public string title_EN;
    public string subject;
    public string subject_EN;
    public string themeDescription;
    public string themeDescription_EN;
    public int themeScore;

    [Header("Reactions")]
    public Sprite clientProfile;
    [TextArea] public string clientReaction;
    [TextArea] public string clientReaction_EN;
    [TextArea] public string painterReaction;
    [TextArea] public string painterReaction_EN;

    [Header("Visuals")]
    public Sprite image;
    public Sprite fillLayer;
    public Sprite pointColorLayer;
    public Sprite strokeLayer;

}
