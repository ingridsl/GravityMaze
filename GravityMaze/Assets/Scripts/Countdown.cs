﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    float currentTime = 0f;
    readonly float startingTime = Constants.COUNTDOWN_TIME;
    [SerializeField] Text countDownText;
    [SerializeField] Text levelNumberText;

    // Start is called before the first frame update
    void Start() 
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            Destroy(countDownText);
            Destroy(levelNumberText);
        }
    }

}
