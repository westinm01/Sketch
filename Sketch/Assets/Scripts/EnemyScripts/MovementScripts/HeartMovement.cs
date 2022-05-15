using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : EnemyMovement
{
    protected override void move(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        force = center - pos;
        force = force.normalized;
        force *= turnSpeed;

        if (force.x < 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
    }
}
