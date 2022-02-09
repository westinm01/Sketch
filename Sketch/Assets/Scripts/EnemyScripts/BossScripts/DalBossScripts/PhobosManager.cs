using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosManager : MonoBehaviour
{
    public float timeDarkened;
    public float maxDarkness;
    public GameObject dark;
    public LightsOut lightsOut;
    private Camera cam;
    private bool cameraMoved = false;
    private float darkTimer = 0;

    public void AdjustCamera(){
        cam.orthographicSize = 4.815f;
        cameraMoved = true;
        cam.gameObject.GetComponent<Camera_Follow>().FreezeCamera();
    }
    public void DarkenScreen(){
        darkTimer = 0;
        dark.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    void Start(){
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lightsOut = gameObject.GetComponent<LightsOut>();
        darkTimer = timeDarkened;   // Start inactive
    }

    void Update(){
        if (cameraMoved){
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(-1.5f, 22, -10), 5 * Time.deltaTime);
        }

        if (darkTimer < timeDarkened){      // Darken Screen over time during transition between phases
            Color tempColor = dark.GetComponent<SpriteRenderer>().color;
            if (tempColor.a < maxDarkness){
                tempColor.a += 0.005f;      // How fast the screen darkens
            }

            dark.GetComponent<SpriteRenderer>().color = tempColor;
            darkTimer += Time.deltaTime;
        }
        else{
            Color tempColor = dark.GetComponent<SpriteRenderer>().color;
            tempColor.a -= 0.005f;
            dark.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}
