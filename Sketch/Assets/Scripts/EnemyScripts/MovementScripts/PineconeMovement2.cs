using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineconeMovement2 : EnemyMovement
{
    public float slideSpeed = 2;
    public float jumpHeight = 2;
    protected Animator blobAnimator;
    protected float slideTimer;
    protected float direction;
    protected int level;
    private bool stopped;
    //private bool canJump;

    protected override void move()
    {
        Vector2 pos = gameObject.transform.position;
        direction = -direction;
        enemyRigidBody.velocity = new Vector2(direction, enemyRigidBody.velocity.y);
        if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        slideTimer = 0;
    }
    protected void moveTowardsPlayer()
    {
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        if (pos.x < center.x)
        {
            direction = maxSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            direction = -maxSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        enemyRigidBody.velocity = new Vector2(direction, enemyRigidBody.velocity.y);
        slideTimer = 0;
    }
    protected override void Start()
    {
        base.Start();
        blobAnimator = gameObject.GetComponent<Animator>();
        slideTimer = slideSpeed;
        direction = maxSpeed;
        level = gameObject.GetComponent<EnemyCombat>().level;
    }
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned())
        {
            moveSpeed = 0;
        }
        else if (slideTimer >= slideSpeed)
        {
            moveSpeed = maxSpeed;
            if (level == 1)
            {
                blobAnimator.Play("blob1_jump");
            }
            else if (level == 2)
            {
                blobAnimator.Play("blob2_slide");
            }

            if (playerDistance < targetDistance)
            {
                if (!stopped) moveTowardsPlayer();
                Invoke("stopEnemy", 0.00f);
                Invoke("moveEnemy", 1.00f);
            }
            else
            {
                move();
            }
        }
        else if (slideTimer < slideSpeed)
        {
            slideTimer += Time.deltaTime;
        }
    }

    private void stopEnemy()
    {
        stopped = true;
        enemyRigidBody.velocity = new Vector2(0, enemyRigidBody.velocity.y);
        //Debug.Log("stopped");
    }
    private void moveEnemy()
    {
        stopped = false;
        moveTowardsPlayer();
        //Debug.Log("move");
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            canJump = true;
            enemyRigidBody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            moveTowardsPlayer();
            canJump = false;
        }
    }*/
}
