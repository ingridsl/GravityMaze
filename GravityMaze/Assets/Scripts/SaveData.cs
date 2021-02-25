using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public int nextLevel = 1;
    public int[] levelStars = new int[] {
                                        0, 0, 0, 0, 0, //5
                                        0, 0, 0, 0, 0, //10
                                        0, 0, 0, 0, 0, //15
                                        0, 0, 0, 0, 0, //20
                                        };
    public float sensitivity = 100.0f;
    public int orientation = 1;
    public bool alienOnScreen = true;

    static public SaveData NewSave()
    {
        SaveData saveData = new SaveData();
        try
        {

            var path = Application.persistentDataPath;
            Debug.Log("Saving game on path : " + path);
            string saveStatePath = Path.Combine(path, "playerSave.json");
            File.WriteAllText(saveStatePath, JsonUtility.ToJson(saveData, true));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        return saveData;
    }

    public void Save()
    {
        try
        {
            var path = Application.persistentDataPath;
            Debug.Log("Saving game on path : " + path);
            string saveStatePath = Path.Combine(path, "playerSave.json");
            File.WriteAllText(saveStatePath, JsonUtility.ToJson(this, true));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public static SaveData LoadSave()
    {
        string path = Application.persistentDataPath + "/playerSave.json";
        Debug.Log("Loading game from path : " + path);
        if (File.Exists(path))
        {
            try
            {
                var loadedGame = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
                return loadedGame;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        return null;
    }
}
