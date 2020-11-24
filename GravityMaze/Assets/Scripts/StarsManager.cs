using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{

    public Sprite EmptyStar;
    public Sprite GoldenStar;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameManager.GetGameManager();
        float totalPointsLevel = gameManager.totalPointsOfLevel;
        float pointsPlayer = gameManager.pointsOnLevel;

        var successRate = (pointsPlayer / totalPointsLevel) * 100;
        Star1.transform.GetComponent<Image>().sprite = GoldenStar;
        if (successRate >= 40)
        {
            Star2.transform.GetComponent<Image>().sprite = GoldenStar;
            if (successRate >= 80)
            {
                Star3.transform.GetComponent<Image>().sprite = GoldenStar;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
