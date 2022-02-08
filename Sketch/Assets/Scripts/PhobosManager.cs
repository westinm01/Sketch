using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosManager : MonoBehaviour
{
    public float timeDarkened;
    public float maxDarkness;
    public GameObject dark;
    public LightsOut lightsOut;
    private float darkTimer = 0;
    public void DarkenScreen(){
        darkTimer = 0;
        dark.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    void Start(){
        darkTimer = timeDarkened;   // Start inactive
        lightsOut = gameObject.GetComponent<LightsOut>();
    }

    void Update(){
        if (darkTimer < timeDarkened){      // Darken Screen over time during transition between phases
            Color tempColor = dark.GetComponent<SpriteRenderer>().color;
            if (tempColor.a < maxDarkness){
                tempColor.a += 0.005f;      // How fast the screen darkens
            }

            dark.GetComponent<SpriteRenderer>().color = tempColor;
            darkTimer += Time.deltaTime;
        }
    }
}
