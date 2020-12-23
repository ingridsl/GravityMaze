using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SaveData saveData = null;
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
        saveData = SaveData.LoadSave();
        if (saveData == null)
        {
            NewSave();
        }
    }
    public void UpdateSave(int currentLevel, int starsAmount)
    {
        saveData.nextLevel = currentLevel + 1;
        saveData.levelStars[currentLevel - 1] = starsAmount;
        saveData.Save();
    }

    public void NewSave()
    {
        saveData = SaveData.NewSave();
    }
}
