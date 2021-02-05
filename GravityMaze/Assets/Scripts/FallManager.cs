using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    public bool up = false;
    GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager == null)
        {
            Errors.GameManagerNotFound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D rb2d = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 movement = new Vector2();
            if (up)
            {
                movement = new Vector2(0, 3);
            }
            else
            {
                movement = new Vector2(0, -3);
            }
            Vector2 finalPosition = rb2d.position + movement * Time.fixedDeltaTime;
            rb2d.MovePosition(finalPosition);



            gameManager.SetPausableObjectsMovement(false);

            StartCoroutine(openGameOverMenu());
        }
    }

    IEnumerator openGameOverMenu()
    {
        yield return new WaitForSeconds(3);

        LevelManager levelManager = LevelManager.GetLevelManager();
        if (levelManager != null)
        {
            levelManager.GameOver();
        }
        else
        {
            Errors.LevelManagerNotFound();
        }
    }
}
