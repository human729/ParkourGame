using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public Text StartGameTimer;
    public PlayerMovement Movement;
    public Dash Dash;
    public Jump Jump;
    public GameObject UI;
    public WallRunning WallRunning;
    public Timer PlayerTimer;
    int Number = 3;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        WallRunning.enabled = false;
        UI.SetActive(false);
        Dash.enabled = false;
        Jump.enabled = false;
        Movement.enabled = false;
    }
    void Start()
    {
        StartGameTimer.enabled = true;
        StartCoroutine(StartingGame());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartingGame()
    {
        while (Number <= 3 && Number > 0)
        { 
            yield return new WaitForSeconds(1f);
            StartGameTimer.text = $"{Number}";
            Number--;
        }
        yield return new WaitForSeconds (1f);
        StartGameTimer.text = "Start!";
        yield return new WaitForSeconds(1f);
        StartGameTimer.enabled = false;
        Movement.enabled = true;
        WallRunning.enabled = true;
        Dash.enabled = true;
        Jump.enabled = true;
        UI.SetActive(true);
        PlayerTimer.enabled = true;
    }
}
