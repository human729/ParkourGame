using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettings : MonoBehaviour
{
    public SettingsScriptableObject SettingsSO;
    public AudioMixer audioMixer;

    private void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/SettingsDATA.json");
        JsonUtility.FromJsonOverwrite(json, SettingsSO);
        if  (SettingsSO.SoundToggle)
        {
            audioMixer.SetFloat("Music", SettingsSO.MusicValue);
            audioMixer.SetFloat("Sounds", SettingsSO.SoundValue);
        } else if (!SettingsSO.SoundToggle)
        {
            audioMixer.SetFloat("Music", -80);
            audioMixer.SetFloat("Sounds", -80);
        }
        

    }                                                                                                                                                                                                         
}

