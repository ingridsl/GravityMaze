using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = false;

        Screen.orientation = ScreenOrientation.LandscapeRight;
        Debug.Log(Screen.orientation.ToString());
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            LoadSave();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //var teste = Screen.orientation;
        //Screen.orientation = ScreenOrientation.LandscapeRight;
        //Debug.Log(Screen.orientation.ToString());
    }

    static public GameManager GetGameManager()
    {
        return GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;
    }

    public void LoadSave()
    {
        SaveData save = SaveData.LoadSave();
        if (save == null)
        {
            NewSave();
        }
    }
    public void UpdateSave(int currentLevel, int pointsOnLevel)
    {
        SaveData saveData = new SaveData
        {
            nextLevel = currentLevel + 1
        };
        saveData.levelStars[currentLevel - 1] = pointsOnLevel;
        saveData.Save();
    }

    public void NewSave()
    {
        SaveData.NewSave();
    }
}
