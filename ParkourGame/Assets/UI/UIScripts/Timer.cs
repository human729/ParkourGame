using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float currentTime;
    public int startMinutes = 0;
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime = currentTime + Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        TimerText.text = time.ToString(@"mm\:ss\:ff");
    }
}
