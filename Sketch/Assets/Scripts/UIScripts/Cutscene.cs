using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public float cutsceneLength;
    public bool deleteAfterPlaying;
    private Am_Movement am;
    private GameManager gm;
    // public bool hideCanvas;

    // private GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        am = GameObject.FindGameObjectWithTag("Player").GetComponent<Am_Movement>();
        StartCoroutine(am.FreezeAm(cutsceneLength));
        // canvas = GameObject.FindGameObjectWithTag("Canvas");
        // if (hideCanvas){
            // canvas.SetActive(false);
        // Time.timeScale = 0;
            // Invoke("UnhideCanvas", cutsceneLength);
        // }

        if (deleteAfterPlaying){
            StartCoroutine(EndCutscene());
            // Destroy(this, cutsceneLength);
        }
    }

    // void UnhideCanvas(){
    //     canvas.SetActive(true);
    // }

    IEnumerator EndCutscene(){
        yield return new WaitForSeconds(cutsceneLength);
        gameObject.SetActive(false);
    }
}
