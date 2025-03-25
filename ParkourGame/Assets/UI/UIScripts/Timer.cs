using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string textForCanvas;
    public NextLevel nextLevel;
    public Text TimerText;
    public GameObject EndScreen;
    float currentTime;
    public int startMinutes = 0;
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (!nextLevel.LvLFinished)
        {
            currentTime = currentTime + Time.deltaTime;

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            TimerText.text = time.ToString(@"mm\:ss\:ff");

            
        } else
        {
            textForCanvas = TimerText.text;
            EndScreen.SetActive(true);
        }
    }
}
