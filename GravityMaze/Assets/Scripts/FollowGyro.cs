
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
            //gyro x is map y. gyro y is map x
            float moveBallX = (Mathf.Abs(gyroMovement.y) > idleProtectionX) ?
                                    gyroMovement.y : 0f;
            float moveBallY = (Mathf.Abs(gyroMovement.x) > idleProtectionY) ?
                                    gyroMovement.x : 0f;

            Vector2 movement = new Vector2(-moveBallX * speed, moveBallY * speed);
            Vector2 finalPosition = rb2d.position + movement * Time.fixedDeltaTime;
            if (Mathf.Abs(finalPosition.y) > limitXY)
            {
                finalPosition.y = rb2d.position.y;
            }
            else if (Mathf.Abs(finalPosition.x) > limitXY)
            {
                finalPosition.x = rb2d.position.x;
            }


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
