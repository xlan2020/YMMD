using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InBlockMarquee : MonoBehaviour
{
    /**
    This is an original Maquee Code that only works within text block
    */

    Text textBlock;
    string originalText;
    int counter = 0;
    float clock = 0f;

    public float interval = 0.2f;
    public string inBetweenSpace = "    ";

    void Awake()
    {
        textBlock = GetComponent<Text>();
        originalText = textBlock.text;
    }

    void Start()
    {
        textBlock.text += inBetweenSpace + originalText + inBetweenSpace + originalText;
    }

    void Update()
    {
        clock += Time.deltaTime;
        if (clock > interval)
        {
            clock = 0f;

            textBlock.text = textBlock.text.Remove(0, 1);
            counter++;
            if (counter > originalText.Length)
            {
                counter = 0;
                textBlock.text += inBetweenSpace + originalText;
            }
        }
    }
}
