using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScene : MonoBehaviour
{
    public LoadingScene loadingScene;
    void Start()
    {
        if (GlobalSaveManager.TryLoad() == true)
        {
            // not the first time, enter title screen directly
            loadingScene.LoadScene("0_TitleScreen", autoSave: false, transition: false);
        }
    }

}
