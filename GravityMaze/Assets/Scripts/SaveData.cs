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
                                        };
    public float sensitivity = 100.0f;

    static public SaveData NewSave()
    {
        SaveData saveData = new SaveData();
        var teste = Application.persistentDataPath;
        string saveStatePath = Path.Combine(Application.persistentDataPath, "playerSave.json");
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(saveData, true));
        return saveData;
    }

    public void Save()
    {        
        var teste = Application.persistentDataPath;
        string saveStatePath = Path.Combine(Application.persistentDataPath , "playerSave.json");
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(this, true));
    }

    public static SaveData LoadSave()
    {
        string path = Application.persistentDataPath + "/playerSave.json";
        if (File.Exists(path))
        {
            var loadedGame = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            return loadedGame;
        }
        return null;
    }
}
