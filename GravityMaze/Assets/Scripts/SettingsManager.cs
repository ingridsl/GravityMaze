using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider mSlider;
    public Text percentageText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.GetGameManager();
        if (gameManager && gameManager.saveData != null)
        {
            mSlider.value = gameManager.saveData.sensitivity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        percentageText.text = mSlider.value.ToString() + "%";
    }
}
