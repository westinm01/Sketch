using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider){
        // Debug.Log("Triggered");
        this.gameObject.GetComponentInParent<Platform>().initialAmContact = true;
        Destroy(this.gameObject);
    }
}
