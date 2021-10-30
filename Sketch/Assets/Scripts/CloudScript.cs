using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : Enemy
{
    protected override void move(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        force = center - pos;
        force = force.normalized;
        force = force * turnSpeed;

        
        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
    }
    protected override void Start()
    {
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector2(8,3);
        moveSpeed = 4;
        turnSpeed = 2;
    }
}
