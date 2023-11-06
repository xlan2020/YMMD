
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite spriteImage;
    [TextAreaAttribute(3, 3)] public string description;

    [Space(10)]
    [Header("Value Attribute")]
    public float value;
    public float storePrice;
    public bool displaceable = true;
    public bool isNew = true;
    private bool isCash = false;

    [Space(10)]
    [Header("Map Interaction")]
    public bool destroyOnInteract;

    [Space(10)]
    [Header("Drawing Attribute")]
    public DrawType drawType = DrawType.notDraw;
    public ArtMaterialScriptableObject artMaterial;
    [TextAreaAttribute(3, 3)] public string drawDescription;
    public string drawAttribute;
    [Range(1, 5)] public int draw_stable = 1;
    [Range(1, 5)] public int draw_experimental = 1;
    [Range(1, 5)] public int draw_organic = 1;
    [Range(1, 5)] public int draw_premium = 1;
    public int durability;

    public bool IsNew()
    {
        return isNew;
    }
}
public enum DrawType
{
    notDraw = 0,
    canvas = 1,
    brush = 2,
    paint = 3,
    brushPaint = 4,
}


