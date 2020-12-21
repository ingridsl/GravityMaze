using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int pointsOnLevel = 0;
    public int totalPointsOfLevel = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    static public LevelManager GetLevelManager()
    {
        return GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
    }

    static public void EndLevel()
    {

    }
}
