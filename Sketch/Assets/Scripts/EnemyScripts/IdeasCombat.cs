using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasCombat : EnemyCombat
{
    public Projectile lightRay;
    public float BeamOffset; // How far away from the object the beam is spawned
    [HideInInspector] public bool isFiring;
    private float beamDuration;
    private float timer;
    protected override void Start(){
        base.Start();
        beamDuration = lightRay.maxDuration;
        isFiring = false;
        timer = 0;
    }

    public void WindUpAttack(Vector3 amPos){
        isFiring = true;
        timer = 0;
        // currDirection = direction;
        // chargeTimer = 0;
    }

    public void attack(Vector3 amPos){ // if direction is positive, projectile goes to the right, otherwise left
        // isFiring = true;
        // timer = 0;
        Vector3 direction = amPos - gameObject.transform.position;
        // Debug.Log(direction);
        Ray r = new Ray(this.transform.position, direction.normalized);
        Projectile newLightRay = Instantiate(lightRay, r.GetPoint(BeamOffset), Quaternion.identity);
        newLightRay.direction =  direction;
        newLightRay.transform.RotateAround(newLightRay.transform.position, new Vector3(0, 0, 1), Vector3.Angle(direction, newLightRay.transform.position));
    }

    protected override void Update()
    {
        base.Update();
        if (isFiring){
            if (timer < beamDuration){
                timer += Time.deltaTime;
            }
            else{
                isFiring = false;
            }
        }
    }
}
