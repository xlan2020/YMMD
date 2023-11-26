using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public int id;
    public float value;
    public float storePrice;
    public string itemName;
    public string itemName_EN;
    public string description;
    public string description_EN;
    public Sprite spriteImage;
    public bool destroyOnInteract;
    public bool displaceable;
    public int customDisplaceEventIndex;
    public bool collectAfterDialogue;
    public bool collectOnInteract;
    public bool isNew;
    public int durability;
    public DrawType drawType;
    public ArtMaterialScriptableObject artMaterial;
    //public int drawType; // 0 - not painting material; 1-  画布; 2 - 画笔; 3 - 颜料; 
    public string drawDescription;
    public string drawDescription_EN;
    public string drawAttribute;
    public string drawAttribute_EN;
    public int draw_stable;
    public int draw_experimental;
    public int draw_organic;
    public int draw_premium;

}
