using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider mSlider;
    public Text percentageText;

    private static float sensitivityOriginal = 100f;
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        if (gameManager && gameManager.saveData != null)
        {
            mSlider.value = gameManager.saveData.sensitivity;
            sensitivityOriginal = mSlider.value;
        }
    }

    public void UpdateSettings()
    {
        gameManager.saveData.sensitivity = mSlider.value;
        gameManager.saveData.Save();
    }

    // Update is called once per frame
    void Update()
    {
        percentageText.text = mSlider.value.ToString() + "%";
    }
    static public SettingsManager GetSettingsManager()
    {
        return GameObject.Find("SettingsManager").GetComponent(typeof(SettingsManager)) as SettingsManager;
    }

    public void UndoSettings()
    {
        mSlider.value = sensitivityOriginal;
    }

}
