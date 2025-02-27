﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            LevelManager levelManager = LevelManager.GetLevelManager();
            if (levelManager != null)
            {
                levelManager.EndLevel();
            }
            else
            {
                Errors.LevelManagerNotFound();
            }
        }

    }
}
