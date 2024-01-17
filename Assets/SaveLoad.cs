using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    public void Load(int saveFileId)
    {
        if (saveFileId == -1)
        {
            // do not load any save, restart the scene
            // only use this when restarting the game
            return;
        }

        string saveString = SaveSystem.Load(saveFileId);

        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.LogWarning("no matching save data file");
        }

        // convert save data to SaveObject
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);


    }
}
