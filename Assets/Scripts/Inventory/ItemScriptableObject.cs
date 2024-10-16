
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/item")]
public class ItemScriptableObject : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemName_EN;
    public Sprite spriteImage;
    [TextAreaAttribute(3, 3)] public string description;
    [TextAreaAttribute(3, 3)] public string description_EN;

    [Space(10)]
    [Header("Value Attribute")]
    public float value;
    public float storePrice;
    [TextAreaAttribute(2, 2)] public string storeTalk = "店长：买买买！【placeholder】";
    [TextAreaAttribute(2, 2)] public string storeTalk_EN = "SALES: Hey, doesn't this look good? [placeholder]";
    public bool displaceable = true;
    public bool isNew = true;
    public bool is_Chai = false;
    private bool isCash = false;

    [Space(10)]
    [Header("Map Interaction")]
    public bool destroyOnInteract;

    [Space(10)]
    [Header("Drawing Attribute")]
    public DrawType drawType = DrawType.notDraw;
    public ArtMaterialScriptableObject artMaterial;
    [TextAreaAttribute(3, 3)] public string drawDescription;
    [TextAreaAttribute(3, 3)] public string drawDescription_EN;
    public string drawAttribute;
    public string drawAttribute_EN;
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


