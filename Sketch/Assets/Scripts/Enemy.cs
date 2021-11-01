using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{

    protected GameObject amPlayer;
    protected Rigidbody2D enemyRigidBody;
    protected Vector2 force, center;
    protected int moveSpeed;
    protected float turnSpeed;
 
    protected virtual void move(){
        Vector2 pos = gameObject.transform.position;
        force = center - pos;
        force = force.normalized;
        force = force * turnSpeed;
     
        
        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
    }

    protected virtual void Start()
    {
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        turnSpeed = 0.5f;
        center = new Vector2(0, 3); // will be a position above the player once player is implemented
    }

    protected virtual void Update()
    {
        move();
    }
}
