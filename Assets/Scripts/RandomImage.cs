using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{
    public Sprite[] spritesPool;

    public bool displayAtStart = true;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();

    }

    void Start()
    {
        if (displayAtStart)
        {
            DisplayRandomImage();
        }
    }
    public void DisplayRandomImage()
    {
        int i = Random.Range(0, spritesPool.Length);
        image.sprite = spritesPool[i];
    }
}
