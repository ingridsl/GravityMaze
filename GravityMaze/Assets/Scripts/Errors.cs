using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Errors
{
    enum ErrorCode
    {
        GameManagerNotFound,
        LevelManagerNotFound,
        GameControllerNotFound,
        SavePathDoesntExist
    }

    readonly static string gameManagerNotFound = "GameManager was not found";
    readonly static string levelManagerNotFound = "LevelManager was not found";
    readonly static string gameControllerNotFound = "GameController type of game object was not found";
    readonly static string savePathDoesntExist = "Save Path Doesnt Exist";

    public static void GameManagerNotFound()
    {
        Debug.LogError(ErrorCode.GameManagerNotFound + " : " + gameManagerNotFound);
    }
    public static void LevelManagerNotFound()
    {
        Debug.LogError(ErrorCode.LevelManagerNotFound + " : " + levelManagerNotFound);
    }
    public static void GameControllerNotFound()
    {
        Debug.LogError(ErrorCode.GameControllerNotFound + " : " + gameControllerNotFound);
    }
    public static void SavePathDoesntExist()
    {
        Debug.LogError(ErrorCode.SavePathDoesntExist + " : " + savePathDoesntExist);
    }
}
