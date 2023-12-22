using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/SavesData/";


    public static void Init()
    {
        string savesFolderPath = GetFilePath("");
        // create the file in the path if it doesn't exist
        // if the file path or name does not exist, return the default SO
        if (!Directory.Exists(Path.GetDirectoryName(savesFolderPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(savesFolderPath));
        }


        /**
        // check if save folder exist
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // if not, create it
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        */
    }

    public static void AutoSave(string saveString)
    {
        SaveAtSlot(saveString, 0);
    }

    public static void DeleteAutoSave()
    {
        string dataPath = GetFilePath("save_0");

        if (File.Exists(dataPath))
        {
            UnityEngine.Debug.Log("deleting auto save!");
            File.Delete(dataPath);
        }
    }

    public static bool HasAutoSave()
    {
        string dataPath = GetFilePath("save_0");

        if (File.Exists(dataPath))
        {
            return true;
        }
        return false;
    }
    public static void SaveAtSlot(string saveString, int slotIndex)
    {
        // get the data path of this save data
        string dataPath = GetFilePath("save_" + slotIndex);
        byte[] byteData;
        byteData = Encoding.ASCII.GetBytes(saveString);

        // create the file in the path if it doesn't exist
        // if the file path or name does not exist, return the default SO
        if (!Directory.Exists(Path.GetDirectoryName(dataPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
        }

        // slotIndex 0 -> AutoSave
        if (slotIndex > 10 || slotIndex < 0)
        {
            UnityEngine.Debug.LogWarning("the save slot does not exist!");
            return;
        }

        //File.WriteAllText(SAVE_FOLDER + "save_" + slotIndex + ".txt", saveString);

        // attempt to save here data
        try
        {
            // save datahere
            File.WriteAllBytes(dataPath, byteData);
            UnityEngine.Debug.Log("Save data to: " + dataPath);
        }
        catch (System.Exception e)
        {
            // write out error here
            UnityEngine.Debug.LogError("Failed to save data to: " + dataPath);
            UnityEngine.Debug.LogError("Error " + e.Message);
        }
    }

    /**
    // legacy save, as many as you can
    public static void Save(string saveString)
    {
        int saveNumber = 1;
        while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".txt"))
        {
            saveNumber++;
        }

        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", saveString);
    }
    */

    public static string Load(int fileId)
    {
        string dataPath = GetFilePath("save_" + fileId);

        // if the file path or name does not exist, return the default SO
        if (!Directory.Exists(Path.GetDirectoryName(dataPath)))
        {
            Debug.LogWarning("File or path does not exist! " + dataPath);
            return null;
        }
        // load in the save data as byte array
        byte[] jsonDataAsBytes = null;

        try
        {
            jsonDataAsBytes = File.ReadAllBytes(dataPath);
            Debug.Log("<color=green>Loaded all data from: </color>" + dataPath);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Failed to load data from: " + dataPath);
            Debug.LogWarning("Error: " + e.Message);
            return null;
        }

        if (jsonDataAsBytes == null)
            return null;

        // convert the byte array to json
        string jsonData;

        // convert the byte array to json
        jsonData = Encoding.ASCII.GetString(jsonDataAsBytes);

        return jsonData;

        /**
        if (File.Exists(dataPath))
        { // safe check
            // deserialize saved data and return
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save_" + fileId + ".txt");
            return saveString;
        }
        else
        {
            return null;
        }
        */
    }


    /// <summary>
    /// Create file path for where a file is stored on the specific platform given a folder name and file name
    /// </summary>
    /// <param name="FolderName"></param>
    /// <param name="FileName"></param>
    /// <returns></returns>
    private static string GetFilePath(string FileName = "")
    {
        string filePath;
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        // mac
        filePath = Path.Combine(Application.persistentDataPath, ("SavesData/"));

        if (FileName != "")
            filePath = Path.Combine(filePath, (FileName + ".txt"));
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        // windows
        filePath = Path.Combine(Application.persistentDataPath, ("SavesData/"));

        if(FileName != "")
            filePath = Path.Combine(filePath, (FileName + ".txt"));
#elif UNITY_ANDROID
        // android
        filePath = Path.Combine(Application.persistentDataPath, ("SavesData/"));

        if(FileName != "")
            filePath = Path.Combine(filePath, (FileName + ".txt"));
#elif UNITY_IOS
        // ios
        filePath = Path.Combine(Application.persistentDataPath, ("SavesData/"));

        if(FileName != "")
            filePath = Path.Combine(filePath, (FileName + ".txt"));
#endif
        return filePath;
    }

}
