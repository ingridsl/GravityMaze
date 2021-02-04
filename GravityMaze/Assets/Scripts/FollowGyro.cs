
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MovingObject
{ 
    [Header("Logic")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Quaternion gyroMovement = new Quaternion(0, 0, 1, 0);
    private Rigidbody2D rb2d;
    public float speed = 15;


    private float idleProtectionY = Constants.MaximumIdleProtection;
    private float idleProtectionX = Constants.MaximumIdleProtection;
    private readonly float limitXY = 4.7f;
    
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        idleProtectionY = Constants.MaximumIdleProtection / (gameManager.saveData.sensitivity / 100);
        idleProtectionX = Constants.MaximumIdleProtection / (gameManager.saveData.sensitivity / 100);
        StartCoroutine(StartAfterTime(Constants.COUNTDOWN_TIME));
    }

    IEnumerator StartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        GyroManager.Instance.EnableGyro();
        rb2d = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            gyroMovement = GyroManager.Instance.GetGyroRotation() * baseRotation;

            float absGyroX = Mathf.Abs(gyroMovement.x);
            float absGyroY = Mathf.Abs(gyroMovement.y);


            float moveBallY = (absGyroY > idleProtectionY) ?
                                    gyroMovement.y : 0f;
            float moveBallX = (absGyroX > idleProtectionX) ?
                                    gyroMovement.x : 0f;
            Debug.Log(" gyroMovementX: " + gyroMovement.x + "gyroMovementY: " + gyroMovement.y);

            float speedX = absGyroY > absGyroX ? speed / (2 * (absGyroY / absGyroX)) : speed;
            float speedY = absGyroX > absGyroY ? speed / (2 * (absGyroX / absGyroY)) : speed;

            Vector2 movement = new Vector2();
            if (Screen.orientation == ScreenOrientation.LandscapeRight){
                movement = new Vector2(moveBallX * speedX, moveBallY * speedY);
            }
            else
            {
                movement = new Vector2(-moveBallX * speedX, -moveBallY * speedY);
            }
            Vector2 finalPosition = rb2d.position + movement * Time.fixedDeltaTime;

            Debug.Log("final position : " + finalPosition.ToString() 
                + " current position : " + rb2d.position
                + "gyromovement : " + gyroMovement.ToString());
            rb2d.MovePosition(finalPosition);
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
