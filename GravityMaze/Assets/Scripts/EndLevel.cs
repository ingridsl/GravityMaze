using System.Collections;
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
            GameObject winGameObj = GameObject.Find("WinOrLose");
            if (winGameObj != null)
            {
                foreach (Transform child in winGameObj.transform)
                {
                    if (child.name == "Win")
                    {
                        child.gameObject.SetActive(true);
                        continue;
                    }
                }

            }

            GameObject uiGameObj = GameObject.Find("UI");
            if (uiGameObj != null)
            {
                foreach (Transform child in uiGameObj.transform)
                {
                    if (child.tag == "Alien")
                    {
                        child.gameObject.SetActive(true);
                        return;
                    }
                }

            }
        }
    }
}
