using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasCombat : EnemyCombat
{
<<<<<<< HEAD
    // public Projectile lightRay;
    // public float BeamOffset; // How far away from the object the beam is spawned
    public LightRayScript lightRay;
    public Projectile projectile;
    public float chargeTime;
    public CapsuleCollider2D upHitbox;
=======
    public Projectile lightRay;
    public float BeamOffset; // How far away from the object the beam is spawned
>>>>>>> parent of 672aaef (Merge pull request #143 from westinm01/Anthony's-branch)
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

<<<<<<< HEAD
    public void attack(Vector3 amPos){ // if direction is positive, projectile goes to the right, otherwise left
        // isFiring = true;
        isCharging = true;
        upHitbox.enabled = true;
        timer = 0;
        getTarget(amPos);
        // // Debug.Log(direction);
        // Projectile newLightRay = Instantiate(lightRay, r.GetPoint(BeamOffset), Quaternion.identity);
        // newLightRay.direction =  direction;
        // newLightRay.transform.RotateAround(newLightRay.transform.position, new Vector3(0, 0, 1), Vector3.Angle(direction, newLightRay.transform.position));
    }

    public void getTarget(Vector3 end){
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
=======
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
>>>>>>> parent of 672aaef (Merge pull request #143 from westinm01/Anthony's-branch)
    }

    protected override void Update()
    {
        base.Update();
        if (isCharging){
            if (timer < chargeTime){
                timer += Time.deltaTime;
            }
            else{
                getTarget(target);
                isCharging = false;
                isFiring = true;
                lightRay.Fire(target);
                timer = 0;
            }
        }
        if (isFiring){
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
