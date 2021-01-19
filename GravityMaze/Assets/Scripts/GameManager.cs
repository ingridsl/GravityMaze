using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public SaveData saveData = null;

    void Awake()
    {

        Debug.Log("GAME MANAGER Awake");
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
        if (Screen.orientation != ScreenOrientation.LandscapeRight) {
            Screen.orientation = ScreenOrientation.LandscapeRight;
            Debug.Log(Screen.orientation.ToString());
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
        saveData.levelStars[currentLevel - 1] = starsAmount;
        saveData.Save();
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
