using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfoScriptableObject", menuName = "ScriptableObjects/sceneInfo")]
public class SceneInfoScriptableObject : ScriptableObject
{
    public SceneInfo[] allScenes;
    private Dictionary<string, SceneInfo> sceneDict;

    void Awake(){
        sceneDict = new Dictionary<string, SceneInfo>();
        foreach (SceneInfo sceneInfo in allScenes){
            sceneDict.Add(sceneInfo.sceneId, sceneInfo);
        }
    }

    public Dictionary<string, SceneInfo> GetSceneInfoDict(){
        if (sceneDict == null){
            sceneDict = new Dictionary<string, SceneInfo>();
            foreach (SceneInfo sceneInfo in allScenes){
                sceneDict.Add(sceneInfo.sceneId, sceneInfo);
             }
        }
        return sceneDict;
    }

}

[System.Serializable]
public struct SceneInfo
{
    public string sceneId;
    public SceneType sceneType;
    public string sceneDescription_CH;
    public string sceneDescription_EN;
}

public enum SceneType{
    ThreeScreen, 
    Waking, 
    Map,
    Draw, 
    FluidBrain, 
    DFD
}