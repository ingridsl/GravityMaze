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
        Debug.Log(Screen.orientation.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //var teste = Screen.orientation;
        Debug.Log(Screen.orientation.ToString());
    }

    static public GameManager GetGameManager()
    {
        return GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;
    }
}
