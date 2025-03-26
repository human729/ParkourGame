using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
    public SettingsScriptableObject SettingsSO;
    public AudioMixer AudioMixer;
    public string SoundCategory;
    public Slider AudioSlider;
    float currentVolume;
    void Start()
    {
        if (SoundCategory == "Music")
        {
            AudioMixer.SetFloat(SoundCategory, SettingsSO.MusicValue);
        }
        else if (SoundCategory == "Sounds")
        {
            AudioMixer.SetFloat(SoundCategory, SettingsSO.SoundValue);
        }

        AudioMixer.GetFloat(SoundCategory, out currentVolume);

        AudioSlider.value = Mathf.Pow(10, currentVolume / 20);
        
        AudioSlider.onValueChanged.AddListener(SetVolume);
        
    }

    private void SetVolume(float volume)
    {
        float volumeInDB = Mathf.Log10(volume) * 20;
        if (volumeInDB <= -60)
        {
            volumeInDB = -80;
        }
        AudioMixer.SetFloat(SoundCategory, volumeInDB);
        if (SoundCategory == "Music")
        {
            SettingsSO.MusicValue = volumeInDB;
        }
        else if (SoundCategory == "Sounds")
        {
            SettingsSO.SoundValue = volumeInDB;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
