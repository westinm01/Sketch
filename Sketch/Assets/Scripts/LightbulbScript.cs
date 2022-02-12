using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbScript : MonoBehaviour
{
    public LightsOut lightsManager;
    public void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("End the lights out phase");
    }
}
