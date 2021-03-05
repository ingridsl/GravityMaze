using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public AudioSource audioSource;
    static LevelManager levelManager = null;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.GetLevelManager();
        if(levelManager == null)
        {
            Errors.LevelManagerNotFound();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioSource.Play();
            this.gameObject.SetActive(false);
            AddPoint();
        }
    }

    public static void AddPoint()
    {
        levelManager = LevelManager.GetLevelManager();
        if (levelManager != null)
        {
            levelManager.pointsOnLevel++;
        }
        else
        {
            Errors.LevelManagerNotFound();
        }
    }
}
