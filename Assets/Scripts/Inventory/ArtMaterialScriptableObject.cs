using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/art material")]
public class ArtMaterialScriptableObject : ScriptableObject
{
    [Header("Canvas Modules")]
    public Sprite canvasSprite;
    [Header("Brush Modules")]
    public Sprite brushSprite;
    [Header("Paint Modules")]
    public GameObject paintPrefab;
}