using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public bool isTutorial = false;
    // Start is called before the first frame update
    void Start()
    {

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
        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager)
        {
            gameManager.SetPausableObjectsMovement(false);
        }

        SetPauseMenu(true);
    }

    public void PlayClick()
    {
        SetPauseMenu(false);

        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager)
        {
            gameManager.SetPausableObjectsMovement(true);
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
