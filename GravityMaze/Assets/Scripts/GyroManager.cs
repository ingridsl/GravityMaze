using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        if (gyroActive)
        {
            return;
        }
        if (SystemInfo.supportsGyroscope)
        {

            gyro = Input.gyro;
            gyro.enabled = true;
            rotation = Quaternion.Euler(90f, -90f, 0f); //These offset values are essential for the gyroscope to orientate itself correctly
            gyroActive = gyro.enabled;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }        
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
