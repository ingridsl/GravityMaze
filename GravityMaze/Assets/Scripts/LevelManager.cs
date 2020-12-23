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
        return GameObject.Find("GameManager").GetComponent(typeof(LevelManager)) as LevelManager;
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

    public void EndLevel()
    {
        CalculateStarsAmount();

        GameObject winGameObj = GameObject.Find("WinOrLose");
        if (winGameObj != null)
        {
            foreach (Transform child in winGameObj.transform)
            {
                if (child.name == "Win")
                {
                    child.gameObject.SetActive(true);
                    continue;
                }
            }

        }

        GameObject uiGameObj = GameObject.Find("UI");
        if (uiGameObj != null)
        {
            foreach (Transform child in uiGameObj.transform)
            {
                if (child.tag == "Alien")
                {
                    child.gameObject.SetActive(false);
                    PointManager.AddPoint();
                    GameManager gameManager = GameManager.GetGameManager();
                    if (gameManager)
                    {
                        gameManager.UpdateSave(levelNumber, startsAmount);
                    }
                    return;
                }
            }

        }
    }

    
}
