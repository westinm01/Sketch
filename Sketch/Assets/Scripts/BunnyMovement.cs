using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : EnemyMovement
{
    protected float jumpTimer = 2.5f;
    protected float direction;
    public float jumpTime = 2.5f;
    public float jumpHeight = 6;
    protected override void move(){
        direction = -direction;
        if (direction > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
        jumpTimer = 0;
    }
    protected void moveTowardsPlayer(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        if (pos.x > center.x){
            direction = -maxSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            direction = maxSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
        jumpTimer = 0;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        direction = maxSpeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            //Dont move
        }
        else if (jumpTimer < jumpTime){
            jumpTimer += Time.deltaTime;
        }
        else if (playerDistance < targetDistance){
            moveTowardsPlayer();
        }
        else{
            move();
        }
    }
}
