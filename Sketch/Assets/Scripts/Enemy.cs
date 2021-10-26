using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private Rigidbody2D enemyRigidBody;
    private Vector2 force, center;
 
    void Start()
    {
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector2(8,3);
        center = new Vector2(0, 3); // will be a position above the player once player is implemented
       

    }


    void Update()
    {
        Vector2 pos = gameObject.transform.position;
        force = center - pos;
        force = force.normalized;
        force = force * .5f;
     
        
        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, 8);

    }
}
