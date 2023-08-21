using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemInfo : MonoBehaviour
{

    public string itemName;
    public Sprite spriteImage;
    [TextAreaAttribute(3, 3)] public string description;

    [Space(10)]
    [Header("Value Attribute")]
    public float value;
    public float storePrice;
    public bool displaceable = true;
    private bool isNew = true;

    [Space(10)]
    [Header("Map Interaction")]
    public bool destroyOnInteract;

    [Space(10)]
    [Header("Drawing Attribute")]
    public DrawType drawType = DrawType.notDraw;
    public ArtMaterialScriptableObject artMaterial;
    [TextAreaAttribute(3, 3)] public string drawDescription;
    public string drawAttribute;
    [Range(1, 5)] public int draw_stable;
    [Range(1, 5)] public int draw_experimental;
    [Range(1, 5)] public int draw_organic;
    [Range(1, 5)] public int draw_premiere;
    public int durability;

    Item item;

    private void Awake()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null && spriteImage == null)
        {
            spriteImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        }

        item = new Item
        {
            value = value,
            storePrice = storePrice,
            itemName = itemName,
            description = description,
            spriteImage = spriteImage,
            destroyOnInteract = destroyOnInteract,
            displaceable = displaceable,
            isNew = isNew,

            durability = durability,
            //drawType = getDrawTypeInt(drawType), // 0 - not draw 1-  画布; 2 - 画笔; 3 - 颜料; 
            drawType = drawType,
            artMaterial = artMaterial,
            drawDescription = drawDescription,
            drawAttribute = drawAttribute,
            draw_stable = draw_stable,
            draw_experimental = draw_experimental,
            draw_organic = draw_organic,
            draw_premiere = draw_premiere
        };
    }
    public Item GetItem()
    {
        return item;
    }

    private int getDrawTypeInt(DrawType name)
    {
        switch (name)
        {
            case DrawType.notDraw:
                return 0;
            case DrawType.canvas:
                return 1;
            case DrawType.brush:
                return 2;
            case DrawType.paint:
                return 3;
            default:
                return 0;
        }
    }
}