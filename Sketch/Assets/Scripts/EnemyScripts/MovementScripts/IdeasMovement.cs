using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasMovement : EnemyMovement
{
    public float slideSpeed;
    protected int level;
    private Animator ideasAnim;
    private float slideTimer;
    protected float direction;
    private bool hasShot;

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
        enemyRigidBody.velocity = new Vector2(direction, 0);
        slideTimer = 0;
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
        if (gameObject.GetComponent<IdeasCombat>().isStunned()){
            moveSpeed = 0;
        }
        else if (slideTimer >= slideSpeed){
            moveSpeed = maxSpeed;
            if (level == 1){
                ideasAnim.Play("ideas1squish");
                hasShot = false;
                if (playerDistance < targetDistance){
                    moveTowardsPlayer();
                }
                else{
                    move();
                }
            }
            // else if (level == 2){
            //     ideasAnim.Play("blob2_slide");
            // }
        }
        else if (slideTimer < slideSpeed){
            if (playerDistance < targetDistance){
                if (!hasShot && ideasAnim.GetCurrentAnimatorStateInfo(0).IsName("ideas1freeze")){
                    Debug.Log("Firing");
                    this.GetComponent<IdeasCombat>().attack(direction);
                    hasShot = true;
                    ideasAnim.enabled = false;
                }
                else if (hasShot && !this.GetComponent<IdeasCombat>().isFiring){ // Done shooting
                    ideasAnim.enabled = true;
                }
            }
            slideTimer += Time.deltaTime;
        }
    }
}
