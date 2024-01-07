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
    public bool beginWithoutLoadingScreen = false;
    private bool isLoading = false;


    void Awake()
    {
        animator = GetComponent<Animator>();
        if (beginWithoutLoadingScreen)
        {
            animator.SetBool("Loading", false);
        }
    }
    public string GetActiveSceneId()
    {
        string id = SceneManager.GetActiveScene().name;
        return id;
    }
    public void LoadScene(string sceneName, bool autoSave = true, bool deleteAutoSave = false, bool transition = true)
    {
        if (isLoading)
        {
            UnityEngine.Debug.Log("scene is already loading in progress! new scene won't be loaded");
            return;
        }
        isLoading = true;
        if (sceneName == "0_NoContent")
        {
            StartCoroutine(LoadSceneAsync(sceneName, autoSave: false, deleteAutoSave: false, transition));
        }
        StartCoroutine(LoadSceneAsync(sceneName, autoSave, deleteAutoSave, transition));
    }

    IEnumerator LoadSceneAsync(string sceneName, bool autoSave = true, bool deleteAutoSave = false, bool transition = true)
    {
        BGMPlayer.GetInstance().FadeCurrentBGM(2f, 0f);
        UnityEngine.Debug.Log("loading scene process start");
        if (transition)
        {
            animator.SetTrigger(animationTrigger);

        }
        // TODO: bgm fade out

        if (autoSave)
        {
            // AUTO SAVE
            if (gameManager != null)
            {
                // problem: the end of 3 screen doesn't have auto save...
                gameManager.AutoSave(sceneName);
                GameEssential.currentSave = 0;
            }
        }

        if (deleteAutoSave)
        {
            // DELETE AUTO SAVE
            SaveSystem.DeleteAutoSave();
        }

        if (transition)
        {
            // transition time added
            yield return new WaitForSeconds(transitionTimeAddition);
        }

        // TODO: handle language?
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            //loadProgressDisplay.text=progressValue.ToString("0.0")+"%";

            UnityEngine.Debug.Log("new scene loading, progress: " + progressValue);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void RestartGame()
    {
        // delete autosave and load scene
        string sceneName = "DAY1-0";
        StartCoroutine(RestartAndLoadSceneAsync(sceneName));
    }

    IEnumerator RestartAndLoadSceneAsync(string sceneName)
    {
        animator.SetTrigger(animationTrigger);
        // TODO: bgm fade out

        // DELETE AUTO SAVE
        SaveSystem.DeleteAutoSave();

        // transition time added
        yield return new WaitForSeconds(transitionTimeAddition);

        // TODO: handle language?
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            //loadProgressDisplay.text=progressValue.ToString("0.0")+"%";

            UnityEngine.Debug.Log("new scene loading, progress: " + progressValue);
            yield return new WaitForSeconds(0.04f);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        LoadScene("0_TitleScreen", autoSave: false, transition: true);
    }

    public void FadeOutLoadingScreen()
    {
        animator.SetBool("Loading", false);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        GlobalSaveManager.Save();
    }
}
