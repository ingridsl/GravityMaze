using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider percentageSlider;
    public Slider orientationSlider;
    public Slider alienOnScreenSlider;

    public Text percentageText;

    private static float sensitivityOriginal = 100f;
    private static bool alienOnScreenDefault = true;
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager == null)
        {
            Errors.GameManagerNotFound();
        }
        else if (gameManager && gameManager.saveData != null)
        {
            percentageSlider.value = gameManager.saveData.sensitivity;
            orientationSlider.value = gameManager.saveData.orientation;
            alienOnScreenSlider.value = gameManager.saveData.alienOnScreen ? 1 : 0;
            sensitivityOriginal = percentageSlider.value;
        }
    }

    public void UpdateSettings()
    {
        if (gameManager != null)
        {
            gameManager.saveData.sensitivity = percentageSlider.value;
            gameManager.saveData.orientation = (int)orientationSlider.value;
            gameManager.saveData.alienOnScreen = alienOnScreenSlider.value == 1;
            gameManager.saveData.Save();
        }
        else
        {
            Errors.GameManagerNotFound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        percentageText.text = percentageSlider.value.ToString() + "%";
    }
    static public SettingsManager GetSettingsManager()
    {
        return GameObject.Find("SettingsManager").GetComponent(typeof(SettingsManager)) as SettingsManager;
    }

    public void DefaultSettings()
    {
        percentageSlider.value = sensitivityOriginal;
        orientationSlider.value = Constants.LandscapeRIGHT;
        alienOnScreenSlider.value = alienOnScreenDefault ? 1 : 0 ;
    }
}
