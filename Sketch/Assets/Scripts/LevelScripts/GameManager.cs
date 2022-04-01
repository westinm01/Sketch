using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    public PauseScript pauser;

    void Awake(){
        pauser = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<PauseScript>();
        DataSave.LoadData();
    }

    void Start(){
        Application.targetFrameRate = 60;
    }

    void Update(){
        if (!isPaused){
            StaticInfo.playTime += Time.deltaTime;
        }
    }

    public void GameOver(){
        pauser.endGame();
    }
}
