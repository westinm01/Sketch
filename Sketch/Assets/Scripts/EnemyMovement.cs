using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    protected GameObject amPlayer;
    protected Rigidbody2D enemyRigidBody;
    protected Vector2 force, center;
    protected int moveSpeed;
    protected float turnSpeed;
    protected float targetDistance;
    protected Vector2 knockbackForce;
    public float stunTimer;
    public float stunTime;
 
    protected virtual void move(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        force = center - pos;
        force = force.normalized;
        force = force * turnSpeed;
     
        
        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
    }

    public virtual void stun(Collider2D collision){
        Vector2 direction;
        if (collision.attachedRigidbody.velocity.Equals(Vector2.zero)){
            direction = -enemyRigidBody.velocity.normalized;
        }
        else{
            direction = collision.attachedRigidbody.velocity.normalized;
        }
        enemyRigidBody.velocity = direction * knockbackForce;
        stunTimer = 0;
        moveSpeed = 0;
    }

    protected virtual void Start()
    {
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        turnSpeed = 0.5f;
        targetDistance = 7.5f;
        stunTime = 1.0f;
        stunTimer = stunTime;
        knockbackForce = new Vector2(5, 5);
    }

    protected virtual void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (stunTimer >= stunTime && playerDistance < targetDistance){
            move();
        }
        else{
            if (stunTimer >= stunTime){
                enemyRigidBody.velocity = Vector2.zero;
            }
            else{
                stunTimer += Time.deltaTime;
                if (stunTimer >= stunTime){
                    moveSpeed = 5;
                }
            }
        }
    }
}
