using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosManager : MonoBehaviour
{
    public float timeDarkened;
    public float maxDarkness;
    public GameObject dark;
    public LightsOut lightsOut;
    public PhobosFight bossFight;
    private Camera cam;
    private bool amEntered = false;
    public bool darken = false;
    public bool brighten = false;
    public int eventIndex;     // 0 for LightsOut, 1 for spiderFlood, 2 for phobosFight

    public void AdjustCamera(){
        cam.orthographicSize = 4.815f;
        amEntered = true;
        cam.gameObject.GetComponent<Camera_Follow>().FreezeCamera();
    }
    public void DarkenScreen(){
        darken = true;
        brighten = false;
        // dark.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
    public void BrightenScreen(){
        brighten = true;
        darken = false;
    }

    public void StartLightsOut(){
        Debug.Log("Switching to lights out");
        eventIndex = 0;
        lightsOut.PlayEvent();
    }

    public void StartBossPhase(){
        eventIndex = 2;
        bossFight.StartFight();
    }

    void Start(){
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lightsOut = gameObject.GetComponent<LightsOut>();
        bossFight = gameObject.GetComponent<PhobosFight>();
        eventIndex = 0;
        darken = false;
        brighten = false;
    }

    void Update(){
        if (amEntered){
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(-1.5f, 22, -10), 5 * Time.deltaTime);
            
            switch(eventIndex){
                case 0:
                    if (!lightsOut.isActive){   // Lights out finished
                        eventIndex = 3;
                        DarkenScreen();
                        Invoke("BrightenScreen", 2f);
                        Invoke("StartBossPhase", 5f);
                    }
                    break;
                case 1:
                    break;
                case 2:
                    if (!bossFight.phobos.isActive){    // Boss phase finished
                        eventIndex = 3;
                        DarkenScreen();
                        Invoke("StartLightsOut", 3f);
                    }
                    break;
                case 3: // Do nothing, wait for transition
                    break;
                default:
                    Debug.Log("PhobosManagerAGAGAGAGAGADGINAISD");
                    break;
            }
        }

        

        if (darken){      // Darken Screen over time during transition between phases
            Color tempColor = dark.GetComponent<SpriteRenderer>().color;
            if (tempColor.a < maxDarkness){
                tempColor.a += 0.005f;      // How fast the screen darkens
            }

            dark.GetComponent<SpriteRenderer>().color = tempColor;
        }
        else if (brighten){
            Color tempColor = dark.GetComponent<SpriteRenderer>().color;
            if (tempColor.a > 0){
                tempColor.a -= 0.005f;
            }
            dark.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}
