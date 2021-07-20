using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    public Image[] img;

    public void LoadNext()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // fade in
        foreach (Image ima in img)
        {
            ima.enabled = true;
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                ima.color = new Color(ima.color[0], ima.color[1], ima.color[2], i);
                yield return null;
            }
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
