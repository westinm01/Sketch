using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoorTrigger : MonoBehaviour
{
    public PhobosManager manager;
    private void OnTriggerEnter2D(Collider2D collider){
        // Debug.Log("Triggered");
        if (collider.gameObject.tag == "Player"){
            this.gameObject.GetComponentInParent<Platform>().initialAmContact = true;
            manager.AdjustCamera();
            manager.DarkenScreen();
            manager.StartLightsOut();
            //manager.bossFight.StartFight(); // Start with phobos fight for testing
            Destroy(this.gameObject);
        }
    }
}
