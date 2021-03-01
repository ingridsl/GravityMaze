using System.Collections;
using UnityEngine;

public class EnemyManager : MovingObject
{
    public bool isBomb = false;
    public Transform enemyEatingPrefab;
    public Transform bombExplodingPrefab; 

    GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.SetPausableObjectsMovement(false);
            if (!isBomb)
            {
                Instantiate(enemyEatingPrefab);
            }
            else
            {
                Instantiate(bombExplodingPrefab);
            }
            StartCoroutine(openGameOverMenu());
        }
    }

    IEnumerator openGameOverMenu()
    {
        LevelManager levelManager = LevelManager.GetLevelManager();
        levelManager.HideScreenRemovables();
        yield return new WaitForSeconds(3);

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
