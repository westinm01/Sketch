using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMovement : EnemyMovement
{
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (playerDistance < targetDistance){
            moveSpeed = maxSpeed;
            move();
        }
        else{
            enemyRigidBody.velocity = Vector2.zero;
        }
    }
}
