using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItems_", menuName = "ScriptableObjects/Shop/ShopItemList")]

public class ShopItemListScriptableObject : ScriptableObject
{
    public ItemScriptableObject[] items;  // 包含的物品列表
}