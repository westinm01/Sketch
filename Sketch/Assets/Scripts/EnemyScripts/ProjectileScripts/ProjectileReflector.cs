using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileReflector : MonoBehaviour
{
    public float reflectCooldown;   // How long the reflector must wait before being able to reflect again
    public int timesReflected;
    private float reflectTimer;
    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Reflectable" && reflectTimer >= reflectCooldown){
            Projectile proj = coll.GetComponent<Projectile>();
            if (proj == null){
                proj = coll.GetComponentInParent<Projectile>();
            }
            proj.Bounce();
            reflectTimer = 0;
            timesReflected++;
        }
    }

    void Start(){
        timesReflected = 0;
        reflectTimer = reflectCooldown;
    }

    void Update(){
        if (reflectTimer < reflectCooldown){
            reflectTimer += Time.deltaTime;
        }
    }
}
