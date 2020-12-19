
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{ 
    [Header("Logic")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Quaternion gyroMovement = new Quaternion(0, 0, 1, 0);
    private Rigidbody2D rb2d;
    public float speed = 15;

    private readonly float idleProtectionY = 0.03f;
    private readonly float idleProtectionX = 0.03f;

    private readonly float limitXY = 4.7f;

    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
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
            float moveBallX = (Mathf.Abs(gyroMovement.x) > idleProtectionX) ?
                                    gyroMovement.x : 0f;
            float moveBallY = (Mathf.Abs(gyroMovement.y) > idleProtectionY) ?
                                    gyroMovement.y : 0f;

            Vector2 movement = new Vector2(-moveBallX * speed, -moveBallY * speed);
            Vector2 finalPosition = rb2d.position + movement * Time.fixedDeltaTime;
            if (Mathf.Abs(finalPosition.y) > limitXY)
            {
                finalPosition.y = rb2d.position.y;
            }
            else if (Mathf.Abs(finalPosition.x) > limitXY)
            {
                finalPosition.x = rb2d.position.x;
            }
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
