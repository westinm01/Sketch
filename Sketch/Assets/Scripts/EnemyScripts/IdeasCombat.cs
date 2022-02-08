using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasCombat : EnemyCombat
{
    public Projectile projectile;
    public float chargeTime;
    public Transform firePoint;
    [Header("ideas1")]
    public LightRayScript lightRay;
    public CapsuleCollider2D upHitbox;
    [Header("ideas2")]

    [HideInInspector] public bool isFiring;
    [HideInInspector] public bool isCharging;
    private float timer;
    private Vector3 target;
    protected override void Start(){
        base.Start();
        isFiring = false;
        isCharging = false;
        timer = 0;
    }

    public void attack(Vector3 amPos){ // if direction is positive, projectile goes to the right, otherwise left
        // isFiring = true;
        isCharging = true;
        timer = 0;
        getTarget(amPos);
        if (level == 1){
            upHitbox.enabled = true;
        }
        // // Debug.Log(direction);
        // Projectile newLightRay = Instantiate(lightRay, r.GetPoint(BeamOffset), Quaternion.identity);
        // newLightRay.direction =  direction;
        // newLightRay.transform.RotateAround(newLightRay.transform.position, new Vector3(0, 0, 1), Vector3.Angle(direction, newLightRay.transform.position));
    }

    public void getTarget(Vector3 end){
        if (level == 1){
            Vector3 direction = end - gameObject.transform.position;
            Ray r = new Ray(this.transform.position, direction.normalized);
            target = r.GetPoint(20);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 20);
            // Debug.Log(hits.Length);
            foreach(RaycastHit2D hit in hits){
                if (hit.collider.tag == "SpawnedShape" || hit.collider.tag == "Wall" || hit.collider.name == "Tilemap"){
                    target = hit.point;
                    return;
                }
                if (hit.collider.tag == "Player"){
                    target = hit.point;
                    return;
                }
            }
        }
        else if (level == 2){
            target = end;
        }
        else if (level == 3){
            target = end;
            // Debug.Log("currPos: " + gameObject.transform.position);
            // Debug.Log("target: " + target);
        }
    }

    protected override void Update()
    {
        base.Update();
        if (isCharging){
            if (timer < chargeTime){
                timer += Time.deltaTime;
            }
            else{       // Done charging
                getTarget(target);
                isCharging = false;

                if (level == 1){
                    lightRay.Fire(target);
                    isFiring = true;
                    timer = 0;
                }
                else if (level == 2){
                    if ((firePoint.right.x > 0 && target.x > 0) || (firePoint.right.x < 0 && target.x < 0)){ //Only shoot if Am is in front
                        Projectile newProj = Instantiate(projectile, firePoint.position, Quaternion.identity);
                        newProj.direction = target.normalized;
                        // Debug.Log(newProj.direction);
                    }
                }
                else if (level == 3){
                    Projectile newProj = Instantiate(projectile, firePoint.position, Quaternion.identity);
                    newProj.direction = target - gameObject.transform.position;
                    newProj.direction = newProj.direction.normalized;
                    // Debug.Log(target.normalized);
                }
            }
        }
        if (isFiring){
            if (level == 1){
                if (timer < lightRay.beamDuration){
                    timer += Time.deltaTime;
                }
                else{
                    isFiring = false;
                    upHitbox.enabled = false;
                    lightRay.stopFiring();
                }
            }
        }
    }
}
