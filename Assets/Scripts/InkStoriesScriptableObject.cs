using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InkStoriesScriptableObject", menuName = "ScriptableObjects/inkStories")]
public class InkStoriesScriptableObject : ScriptableObject
{
    
    public TextAsset[] allInkJsons;

    public int GetInkJsonId(TextAsset inkJson){
        for(int i = 0; i < allInkJsons.Length; i++){
            if (allInkJsons[i] == inkJson){
                // this get the first same ink json in the array
                return i;
            }
        }
        UnityEngine.Debug.LogWarning("The text asset does not exist!");
        return -1;
    }

    public TextAsset GetInkJsonById(int id){
        return allInkJsons[id];
    }

    
}