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
        SceneManager.LoadScene(levelName);
    }

    public void SwitchToSelectLevelTable()
    {
        LevelSelectionActivation(true);
        MainMenuActivation(false);
    }

    public void SwitchToSettings()
    {
        SettingsActivation(true);
        MainMenuActivation(false);
    }

    public void SwitchToMainMenu(int currentScreen)
    {
        switch (currentScreen)
        {
            case (int) ActivatedScreen.LevelSelection:
                LevelSelectionActivation(false);
                break;
            case (int) ActivatedScreen.Settings:
                SettingsActivation(false);
                break;
            default:
                break;
        }
        MainMenuActivation(true);
    }

    public void OpenSettings()
    {

    }

    public void OpenInfo()
    {

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

    private void LevelSelectionActivation(bool isActive)
    {
        GameObject levelSelectionObj = GameObject.Find("LevelSelection");
        if (levelSelectionObj != null)
        {
            foreach (Transform child in levelSelectionObj.transform)
            {
                child.gameObject.SetActive(isActive);
            }
        }
    }

    private void SettingsActivation(bool isActive)
    {
        GameObject levelSelectionObj = GameObject.Find("Settings");
        if (levelSelectionObj != null)
        {
            foreach (Transform child in levelSelectionObj.transform)
            {
                child.gameObject.SetActive(isActive);
            }
        }
    }
}
