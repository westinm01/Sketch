using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasMovement : EnemyMovement
{
    public float slideSpeed;
    public float rotationSpeed;
    protected int level;
    private Animator ideasAnim;
    private float slideTimer;
    protected float direction;
    private Vector2 directionVector;
    private bool hasShot;
    private bool movedTowardsPlayer; // Only shoot if moved towards player

    protected override void move(){
        direction = -direction;
        if (direction > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        enemyRigidBody.velocity = new Vector2(direction, 0);
        slideTimer = 0;
        movedTowardsPlayer = false;
    }

    protected void moveTowardsPlayer(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        if (pos.x < center.x){
            direction = maxSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            direction = -maxSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (level == 3){
            force = center - pos;
            force = force.normalized;
            force *= turnSpeed;
            enemyRigidBody.velocity = force;

            // enemyRigidBody.AddForce(force);
            // enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
        }
        else{
            enemyRigidBody.velocity = new Vector2(direction, 0);
        }
        slideTimer = 0;
        movedTowardsPlayer = true;
    }

    protected void Shoot(){
        this.GetComponent<IdeasCombat>().attack(amPlayer.transform.position);
        hasShot = true;
        ideasAnim.enabled = false;
    }

    protected override void Start()
    {
        base.Start();
        slideTimer = 0;
        ideasAnim = this.gameObject.GetComponent<Animator>();
        direction = maxSpeed;
        level = this.gameObject.GetComponent<EnemyCombat>().level;
        hasShot = false;
    }

    protected override void Update()
    {

        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;        
        if (level == 3){
            gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), rotationSpeed);
        }


        if (gameObject.GetComponent<IdeasCombat>().isStunned()){
            moveSpeed = 0;
        }
        else if (slideTimer >= slideSpeed){
            moveSpeed = maxSpeed;
            if (level == 1){
                ideasAnim.Play("ideas1squish");
            }
            else if (level == 2){
                ideasAnim.Play("ideas2squish");
            }
            hasShot = false;
            if (playerDistance < targetDistance){
                if (level == 3){
                    ideasAnim.Play("ideas3attack");
                    Shoot();
                    ideasAnim.enabled = true;
                }
                moveTowardsPlayer();
            }
            else{
                move();
            }
        }
        else if (slideTimer < slideSpeed){
            if (playerDistance < targetDistance && movedTowardsPlayer){
                if (!hasShot){
                    if (level == 1 && ideasAnim.GetCurrentAnimatorStateInfo(0).IsName("ideas1freeze")){
                        Shoot();
                    }
                    else if (level == 2 && ideasAnim.GetCurrentAnimatorStateInfo(0).IsName("ideas2attack")){
                        Shoot();
                    }
                }
                else if (hasShot && !this.GetComponent<IdeasCombat>().isFiring && !this.GetComponent<IdeasCombat>().isCharging){ // Done shooting
                    ideasAnim.enabled = true;
                }
            }
            slideTimer += Time.deltaTime;
        }
    }
}
