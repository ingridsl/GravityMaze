using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSave : MonoBehaviour
{
    SettingsManager settingsManager = null;
    // Start is called before the first frame update
    void Start()
    {
        settingsManager = SettingsManager.GetSettingsManager();
        if (settingsManager == null)
        {
            Errors.SettingsManagerNotFound();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        GameManager.OpenLoading();
        settingsManager.UpdateSettings();
        StartCoroutine(GameManager.CloseLoadingCoroutine());
    }
    
    public void Undo()
    {
        settingsManager.DefaultSettings();
    }
}
