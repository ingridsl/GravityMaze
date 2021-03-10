using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public bool isTutorial = false;
    GameManager gameManager = null;
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
        if (Input.GetMouseButtonDown(0) && isTutorial)
        {
            CloseTutorialClick();
        }
    }

    public void CloseTutorialClick()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");

        GameObject pausableGameObj = GameObject.Find("Pausable");
        if (pausableGameObj != null)
        {
            foreach (Transform child in pausableGameObj.transform)
            {
                child.gameObject.SetActive(true);
            }
        }


        GameObject pauseGameObj = GameObject.Find("PauseObjects");
        if (pauseGameObj != null)
        {
            foreach (Transform child in pauseGameObj.transform)
            {
                if (child.name == "Tutorial")
                {
                    child.gameObject.SetActive(false);
                    return;
                }
            }

        }
    }

    public void PauseMenuClick()
    {
        if (gameManager != null)
        {
            gameManager.SetPausableObjectsMovement(false);
            SetPauseMenu(true);
        }
        else
        {
            Errors.GameManagerNotFound();
        }
    }

    public void PlayClick()
    {
        if (gameManager != null)
        {
            SetPauseMenu(false);
            gameManager.SetPausableObjectsMovement(true);
        }
        else
        {
            Errors.GameManagerNotFound();
        }
    }

    public void SetPauseMenu(bool active)
    {
        GameObject pauseGameObj = GameObject.Find("PauseObjects");
        if (pauseGameObj != null)
        {
            foreach (Transform child in pauseGameObj.transform)
            {
                if (child.name == "PauseMenu")
                {
                    child.gameObject.SetActive(active);
                }
            }
        }
    }
}
