using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public Toggle toggie;
    public SettingsScriptableObject SettingsSO;
    public AudioMixer Mixer;
    public Image On;
    public Image Off;
    float MusicValue;
    float SoundValue;
    void Start()
    {
        toggie.isOn = SettingsSO.SoundToggle;
        toggie.onValueChanged.AddListener(ToggleSound);
    }

    
    public void ToggleSound(bool isOn)
    {
        if (isOn)
        {           
            Mixer.SetFloat("Music", MusicValue);
            Mixer.SetFloat("Sounds", SoundValue);
            On.enabled = true; Off.enabled = false;
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "ON";
        } else if (!isOn)
        {
            Mixer.GetFloat("Sounds", out SoundValue);
            Mixer.GetFloat("Music", out MusicValue);
            Mixer.SetFloat("Music", -80);
            Mixer.SetFloat("Sounds", -80);
            On.enabled = false; Off.enabled = true;
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "OFF";
        }
    }

}
