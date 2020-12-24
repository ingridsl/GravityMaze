using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public AudioSource audioSource;

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
            audioSource.Play();
            this.gameObject.SetActive(false);
            AddPoint();
        }
    }

    public static void AddPoint()
    {
        var levelManager = LevelManager.GetLevelManager();
        if (levelManager != null)
        {
            levelManager.pointsOnLevel++;
        }
    }
}
