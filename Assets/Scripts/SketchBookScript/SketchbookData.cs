using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SketchbookData
{
    public static BookNote[,] bookNotes2DArray; // 2D array of BookNote
    public static int maxPage = 11;
    public static SketchBookSpritesScriptableObject sketchBookSprites;
    public static int currPage = 0;

    static SketchbookData()
    {
        CreateBook();
    }
    private static void CreateBook()
    {
        UnityEngine.Debug.Log("create sketchbook data");
        sketchBookSprites = Resources.Load<SketchBookSpritesScriptableObject>("SketchBookSpritesScriptableObject");
        // create book data structure
        bookNotes2DArray = new BookNote[maxPage, 4];
        for (int i = 0; i < maxPage; i++)
        {
            for (int j = 0; j < 4; j++)
            {

                Sprite s = null;
                bool exist = false;
                bool unlocked = false;
                if (i == 0 || i == 1)
                {
                    // first two pages initially unlocked
                    unlocked = true;
                }

                if (sketchBookSprites.pages.Length > i && sketchBookSprites.pages[i].notes.Length > j)
                {
                    s = sketchBookSprites.pages[i].notes[j];
                    exist = true;
                }

                bookNotes2DArray[i, j] = new BookNote
                {
                    sprite = s,
                    unlocked = unlocked,
                    exist = exist
                };
                //UnityEngine.Debug.Log("create note at: " + i + ", " + j);
            }
        }
    }

    public static bool[] GetNoteUnlockedSaveArray()
    {
        bool[] saveArray = new bool[maxPage * 4];

        for (int i = 0; i < maxPage; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                // UnityEngine.Debug.Log("about to save note unlocked state at: " + i + ", " + j);
                saveArray[i * 4 + j] = bookNotes2DArray[i, j].unlocked;
            }
        }

        return saveArray;
    }

    public static void LoadNotesUnlockedStates(bool[] saveArray)
    {

        for (int i = 0; i < maxPage; i++)
        {
            for (int j = 0; j < 4; j++)
            {

                bookNotes2DArray[i, j].unlocked = saveArray[i * 4 + j];

            }
        }
    }

}
