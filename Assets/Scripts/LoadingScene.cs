using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScene : MonoBehaviour
{
    private Animator animator;
    public Text loadProgressDisplay;
    public float transitionTimeAddition = 2f;
    public string animationTrigger = "DipToBlack";
    

    void Awake(){
        animator = GetComponent<Animator>();
    }
    public string GetActiveSceneId(){
        string id = SceneManager.GetActiveScene().name;
        return id;
    }
    public void LoadScene(string sceneName){
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName){
        animator.SetTrigger(animationTrigger);
        // bgm fade out

        // AUTO SAVE
        
        yield return new WaitForSeconds(transitionTimeAddition);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            //loadProgressDisplay.text=progressValue.ToString("0.0")+"%";

            UnityEngine.Debug.Log("new scene loading, progress: "+progressValue);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
