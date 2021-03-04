using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManagement : MonoBehaviour
{
    public GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetSelectedBall(Transform childButton, GameManager gameManager)
    {
        foreach (Transform buttonContents in childButton)
        {
            if (buttonContents.transform.name == "SelectedImage")
            {
                buttonContents.gameObject.SetActive(true);
                GameManager.OpenLoading();
                StartCoroutine(GameManager.CloseLoadingCoroutine());
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
        gameManager.saveData.selectedBall = Int32.Parse(this.transform.parent.name);
        gameManager.saveData.Save();
        SetSelectedBall(this.transform, gameManager);
    }
}
