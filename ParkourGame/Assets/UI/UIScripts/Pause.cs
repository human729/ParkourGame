using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PlayerUI;
    public GameObject SettingsUI;
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
}
