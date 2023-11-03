using UnityEngine;

[CreateAssetMenu(fileName = "ClientSpecialScriptableObject", menuName = "ScriptableObjects/clientSpecial")]
public class ClientSpecialScriptableObject : ScriptableObject
{
    public PreferenceAttitude experimental_attitude;
    public PreferenceAttitude organic_attitude;
    public PreferenceAttitude premium_attitude;

    public ResultDrawingScriptableObject[] resultDrawings = new ResultDrawingScriptableObject[3];
    
    [Range(0,100)] public int[] resultStandard = new int[3]; // length must match the above
    public string binaryStandard;
}

public enum PreferenceAttitude{
    none,
    preferred,
    disliked
}
