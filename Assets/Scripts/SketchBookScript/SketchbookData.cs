using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SketchbookData
{
    public static BookNote[,] bookNotes2DArray; // 2D array of BookNote
    public static int maxPage;

    public static bool[] GetNoteUnlockedSaveArray(){

        bool[] saveArray = new bool[maxPage * 4];

        for (int i = 0; i < maxPage; i++){
            for (int j = 0; j < 4; j++){
                // UnityEngine.Debug.Log("about to save note unlocked state at: " + i + ", " + j);
                saveArray[i * 4 + j] = bookNotes2DArray[i, j].unlocked;
            }
        }

        return saveArray;
    }

    public static void LoadNotesUnlockedStates(bool[] saveArray){

        for (int i = 0; i< maxPage; i++){
            for (int j = 0; j < 4; j++){

                bookNotes2DArray[i, j].unlocked = saveArray[i * 4 + j];

            }
        }
    }
}
