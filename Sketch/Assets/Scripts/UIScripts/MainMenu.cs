using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject _MainMenu;
    public GameObject LevelSelect;
    public static bool goToLevelSelect = false;

    void OnEnable(){
        if (goToLevelSelect){
            LoadLevelSelect();
            goToLevelSelect = false;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadEncyclopedia(){
        SceneManager.LoadScene(50);
    }

    public void SetVolume(float volume){
        mixer.SetFloat("MasterVolume", volume);
    }

    public void musicSetVolume(float volume){
        mixer.SetFloat("Music Volume", Mathf.Log10(volume) * 20);
    }

    public void sfxSetVolume(float volume){
        mixer.SetFloat("Sound Effect", Mathf.Log10(volume) * 20);
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
        switch(option){
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 3:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 4:
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

    public void SetResolution(int resolution){
        if (Display.displays.Length > 1)
        {
            Display.displays[1].SetRenderingResolution(resolution, resolution * 9 / 16);
        }
    }
}
