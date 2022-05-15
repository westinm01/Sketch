using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float masterVolume { get; private set; }
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI masterSliderText;
    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI soundEffectSliderText;

    public void OnMasterVolumeSliderValueChange(float value)
    {
        masterVolume = value;

        masterSliderText.text = ((int)(value * 100)).ToString();
    }

    public void OnMuisicSliderValueChange(float value)
    {
        musicVolume = value;

        musicSliderText.text = ((int)(value * 100)).ToString();
    }

    public void OnSoundEffectSliderValueChange(float value)
    {
        soundEffectsVolume = value;

        soundEffectSliderText.text = ((int)(value * 100)).ToString();
    }
}
