using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEssential
{
    public static GameLanguage language = GameLanguage.CH;
    public static int currentSave = 0;

}

public enum GameLanguage
{
    CH,
    EN
}