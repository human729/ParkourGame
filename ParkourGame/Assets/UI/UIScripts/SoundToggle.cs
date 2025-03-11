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

    void Start()
    {
        toggie.isOn = SettingsSO.SoundToggle;
        toggie.onValueChanged.AddListener(ToggleSound);
    }

    
    public void ToggleSound(bool isOn)
    {
        if (isOn)
        {
            Mixer.SetFloat("Music", 100);
            Mixer.SetFloat("Sounds", 100);
            On.enabled = true; Off.enabled = false;
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "ON";
        } else if (!isOn)
        {
            Mixer.SetFloat("Music", -80);
            Mixer.SetFloat("Sounds", -80);
            On.enabled = false; Off.enabled = true;
            transform.GetChild(1).gameObject.GetComponent<Text>().text = "OFF";
        }
    }
}
