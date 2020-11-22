using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pointsOnLevel = 0;
    public int totalPointsOfLevel = 3;
    // Start is called before the first frame update
    void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = false;

        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    // Update is called once per frame
    void Update()
    {
        var teste = Screen.orientation;
    }
    
}
