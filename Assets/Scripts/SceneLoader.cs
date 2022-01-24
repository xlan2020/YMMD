using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float transitionTime = 1f;
    private bool loaded = false;
    [SerializeField] Player player;

    void Start()
    {
        if (loaded == false)
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadScene(int levelIndex)
    {//save inventory
        player.SaveInventory();
        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
        loaded = true;
    }
}
