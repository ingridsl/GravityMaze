
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGyro : MonoBehaviour
{
    [Header("Logic")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Quaternion gyroMovement = new Quaternion(0, 0, 1, 0);
    private SpriteRenderer star;
    public float speed = 1;

    private readonly float idleProtectionY = 0.06f;
    private readonly float idleProtectionX = 0.06f;

    private readonly float limitX = 12f;
    private readonly float limitY = 6f;

    public bool isMovingX = true;
    public bool isMovingY = true;

    // Start is called before the first frame update
    void Start()
    {
        GyroManager.Instance.EnableGyro();
        star = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gyroMovement = GyroManager.Instance.GetGyroRotation() * baseRotation;
        //gyro x is map y. gyro y is map x

        if (Mathf.Abs(gyroMovement.y) > idleProtectionY || Mathf.Abs(gyroMovement.x) > idleProtectionX)
        {
            float moveX = -gyroMovement.y;
            float moveY = gyroMovement.x;
            if (/*Mathf.Abs(star.transform.position.x + (moveX * speed)) > limitX &&*/ !isMovingX)
            {
                moveX = 0;
            }
            if (/*Mathf.Abs(star.transform.position.y + (moveY * speed)) > limitY &&*/ !isMovingY)
            {
                moveY = 0;
            }
            Vector2 movement = new Vector2(star.transform.position.x + (moveX * speed), star.transform.position.y + (moveY * speed));
            star.transform.position = movement;
        }
    }
}
