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
    private bool moveCamera = false;
    private float darkTimer = 0;
    private bool darken = false;
    private bool brighten = false;

    public void AdjustCamera(){
        cam.orthographicSize = 4.815f;
        moveCamera = true;
        cam.gameObject.GetComponent<Camera_Follow>().FreezeCamera();
    }
    public void DarkenScreen(){
        darken = true;
        brighten = false;
        dark.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
    public void BrightenScreen(){
        brighten = true;
        darken = false;
    }

    void Start(){
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lightsOut = gameObject.GetComponent<LightsOut>();
        bossFight = gameObject.GetComponent<PhobosFight>();
        darkTimer = timeDarkened;   // Start inactive
    }

    void Update(){
        if (moveCamera){
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(-1.5f, 22, -10), 5 * Time.deltaTime);
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
            tempColor.a -= 0.005f;
            dark.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}
