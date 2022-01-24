using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadEventHandler : MonoBehaviour
{
    [SerializeField] Button[] btnsToBeClicked;//btns to be clicked when a new scene loaded
    [SerializeField] float bufferTime = 1f;
    Scene currentScene;

    private void Awake()
    {
        // remove listener as fail- safe
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Add the listener when new scene loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(gameObject);

        // Store the creating scene as the scene to trigger start
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        // clean up listeners
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Listener for sceneLoaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // return if not the starting scene
        if (!string.Equals(scene.path, this.currentScene.path)) return;

        // click button and fade in
        StartCoroutine(clickNfadeIn());
    }

    IEnumerator clickNfadeIn()
    {
        foreach (Button btnToBeClicked in btnsToBeClicked)
        {
            yield return new WaitForSeconds(bufferTime);
            btnToBeClicked.onClick.Invoke();
        }
    }
}
