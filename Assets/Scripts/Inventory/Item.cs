using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public float value;
    public float storePrice;
    public string itemName;
    public string description;
    public Sprite spriteImage;
    public bool destroyOnInteract;
    public bool displaceable;
    public bool collectAfterDialogue;
    public bool collectOnInteract;
    public bool isNew;
    public int durability;
    public DrawType drawType;
    //public int drawType; // 0 - not painting material; 1-  画布; 2 - 画笔; 3 - 颜料; 
    public string drawDescription;
    public string drawAttribute;
    public int draw_stable;
    public int draw_experimental;
    public int draw_organic;
    public int draw_premiere;
}
