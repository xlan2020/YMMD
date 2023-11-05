using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
The current version created 2023/11/5
*/

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Text loadProgressDisplay;


    public void LoadScene(string sceneName){
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName){
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        // save load data

        while (!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadProgressDisplay.text=progressValue.ToString("0.0")+"%";

            UnityEngine.Debug.Log("new scene loading, progress: "+progressValue);
            yield return new WaitForSeconds(0.04f);
        }
    }
}
