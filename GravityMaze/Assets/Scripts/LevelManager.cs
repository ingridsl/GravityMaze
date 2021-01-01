using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int pointsOnLevel = 0;
    public int totalPointsOfLevel = 3; //amount of energy + 1 victory point
    public int levelNumber = 0;
    public int startsAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    static public LevelManager GetLevelManager()
    {
        return GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
    }

    public void CalculateStarsAmount()
    {
        float pointsPlayer = pointsOnLevel;

        var successRate = (pointsPlayer / totalPointsOfLevel) * 100;
        startsAmount = 1;
        if (successRate >= 40)
        {
            startsAmount++;
            if (successRate >= 90)
            {
                startsAmount++;
            }
        }
    }

    public void VictoryOrLoseScreen(bool victory)
    {
        GameObject outcomeGameObj = GameObject.Find("WinOrLose");
        if (outcomeGameObj != null)
        {
            foreach (Transform child in outcomeGameObj.transform)
            {
                string outcome = victory ? "Win" : "Lose";
                if (child.name == outcome)
                {
                    child.gameObject.SetActive(true);
                    return;
                }
            }

        }
    }

    public void HideScreenAlien()
    {
        var aliens = GameObject.FindGameObjectsWithTag("Alien");
        if (aliens != null)
        {
            aliens[0].SetActive(false);
        }
    }


    public void EndLevel()
    {
        PointManager.AddPoint();
        CalculateStarsAmount();
        VictoryOrLoseScreen(true);
        HideScreenAlien();

        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager)
        {
            var nextPlayable = levelNumber >= gameManager.saveData.nextLevel ?
                                    levelNumber + 1 :
                                    gameManager.saveData.nextLevel;
            gameManager.UpdateSave(levelNumber, nextPlayable, startsAmount);
            gameManager.SetPausableObjectsMovement(false);
        }
    }

    public void GameOver()
    {
        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager)
        {
            gameManager.SetPausableObjectsMovement(false);
        }

        startsAmount = 0;
        pointsOnLevel = 0;

        HideScreenAlien();
        VictoryOrLoseScreen(false);
    }

}
