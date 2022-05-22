using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject _MainMenu;
    public GameObject LevelSelect;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public static bool goToLevelSelect = false;


    void OnEnable(){
        if (goToLevelSelect){
            LoadLevelSelect();
            goToLevelSelect = false;
        }
        else{
            StartCoroutine(InitializeSettings());
        }
    }

    private IEnumerator InitializeSettings(){
        yield return 0;
        float musicVolume = 1;
        float sfxVolume = 1;
        if (PlayerPrefs.HasKey("MusicVolume")){
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SFXVolume")){
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        }

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        musicSetVolume(musicSlider.value);
        sfxSetVolume(sfxSlider.value);

        switch(Screen.currentResolution.width){
            case 2560:
                resolutionDropdown.value = 0;
                break;
            case 1920:
                resolutionDropdown.value = 1;
                break;
            case 1600:
                resolutionDropdown.value = 2;
                break;
            case 1280:
                resolutionDropdown.value = 3;
                break;
            default:
                resolutionDropdown.value = 4;
                break;
        }
    }

    public void PlayGame()
    {
        int totalLevelsDone = 0;
        for (int i=0; i < 12; i++){
            totalLevelsDone += StaticInfo.levelInt[i];
            if (StaticInfo.bossBool[i] == true) ++totalLevelsDone;
        }
        
        if (totalLevelsDone == 0){      // If no levels have been done, load the tutorial
            SceneManager.LoadScene(2);
        }
        else{
            LoadLevelSelect();
        }
    }

    public void LoadEncyclopedia(){
        SceneManager.LoadScene(50);
    }

    public void SetVolume(float volume){
        float newVolume = Mathf.Log10(volume) * 20;
        mixer.SetFloat("MasterVolume", newVolume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void musicSetVolume(float volume){
        float newVolume = Mathf.Log10(volume) * 20;
        mixer.SetFloat("Music Volume", newVolume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void sfxSetVolume(float volume){
        float newVolume = Mathf.Log10(volume) * 20;
        mixer.SetFloat("Sound Effect", newVolume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen){
        Debug.Log(isFullscreen);
        if (isFullscreen){
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else{
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void SetResolution(int option){
        Debug.Log(option);
        Resolution[] resolutions = Screen.resolutions;
        int maxWidth = resolutions[resolutions.Length - 1].width;
        switch (option){
            case 0:
                if (maxWidth < 2560) break;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                SetResolutionScale(2560);
                break;
            case 1:
                if (maxWidth < 1920) break;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                SetResolutionScale(1920);
                break;
            case 2:
                if (maxWidth < 1600) break;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                SetResolutionScale(1600);
                break;
            case 3:
                if (maxWidth < 1280) break;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                SetResolutionScale(1280);
                break;
            case 4:
                SetResolutionScale(resolutions[resolutions.Length - 1].width);
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                
                break;
            default:
                Debug.Log("Option " + option + " not found");
                break;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }

    public void LoadLevelSelect(){
        LevelSelect.SetActive(true);
        _MainMenu.SetActive(false);
        // GameObject.FindGameObjectWithTag("LevelSelect").SetActive(true);
        // GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }

    public void SetResolutionScale(int resolution){
        Screen.SetResolution(resolution, resolution * 9 / 16, false);
        //Display.main.SetRenderingResolution(resolution, resolution * 9 / 16);
    }
}
