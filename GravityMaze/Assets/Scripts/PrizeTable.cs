using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeTable : MonoBehaviour
{
    GameManager gameManager = null;
    int selectedBall = 0;
    int starsTotal = 0;

    public Text starsTotalText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager == null)
        {
            Errors.GameManagerNotFound();
        }
        else if (gameManager && gameManager.saveData != null)
        {
            SetSelectedBall();
        }

        CalculateStarsTotal();
        EnablePossibleBalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateStarsTotal()
    {
        foreach (int starAmount in gameManager.saveData.levelStars)
        {
            starsTotal += starAmount;
        }
        foreach (int starAmount in gameManager.saveData.newLevelStars)
        {
            starsTotal += starAmount;
        }        
        starsTotalText.text = starsTotal.ToString();
    }

    void EnablePossibleBalls()
    {
        foreach (Transform childNumber in this.transform)
        {
            foreach (Transform childButton in childNumber.transform)
            {
                foreach (Transform buttonContents in childButton.transform)
                {
                    if (buttonContents.transform.name == "Text")
                    {
                        var starsText = buttonContents.GetComponentInChildren<Text>();
                        if (Int32.Parse(starsText.text) <= starsTotal)
                        {
                            childButton.GetComponent<Button>().interactable = true;
                        }
                    }
                }
            }
        }
    }

    void SetSelectedBall()
    {
        selectedBall = gameManager.saveData.selectedBall;
        foreach (Transform childNumber in this.transform)
        {
            if (childNumber.transform.name == selectedBall.ToString())
            {

                foreach (Transform childButton in childNumber.transform)
                {
                    PrizeManagement prizeManagement = childButton.GetComponent<PrizeManagement>();
                    prizeManagement.SetSelectedBall(childButton.transform, gameManager);
                }
            }
        }
    }

}
