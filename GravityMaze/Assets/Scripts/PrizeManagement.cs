using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void SetSelectedBall(Transform childButton)
    {
        foreach (Transform buttonContents in childButton)
        {
            if (buttonContents.transform.name == "SelectedImage")
            {
                buttonContents.gameObject.SetActive(true);
            }
        }
    }

    public void SelectBall()
    {
        foreach (var selectedImagesObj in GameObject.FindGameObjectsWithTag("SelectedBallCircle"))
        {
            if (selectedImagesObj.gameObject.activeSelf)
            {
                selectedImagesObj.SetActive(false);
            }
        }
        SetSelectedBall(this.transform);
    }
}
