using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Timer timer;
    Text TimeText;
    public GameObject PlayerUI;
    public GameObject Player;
    void Start()
    {
        TimeText = transform.GetChild(3).GetComponent<Text>();
        Cursor.lockState = CursorLockMode.Confined;
        TimeText.text = timer.textForCanvas;
        PlayerUI.SetActive(false);
        Player.SetActive(false);
    }

    public void NextLvL(string LvLName)
    {   
        SceneManager.LoadScene(LvLName);
    }
}
