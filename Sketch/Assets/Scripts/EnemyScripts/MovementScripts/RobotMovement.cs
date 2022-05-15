using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : EnemyMovement
{
    public float moveDistance;
    public EnemyGroundCheck leftCheck;
    public EnemyGroundCheck rightCheck;
    public float direction = 1;
    private float distTraveled;

    protected override void Start()
    {
        base.Start();
        distTraveled = 0;
        if (direction == 0){
            direction = 1;
        }
    }

    public void SetDirection(float direction){
        this.direction = direction;
    }
    
    // Update is called once per frame
    protected override void Update()
    {
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            enemyRigidBody.velocity = Vector2.zero;
            return;
        }

        if ((!rightCheck.isGrounded && leftCheck.isGrounded) || rightCheck.touchingWall){
            direction = -1f;
            distTraveled = 0;
        }
        else if ((!leftCheck.isGrounded && rightCheck.isGrounded)|| leftCheck.touchingWall){
            direction = 1f;
            distTraveled = 0;
        }
        
        distTraveled += maxSpeed * Time.deltaTime;
        if (distTraveled >= moveDistance){
            direction = -direction;
            distTraveled = 0;
        }

        enemyRigidBody.velocity = new Vector2(maxSpeed * direction, 0);

    }
}
