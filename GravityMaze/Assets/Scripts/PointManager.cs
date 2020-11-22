using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
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
            this.gameObject.SetActive(false);
            AddPoint();
        }
    }

    public static void AddPoint()
    {
        var player = GameObject.Find("Ball");
        if (player != null)
        {
            var playerManager = player.GetComponent<GameManager>();
            if (playerManager != null)
            {
                playerManager.pointsOnLevel++;
            }
        }
    }
}
