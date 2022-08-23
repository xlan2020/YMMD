using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MH.Mumbler
{
    [InitializeOnLoad]
    public class VersionCheck
    {
        public const string CURRENT_VERSION = "0.7";

        static VersionCheck()
        {
            string prefVer = EditorPrefs.GetString(PREF_KEY);
            if (prefVer != CURRENT_VERSION)
            {
                CommonAttributeProcessor.RefreshAll();
                EditorPrefs.SetString(PREF_KEY, CURRENT_VERSION);
                Dbg.Log("Refresh Settings for StartPak v" + CURRENT_VERSION);
            }
        }

        public const string PREF_KEY = "MH.Mumbler.Version";
    }
}