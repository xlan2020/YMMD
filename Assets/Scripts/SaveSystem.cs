using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/SavesData/";


    public static void Init() {
        // check if save folder exist
        if (!Directory.Exists(SAVE_FOLDER)) {
            // if not, create it
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void AutoSave(string saveString) {
        SaveAtSlot(saveString, 0);
    }

    public static void DeleteAutoSave(){
        if (File.Exists(SAVE_FOLDER + "save_0.txt")){
            UnityEngine.Debug.Log("deleting auto save!");
            File.Delete(SAVE_FOLDER + "save_0.txt");
        }
    }

    public static bool HasAutoSave(){
        if (File.Exists(SAVE_FOLDER + "save_0.txt")){
            return true;
        }
        return false;
    }
    public static void SaveAtSlot(string saveString, int slotIndex) {
        // slotIndex 0 -> AutoSave
        if (slotIndex > 10 || slotIndex < 0){
            UnityEngine.Debug.LogWarning("the save slot does not exist!");
            return;
        }
        File.WriteAllText(SAVE_FOLDER + "save_" + slotIndex + ".txt", saveString);
    }

    // legacy save, as many as you can
    public static void Save(string saveString){
        int saveNumber = 1;
        while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".txt")) {
            saveNumber++;
        } 

        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", saveString);
    }

    public static string Load(int fileId) {
        if (File.Exists(SAVE_FOLDER + "/save_" + fileId +".txt")) { // safe check
            // deserialize saved data and return
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save_" + fileId +".txt");
            return saveString;
        } else {
            return null;
        }
    }
}