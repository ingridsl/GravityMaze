using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeTable : MonoBehaviour
{
    public GameManager gameManager = null;

    int selectedBall = 0;
    int starsTotal = 0;

    public Text starsTotalText;

    // Start is called before the first frame update
    void Start()
    {
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
        starsTotalText.text = starsTotal.ToString();
    }

    void EnablePossibleBalls()
    {

    }

    void SetSelectedBall()
    {
        selectedBall = gameManager.saveData.selectedBall;
    }
}
