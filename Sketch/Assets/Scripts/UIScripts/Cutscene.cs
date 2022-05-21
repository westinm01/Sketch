using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public float cutsceneLength;
    // public bool deleteAfterPlaying = true;
    public bool skippable = true;
    [SerializeField] private Am_Movement am;
    [SerializeField] private CanvasScript canvas;
    private float timer = 0;

    public bool isInGame = true;
    // public bool hideCanvas;

    // private GameObject canvas;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (isInGame){
            StartCoroutine(am.FreezeAm(cutsceneLength));
            canvas.DisableUI();
        }
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= cutsceneLength || Input.GetKeyDown(KeyCode.Escape)){
            if (isInGame){
                am.UnfreezeAm();
                canvas.EnableUI();
            }
            gameObject.SetActive(false);

        }

    }

    // IEnumerator EndCutscene(){
    //     yield return new WaitForSeconds(cutsceneLength);
    // }
}
