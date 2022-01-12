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

    protected override void move(){
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
        // level = this.gameObject.GetComponent<EnemyCombat>().level;
    }

    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            moveSpeed = 0;
        }
        else if (slideTimer >= slideSpeed){
            moveSpeed = maxSpeed;
            // if (level == 1){
            //     ideasAnim.Play("blob1_jump");
            // }
            // else if (level == 2){
            //     ideasAnim.Play("blob2_slide");
            // }

            if (playerDistance < targetDistance){
                ideasAnim.Play("ideas1squish");
                move();
            }
        }
        else if (slideTimer < slideSpeed){
            slideTimer += Time.deltaTime;
        }
    }
}
