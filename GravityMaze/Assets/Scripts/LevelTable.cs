using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTable : MonoBehaviour
{

    public Sprite GoldenStar;

    // Start is called before the first frame update
    void Start()
    {
        EnableLevels();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableLevels()
    {
        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager)
        {
            GameObject levelTable = GameObject.Find("LevelTable");
            if (levelTable != null)
            {
                foreach (Transform child in levelTable.transform)
                {
                    int levelNumber = Int16.Parse(child.name);
                    if (levelNumber <= gameManager.saveData.nextLevel) //this level was already played or is the next level
                    {
                        child.gameObject.SetActive(true);
                        foreach (Transform child2 in child.gameObject.transform)
                        {
                            if (gameManager.saveData.levelStars[levelNumber - 1] == 0)
                            {
                                break;
                            }
                            else if (child2.gameObject.name == "Star1" &&
                                gameManager.saveData.levelStars[levelNumber - 1] >= 1) //if have this star, give it to player
                            {
                                // give star
                                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                                continue;
                            }
                            else if (child2.gameObject.name == "Star2" &&
                                gameManager.saveData.levelStars[levelNumber - 1] >= 2) //if have this star, give it to player
                            {
                                // give star
                                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                                continue;
                            }
                            else if (child2.gameObject.name == "Star3" &&
                                gameManager.saveData.levelStars[levelNumber - 1] == 3) //if have this star, give it to player
                            {
                                // give star
                                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                                break;
                            }
                        }
                    }
                    if (Int16.Parse(child.name) > gameManager.saveData.nextLevel) //this level is locked
                    {
                        break;
                    }
                }

            }
        }
    }
}
