using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBlackout : MonoBehaviour
{
    public LoadingScene loadingScene;
    public string nextSceneName;

    public void LoadNextScene(){
        loadingScene.LoadScene(nextSceneName);
    }

    public void StartBlackout(){
        GetComponent<Animator>().SetTrigger("start");
    }

}
