using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private const string volumeKey = "Volume";

    private void Start()
    {
        
        if (PlayerPrefs.HasKey(volumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(volumeKey);
            SetVolume(savedVolume);
            volumeSlider.value = savedVolume;
        }
        else
        {
            SetVolume(0f); 
        }
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(volumeKey, volume);
        PlayerPrefs.Save();
    }


}
