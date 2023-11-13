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
    public GameManager gameManager;
    

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
        // TODO: bgm fade out

        // AUTO SAVE
        if (gameManager != null){
            // problem: the end of 3 screen doesn't have auto save...
            gameManager.AutoSave(sceneName);
        }

        // transition time added
        yield return new WaitForSeconds(transitionTimeAddition);

        // TODO: handle language?
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            //loadProgressDisplay.text=progressValue.ToString("0.0")+"%";

            UnityEngine.Debug.Log("new scene loading, progress: "+progressValue);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void RestartGame(){
        // delete autosave and load scene
        string sceneName = "DAY1-0"; // might switch language
        StartCoroutine(RestartAndLoadSceneAsync(sceneName));
    }

    IEnumerator RestartAndLoadSceneAsync(string sceneName)
    {
        animator.SetTrigger(animationTrigger);
        // TODO: bgm fade out

        // AUTO SAVE
        SaveSystem.DeleteAutoSave();

        // transition time added
        yield return new WaitForSeconds(transitionTimeAddition);

        // TODO: handle language?
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
