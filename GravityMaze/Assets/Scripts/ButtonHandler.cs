using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    enum ActivatedScreen
    {
        MainMenu,
        LevelSelection,
        Settings,
        Info
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string levelName)
    {
        try
        {
            GameObject loadingObj = GameObject.Find("Loading");
            if (loadingObj != null)
            {
                foreach (Transform child in loadingObj.transform) {
                    child.gameObject.SetActive(true);
                }
            }
        }
        catch (Exception e)
        { 
            Debug.LogException(e);
        }
        StartCoroutine(LoadSceneCoroutine(levelName));
    }
    IEnumerator LoadSceneCoroutine(string levelName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
    }

    public void SwitchToSelectLevelTable()
    {
        SubMenuActivation(true, "LevelSelection");
        MainMenuActivation(false);
    }

    public void SwitchToSettings()
    {
        SubMenuActivation(true, "Settings");
        MainMenuActivation(false);
    }

    public void SwitchToInfo()
    {
        SubMenuActivation(true, "Info");
        MainMenuActivation(false);
    }

    public void SwitchToMainMenu(int currentScreen)
    {
        switch (currentScreen)
        {
            case (int) ActivatedScreen.LevelSelection:
                SubMenuActivation(false, "LevelSelection");
                break;
            case (int) ActivatedScreen.Settings:
                SubMenuActivation(false, "Settings");
                break;
            case (int)ActivatedScreen.Info:
                SubMenuActivation(false, "Info");
                break;
            default:
                break;
        }
        MainMenuActivation(true);
    }
    
    private void MainMenuActivation(bool isActive)
    {
        GameObject mainMenuObj = GameObject.Find("MainMenu");
        if (mainMenuObj != null)
        {
            foreach (Transform child in mainMenuObj.transform)
            {
                child.gameObject.SetActive(isActive);
            }
        }
    }
    private void SubMenuActivation(bool isActive, string subMenu)
    {
        GameObject subMenuObj = GameObject.Find(subMenu);
        if (subMenuObj != null)
        {
            foreach (Transform child in subMenuObj.transform)
            {
                child.gameObject.SetActive(isActive);
            }
        }
    }    
}
