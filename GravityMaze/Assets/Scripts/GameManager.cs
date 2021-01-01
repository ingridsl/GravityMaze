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
            obstaclesAnimator.enabled = false;

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
                    enemyAnimator.enabled = false;
                }
            }
        }
    }
}
