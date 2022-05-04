using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    private PauseScript pauser;
    private CanvasScript canvas;

    void Awake(){
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();;
        pauser = canvas.GetComponentInChildren<PauseScript>();
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

    public IEnumerator DisableUI(float timeDisabled){
        canvas.DisableUI();
        yield return new WaitForSeconds(timeDisabled);
        canvas.EnableUI();
    }
}
