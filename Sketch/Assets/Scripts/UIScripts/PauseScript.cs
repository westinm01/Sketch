using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    private GameManager gm;
    public GameObject endMenu;
    public GameObject pauseMenu;

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gm.isPaused = true;
        isPaused = true;
    }

    public void UnpauseGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gm.isPaused = false;
        isPaused = false;
    }

    public void endGame(){
        endMenu.SetActive(true);
        gm.isPaused = true;
        Time.timeScale = 0;
        DataSave.SaveData();
    }

    public void returnToLevelSelect(){
        Time.timeScale = 1;
        gm.isPaused = false;
        endMenu.SetActive(false);
        MainMenu.goToLevelSelect = true;
        ASceneLoader.LoadScene(0);
    }

    public void Restart(){
        gm.isPaused = false;
        Time.timeScale = 1;
        endMenu.SetActive(false);
        ASceneLoader.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Awake(){
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        DataSave.LoadData();
    }

    void Start(){
        // this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gm.isTournamentMode){
            if (isPaused){
                UnpauseGame();
            }
            else{
                PauseGame();
            }
        }
    }
}
