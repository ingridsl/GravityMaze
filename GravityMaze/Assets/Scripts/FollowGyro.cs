
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MovingObject
{ 
    [Header("Logic")]
    private Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;

    // Range option so moveSpeedModifier can be modified in Inspector 
    // this variable helps to simulate objects acceleration
    [Range(0.002f, 2f)]
    public float moveSpeedModifier = 0.002f;

    // Direction variables that read acceleration input to be added
    // as velocity to Rigidbody2d component
    float dirX, dirY;

    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager.saveData.selectedBall != 0) {
            spriteRenderer.sprite = gameManager.ballsList[gameManager.saveData.selectedBall-1];
        }

        StartCoroutine(StartAfterTime(Constants.COUNTDOWN_TIME));
    }

    IEnumerator StartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //GyroManager.Instance.EnableGyro();
        rb2d = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && rb2d != null)
        {
            // Getting devices accelerometer data in X and Y direction
            // multiplied by move speed modifier
            dirX = Input.acceleration.x * moveSpeedModifier * gameManager.saveData.sensitivity;
            dirY = Input.acceleration.y * moveSpeedModifier * gameManager.saveData.sensitivity;
            
            rb2d.velocity = new Vector2(rb2d.velocity.x + dirX, rb2d.velocity.y + dirY);
        }
        else if(rb2d != null)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "End")
        {
            GameObject winGameObj = GameObject.Find("WinOrLose");
            if (winGameObj != null)
            {
                if (winGameObj.transform.name == "Win")
                {
                    winGameObj.transform.gameObject.SetActive(true);
                };
            }
        }
    }
}
