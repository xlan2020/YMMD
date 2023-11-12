using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllItemScriptableObject", menuName = "ScriptableObjects/allItem")]
public class AllItemScriptableObject : ScriptableObject
{
    public ItemScriptableObject[] arrayById;

}
