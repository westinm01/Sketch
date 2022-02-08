using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    private PhobosManager manager;
    public void PlayEvent(){
        manager.DarkenScreen();
    }

    void Start(){
        manager = gameObject.GetComponent<PhobosManager>();
    }
}
