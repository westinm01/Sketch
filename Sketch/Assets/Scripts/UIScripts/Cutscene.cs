using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public float cutsceneLength;
    // public bool deleteAfterPlaying = true;
    public bool skippable = true;
    private Am_Movement am;
    [SerializeField] private CanvasScript canvas;
    private float timer = 0;
    // public bool hideCanvas;

    // private GameObject canvas;
    // Start is called before the first frame update
    void OnEnable()
    {
        am = GameObject.FindGameObjectWithTag("Player").GetComponent<Am_Movement>();
        StartCoroutine(am.FreezeAm(cutsceneLength));
        // canvas = GameObject.FindGameObjectWithTag("Canvas");
        // if (hideCanvas){
            // canvas.SetActive(false);
        // Time.timeScale = 0;
            // Invoke("UnhideCanvas", cutsceneLength);
        // }
        canvas.DisableUI();

        // if (deleteAfterPlaying){
        //     StartCoroutine(EndCutscene());
        //     // Destroy(this, cutsceneLength);
        // }
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= cutsceneLength || Input.GetKeyDown(KeyCode.Escape)){
            canvas.EnableUI();
            gameObject.SetActive(false);
            am.UnfreezeAm();
        }

    }

    // IEnumerator EndCutscene(){
    //     yield return new WaitForSeconds(cutsceneLength);
    // }
}
