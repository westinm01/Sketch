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
    }

    void Start(){
        Application.targetFrameRate = 60;
    }

    public void GameOver(){
        pauser.endGame();
    }
}
