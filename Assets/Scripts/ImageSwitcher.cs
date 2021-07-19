using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image npc;
    public Sprite[] oriSprites;
    private Queue<Sprite> sprites;

    void Start()
    {
        // initialize q and store sprites in it
        sprites = new Queue<Sprite>();
        foreach (Sprite s in oriSprites)
        {
            sprites.Enqueue(s);
        }
    }

    // switches images from the q
    public void Switch()
    {
        if (sprites.Count != 0)
        {
            npc.sprite = sprites.Dequeue();
        }
        return;
    }


}
