using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawResultVisualizer : MonoBehaviour
{
    public Image mat1;
    public Image mat2;
    public Image mat3;

    public Text mat_vals;
    public Text mat_sum;
    public Text mat_stability;
    public Text mat_res;
    public Text theme;
    public Text all_sum;
    public Text reputation;
    public Text gain;

    public void ShowSelf(bool b)
    {
        gameObject.SetActive(b);
        if (b == true)
        {
            // handle audio
            // stop current bgm
            // play draw result bgm
        }
    }


}
