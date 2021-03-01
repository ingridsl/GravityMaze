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
        StartCoroutine(CloseLoadingCoroutine());
    }


    IEnumerator CloseLoadingCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.CloseLoading();
    }

    public void Undo()
    {
        settingsManager.DefaultSettings();
    }
}
