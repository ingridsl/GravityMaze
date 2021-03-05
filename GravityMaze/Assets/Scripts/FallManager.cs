using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    public bool up = false;
    GameManager gameManager = null;

    bool falling = false;

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
            gameManager.SetPausableObjectsMovement(false);
            falling = true;
            Vector2 movement = new Vector2();
            if (up)
            {
                movement = new Vector2(0, 30);
            }
            else
            {
                movement = new Vector2(0, -30);
            }
            Vector2 finalPosition = rb2d.position + movement * Time.fixedDeltaTime;
            rb2d.MovePosition(finalPosition);
            StartCoroutine(OpenGameOverMenu());
        }
    }

    IEnumerator OpenGameOverMenu()
    {

        LevelManager levelManager = LevelManager.GetLevelManager();
        levelManager.HideScreenRemovables();
        yield return new WaitForSeconds(3);
        falling = false;
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
