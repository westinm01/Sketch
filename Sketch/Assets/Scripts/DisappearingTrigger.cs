using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTrigger : MonoBehaviour
{
    public PhobosManager manager;
    private void OnTriggerEnter2D(Collider2D collider){
        // Debug.Log("Triggered");
        this.gameObject.GetComponentInParent<Platform>().initialAmContact = true;
        manager.lightsOut.PlayEvent();
        Destroy(this.gameObject);
    }
}
