using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasCombat : EnemyCombat
{
    public Projectile lightRay;
    public float BeamxOffset;
    [HideInInspector] public bool isFiring;
    private float beamDuration;
    private float timer;
    protected override void Start(){
        base.Start();
        beamDuration = lightRay.maxDuration;
        isFiring = false;
        timer = 0;
    }

    // public void WindUpAttack(float direction){
    //     isFiring = true;
    //     currDirection = direction;
    //     chargeTimer = 0;
    // }

    public void attack(float direction){ // if direction is positive, projectile goes to the right, otherwise left
        isFiring = true;
        timer = 0;
        if (direction > 0){
            Projectile newRay = Instantiate(lightRay, gameObject.transform.position + new Vector3(BeamxOffset, 0), Quaternion.identity);
            newRay.direction = new Vector2(1, 0);
        }
        else{
            Projectile newRay = Instantiate(lightRay, gameObject.transform.position - new Vector3(BeamxOffset, 0), Quaternion.identity);
            newRay.direction = new Vector2(-1, 0);
        }
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
