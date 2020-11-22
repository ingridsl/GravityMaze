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

        GameObject pausableGameObj = GameObject.Find("Pausable");
        if (pausableGameObj != null)
        {
            foreach (Transform child in pausableGameObj.transform)
            {
                //pausar movimentação da bolinha
                //pausar movimentação dos inimitos, quando existirem
            }

        }
    }

    public void PlayClick()
    {
        GameObject pausableGameObj = GameObject.Find("Pausable");
        if (pausableGameObj != null)
        {
            foreach (Transform child in pausableGameObj.transform)
            {
                //despausar movimentação da bolinha
                //pausar movimentação dos inimitos, quando existirem
            }

        }
    }
}
