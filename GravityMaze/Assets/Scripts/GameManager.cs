using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public SaveData saveData = null;
    string googlePlayId = "4008693";
    bool testMode = false;

    public Sprite[] ballsList;

    void Awake()
    {
        Debug.Log("GAME MANAGER Awake");
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void Start()
    {
        Advertisement.Initialize(googlePlayId, testMode);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Screen.orientation = ScreenOrientation.LandscapeRight;

        Debug.Log("first time : " + Screen.orientation.ToString());
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;

        if (sceneName == "MainMenu")
        {
            LoadSave();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Screen.orientation == ScreenOrientation.LandscapeRight 
        //    /*&& saveData.orientation == Constants.LandscapeLEFT*/)
        //{

        //    Screen.orientation = ScreenOrientation.LandscapeLeft;

        //    Debug.Log("HAD TO CHANGE : " + Screen.orientation.ToString() 
        //        + " AUTOROTATE PORTRAIT : " + Screen.autorotateToPortrait);
        //    Screen.autorotateToLandscapeRight = false;
        //    Screen.autorotateToLandscapeLeft = true;
        //}
        //else if (Screen.orientation == ScreenOrientation.LandscapeLeft
        //    /*&& saveData.orientation == Constants.LandscapeRIGHT*/)
        //{
        //    Screen.orientation = ScreenOrientation.LandscapeRight;

        //    Debug.Log("HAD TO CHANGE : " + Screen.orientation.ToString()
        //        + " AUTOROTATE PORTRAIT : " + Screen.autorotateToPortrait);
        //    Screen.autorotateToLandscapeRight = true;
        //    Screen.autorotateToLandscapeLeft = false;
        //}

         if (Screen.orientation != ScreenOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;

            Debug.Log("HAD TO CHANGE : " + Screen.orientation.ToString());
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
        }
    }

    static public GameManager GetGameManager()
    {
        GameManager gameManagerObj = null;
        try
        {
            gameManagerObj = GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        return gameManagerObj;
    }

    public static void OpenLoading()
    {
        GameObject loadingObj = GameObject.Find("Loading");
        if (loadingObj != null)
        {
            foreach (Transform child in loadingObj.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public static void CloseLoading()
    {
        GameObject loadingObj = GameObject.Find("Loading");
        if (loadingObj != null)
        {
            foreach (Transform child in loadingObj.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void LoadSave()
    {
        saveData = SaveData.LoadSave();
        if (saveData == null)
        {
            NewSave();
        }
    }

    public void UpdateSave(int currentLevel, int nextPlayable, int starsAmount)
    {
        saveData.nextLevel = nextPlayable;
        if (saveData.levelStars[currentLevel - 1] < starsAmount) {
            saveData.levelStars[currentLevel - 1] = starsAmount;
            saveData.Save();
        }
    }

    public void NewSave()
    {
        saveData = SaveData.NewSave();
    }

    public void SetPausableObjectsMovement(bool canMove)
    {
        GameObject pausableGameObj = GameObject.Find("Pausable");
        if (pausableGameObj != null)
        {
           
            var obstaclesAnimator = pausableGameObj.GetComponent<Animator>();
            if (obstaclesAnimator != null) {
                obstaclesAnimator.enabled = canMove;
                if (canMove)
                {
                    obstaclesAnimator.Play("Entry", 0);
                }
            }

            foreach (Transform child in pausableGameObj.transform)
            {
                if (child.transform.tag == "Player")
                {
                    child.GetComponent<FollowGyro>().canMove = canMove;
                }
                else if (child.transform.tag == "Enemy")
                {
                    child.GetComponent<EnemyManager>().canMove = canMove;

                    var enemyAnimator = child.GetComponent<Animator>();
                    enemyAnimator.enabled = canMove;
                }
            }
        }
    }

    public void StopBackgroundMusic()
    {
        GameObject musicGameObj = GameObject.Find("Music");
        var musicComponent = musicGameObj.GetComponent<AudioSource>();
        if (musicComponent != null) {
            musicComponent.Pause();
        }
    }
}
