using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

public class SettingsAutoConverter : AssetPostprocessor
{
    static Dictionary<string, Action> parsers;

    static SettingsAutoConverter()
    {
        parsers = new Dictionary<string, Action>();
        parsers.Add("FishDB.csv", ParseEnemies);
    }

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        for (int i = 0; i < importedAssets.Length; i++)
        {
            string fileName = Path.GetFileName(importedAssets[i]);
            if (parsers.ContainsKey(fileName))
                parsers[fileName]();
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    static void ParseEnemies()
    {
        string filePath = Application.dataPath + "/Settings/FishDB.csv";
        if (!File.Exists(filePath))
        {
            Debug.LogError("Missing Fish Data: " + filePath);
            return;
        }

        string[] readText = File.ReadAllLines("Assets/Settings/FishDB.csv");
        filePath = "Assets/Settings/Resources/";
        for (int i = 1; i < readText.Length; ++i)
        {
            FishScriptable fishData = ScriptableObject.CreateInstance<FishScriptable>();
            fishData.LoadData(readText[i]);
            string fileName = string.Format("{0}{1}.asset", filePath, fishData.name);
            AssetDatabase.CreateAsset(fishData, fileName);
        }
    }
}