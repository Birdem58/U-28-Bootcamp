using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider efectSlider;

    private void Start()
    {
        SetMusicVolume();
        SetEfectVolume();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
    public void SetEfectVolume()
    {
        float volume = efectSlider.value;
        myMixer.SetFloat("efect", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
