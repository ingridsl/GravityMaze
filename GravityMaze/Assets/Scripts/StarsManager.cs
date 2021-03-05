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
        ChangeStars();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ChangeStars()
    {
        var levelManager = LevelManager.GetLevelManager();

        if (levelManager != null)
        {
            Star1.transform.GetComponent<Image>().sprite = GoldenStar;
            if (levelManager.startsAmount >= 2)
            {
                Star2.transform.GetComponent<Image>().sprite = GoldenStar;
                if (levelManager.startsAmount == 3)
                {
                    Star3.transform.GetComponent<Image>().sprite = GoldenStar;
                }
            }
        }
        else
        {
            Errors.LevelManagerNotFound();
        }
    }    
}
