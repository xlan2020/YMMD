using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    public Image img;
    public bool fade_away;
    
    // Fades the img in(false)/out(true)
    public void FadeInOrOut()
    {
            StartCoroutine(FadeImage(fade_away));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            // fade to transparent
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(img.color[0], img.color[1], img.color[2], i);
                yield return null;
            }
            img.enabled = false;
        }
        else
        {
            img.enabled = true;
            // fade in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            fade_away = !fade_away;
        }
    }
}
