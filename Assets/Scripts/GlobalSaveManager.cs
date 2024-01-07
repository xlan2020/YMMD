using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
only save data in game essentials and gallery
save when closing the program
SAVE SLOT: 99
*/
public static class GlobalSaveManager
{
    private static int SAVE_FILE_INDEX = 99;
    public static void Save()
    {
        UnityEngine.Debug.Log("saving data before closing...");
        GlobalSaveObject saveObject = new GlobalSaveObject
        {
            localeId = GameEssential.localeId
        };

        string json = JsonUtility.ToJson(saveObject);
        // write the save file
        SaveSystem.SaveAtSlot(json, SAVE_FILE_INDEX);
        UnityEngine.Debug.Log("global save complete");
    }

    public static bool TryLoad()
    {
        string saveString = SaveSystem.Load(SAVE_FILE_INDEX);

        if (saveString == null || saveString == "")
        {
            UnityEngine.Debug.Log("no matching save data file, first time entering the game");
            // play language select screen
            return false;
        }

        // convert save data to SaveObject
        GlobalSaveObject saveObject = JsonUtility.FromJson<GlobalSaveObject>(saveString);

        // load data from save
        GameEssential.localeId = saveObject.localeId;

        return true;
    }

    private class GlobalSaveObject
    {
        public int localeId;
        public float bgmVol;
        public float sfxVol;

        // note unlocked state?
        // item gallery
    }
}
