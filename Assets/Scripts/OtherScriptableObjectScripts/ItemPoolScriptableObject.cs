using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPool_", menuName = "ScriptableObjects/itemPool")]
public class ItemPoolScriptableObject : ScriptableObject
{
    public int priceRank;
    public ItemScriptableObject[] items_N;
    public ItemScriptableObject[] items_R;
    public ItemScriptableObject[] items_SR;

}
