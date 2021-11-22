using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int maxSpeed = 5;
    public float turnSpeed = 0.5f;
    public float targetDistance = 7.5f;

    protected GameObject amPlayer;
    protected Rigidbody2D enemyRigidBody;
    protected Vector2 force, center;
    protected int moveSpeed;
 
    protected virtual void move(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
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
        moveSpeed = maxSpeed;
    }

    protected virtual void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            moveSpeed = 0;
        }

        else if (playerDistance < targetDistance){
            moveSpeed = maxSpeed;
            move();
        }
        else{
            enemyRigidBody.velocity = Vector2.zero;
        }
    }
}
