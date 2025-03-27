using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PlayerUI;
    public GameObject SettingsUI;
    public SettingsScriptableObject SettingsSO;
    public GameObject StartGameUI;
    public GameObject FinishScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseTab();
        }
        if (SettingsUI.activeInHierarchy)
        {
            
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            SaveData(SettingsSO);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CloseTab()
    {
        if (!StartGameUI.activeInHierarchy && !FinishScreen.activeInHierarchy)
        {
            SettingsUI.SetActive(!SettingsUI.activeInHierarchy);
            PlayerUI.SetActive(!PlayerUI.activeInHierarchy);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveData(SettingsScriptableObject settingsSO)
    {
        string json = JsonUtility.ToJson(settingsSO);
        File.WriteAllText(Application.dataPath + "/SettingsDATA.json", json);
    }
}
