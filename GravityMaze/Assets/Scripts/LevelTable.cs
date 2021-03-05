using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTable : MonoBehaviour
{
    public Sprite GoldenStar;
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager == null)
        {
            Errors.GameManagerNotFound();
        }

        EnableLevels();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableLevels()
    {
        if (gameManager != null)
        {
            GameObject levelTable = GameObject.Find("LevelTable");
            if (levelTable != null)
            {
                foreach (Transform child in levelTable.transform)
                {
                    int levelNumber = Int16.Parse(child.name);
                    if (levelNumber <= gameManager.saveData.nextLevel) //this level was already played or is the next level
                    {
                        foreach (Transform buttonChild in child.transform)
                        {
                            if (buttonChild.tag == "Button")
                            {
                                buttonChild.GetComponent<Button>().interactable = true;
                            }
                        }

                        //child.gameObject.SetActive(true);
                        //if (levelNumber <= 15) {
                            LevelStars(gameManager.saveData.levelStars, levelNumber, child);
                        //}
                       // else
                       // {
                            LevelStars(gameManager.saveData.newLevelStars, levelNumber, child);
                      //  }
                    }

                    if (Int16.Parse(child.name) > gameManager.saveData.nextLevel) //this level is locked
                    {
                        break;
                    }
                }

            }
        }
        else
        {
            Errors.GameManagerNotFound();
        }
    }

    void LevelStars(int[] levelStars, int levelNumber, Transform child)
    {
        int difference = levelNumber <= 15 ? 1 : 16;
        foreach (Transform child2 in child.gameObject.transform)
        {
            if (levelStars[levelNumber - difference] == 0)
            {
                break;
            }

            else if (child2.gameObject.name == "Star1" &&
                levelStars[levelNumber - difference] >= 1) //if have this star, give it to player
            {
                // give star
                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                continue;
            }
            else if (child2.gameObject.name == "Star2" &&
                levelStars[levelNumber - difference] >= 2) //if have this star, give it to player
            {
                // give star
                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                continue;
            }
            else if (child2.gameObject.name == "Star3" &&
                levelStars[levelNumber - difference] == 3) //if have this star, give it to player
            {
                // give star
                child2.gameObject.transform.GetComponent<Image>().sprite = GoldenStar;
                break;
            }
        }
    }
}
