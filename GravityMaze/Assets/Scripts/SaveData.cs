using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData: MonoBehaviour
{
    public int nextLevel = 1;
    public int[] levelStars = new int[] {
                                        0, 0, 0, 0, 0, //5
                                        0, 0, 0, 0, 0, //10
                                        0, 0, 0, 0, 0, //15
                                        };

    public SaveData NewSave()
    {
        SaveData saveData = new SaveData();
        var teste = Application.persistentDataPath;
        string saveStatePath = Path.Combine(Application.persistentDataPath, "playerSave.json");
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(saveData, true));
        return saveData;
    }

    public static void SaveProgress(int currentLevel, int thisLevelPoints)
    {
        SaveData saveData = new SaveData
        {
            nextLevel = currentLevel + 1
        };
        saveData.levelStars[currentLevel-1] = thisLevelPoints;

        var teste = Application.persistentDataPath;
        string saveStatePath = Path.Combine(Application.persistentDataPath , "playerSave.json");
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(saveData, true));
    }
}
