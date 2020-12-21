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
        var anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Star3");

        var levelManager = LevelManager.GetLevelManager();
        float totalPointsLevel = levelManager.totalPointsOfLevel;
        float pointsPlayer = levelManager.pointsOnLevel;

        var successRate = (pointsPlayer / totalPointsLevel) * 100;
        Star1.transform.GetComponent<Image>().sprite = GoldenStar;
        if (successRate >= 40)
        {
            Star2.transform.GetComponent<Image>().sprite = GoldenStar;
            if (successRate >= 90)
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
