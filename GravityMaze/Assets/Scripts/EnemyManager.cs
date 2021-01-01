using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MovingObject
{
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager levelManager = LevelManager.GetLevelManager();
            if (levelManager != null)
            {
                levelManager.GameOver();
            }
        }
    }
}
