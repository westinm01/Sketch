using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : EnemyMovement
{
    private Animator spiderAnim;
    public float attackDistance;
    public float chargeTime;
    private bool hasAttacked = false;
    private float chargeTimer;
    private float direction;

    protected override void Start()
    {
        base.Start();
        chargeTimer = chargeTime;
        spiderAnim = gameObject.GetComponent<Animator>();
    }
    protected override void move(){
        Vector2 posDiff = gameObject.transform.position - amPlayer.transform.position;
        if (posDiff.x > 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = -maxSpeed;
        }
        else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = maxSpeed;
        }
        Vector2 oldVelocity = enemyRigidBody.velocity;
        enemyRigidBody.velocity = new Vector2(direction, oldVelocity.y);
    }
    
    protected void jumpTowardsPlayer(){
        enemyRigidBody.velocity = new Vector2(direction * 2f, 0);
        hasAttacked = true;
    }

    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;

        if (hasAttacked){
            Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
            tempColor.a -= 0.01f;
            gameObject.GetComponent<SpriteRenderer>().color = tempColor;
            if (tempColor.a <= 0){
                Destroy(this.gameObject);
            }
        }

        if (chargeTimer < chargeTime){
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeTime){
                jumpTowardsPlayer();
            }
        }
        else if (playerDistance < attackDistance && !hasAttacked){
            spiderAnim.Play("spiderFall");
            enemyRigidBody.velocity = Vector2.zero;
            chargeTimer = 0;
        }
        else if (!hasAttacked){
            move();
        }
    }
}
