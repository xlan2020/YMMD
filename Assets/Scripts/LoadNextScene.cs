using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene: MonoBehaviour
{
    public void LoadSceneByName(string name){
        SceneManager.LoadScene(name);
    }
}
