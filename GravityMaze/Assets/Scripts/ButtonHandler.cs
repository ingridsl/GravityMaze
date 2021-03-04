using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonHandler : MonoBehaviour 
{
    [SerializeField]
    enum ActivatedScreen
    {
        MainMenu,
        LevelSelection,
        Settings,
        Info,
        Trophy
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
        bool showAds = (UnityEngine.Random.value > 0.8f);
        if (showAds || levelName == "MainMenu") {
            if (Advertisement.IsReady())
            {
                Debug.Log("Playing ads!");
                Advertisement.Show();
            }
            else
            {
                Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            }
        }
        Debug.Log("FINISHED Playing ads!");

        try
        {
            if (!Advertisement.isShowing || !showAds)
            {
                GameManager.OpenLoading();
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

    public void SwitchToPrizeTable()
    {
        SubMenuActivation(true, "PrizeSelection");
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
            case (int)ActivatedScreen.Trophy:
                SubMenuActivation(false, "PrizeSelection");
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
