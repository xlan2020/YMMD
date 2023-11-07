using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DisplaceTargetItem
{
    public ItemScriptableObject item;
    public float minMoney;
    public bool displaced;
    public bool canDisplaceAgain;
}


[CreateAssetMenu(fileName = "accurateDepiction_", menuName = "ScriptableObjects/accurateDepiction")]
public class AccurateDepictionScriptableObject : ScriptableObject
{
    public string name;
    public Sprite image;
    public DisplaceTargetItem[] targetItems;
}