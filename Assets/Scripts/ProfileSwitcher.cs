using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSwitcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Dictionary<string, Sprite> spriteSources = new Dictionary<string, Sprite>();
    [SerializeField] private SpriteRenderer profileFrame;

    //private string[] painterNames = { "painter", "Painter", "画家", "我", "Me", "me" };
    //private string[] eighminusNames = { "8-2", "巴简二", "Eighminus", "Eighminus Tue" };
    /**
    private string ConvertName(string name)
    {

        if (painterNames.Contains(name))
        {
            return "painter";
        }
        else if (eighminusNames.Contains(name))
        {
            return "8-2";
        }
        {
            return null;
        }
    }
    */

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("ProfileSprites");
        foreach (Sprite s in sprites)
        {
            spriteSources.Add(s.name, s);
        }
    }

    public void ChangeProfile(string name)
    {
        if (name == "null" || name == "none" || name == "hide")
        {
            spriteRenderer.sprite = null;
            profileFrame.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = spriteSources[name];
            profileFrame.enabled = true;
        }
        /**
        string[] splitName = name.Split("_");
        string charaName = splitName[0];
        string expression = splitName[1];

        string directory = "ProfileSprites/profile_" + charaName + "/" + charaName + "_" + expression;
        UnityEngine.Debug.Log("finding sprite from directory: " + directory);

        spriteRenderer.sprite = Resources.Load<Sprite>(directory);
        */
    }
}
