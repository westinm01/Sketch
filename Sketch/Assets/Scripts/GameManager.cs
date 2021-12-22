using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    public PauseScript pauser;

    void Start(){
        pauser = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<PauseScript>();
    }

    public void GameOver(){
        pauser.endGame();
    }
}
