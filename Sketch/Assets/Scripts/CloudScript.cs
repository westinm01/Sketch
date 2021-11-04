using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : Enemy
{
    protected float targetDistance;
    protected override void move(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        force = center - pos;
        force = force.normalized;
        force = force * turnSpeed;

        
        enemyRigidBody.AddForce(force);
        enemyRigidBody.velocity = Vector2.ClampMagnitude(enemyRigidBody.velocity, moveSpeed);
    }
    protected override void OnTriggerEnter2D(Collider2D collision){
        if (collision.attachedRigidbody.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Cloud hit " + collision.gameObject.name);
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Cloud/SScloud2_0");
        }
    }

    protected override void Start()
    {
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 4;
        turnSpeed = 2;
        targetDistance = 7.5f;
        animator = gameObject.GetComponent<Animator>();
    }

    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (playerDistance < targetDistance){
            move();
        }
        else{
            enemyRigidBody.velocity = new Vector2(0, 0);
        }
    }
}
