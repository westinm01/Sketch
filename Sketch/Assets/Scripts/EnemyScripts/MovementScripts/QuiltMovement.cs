using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiltMovement : EnemyMovement
{
    public float slideSpeed = 2;
    public float jumpHeight = 2;
    protected Animator quiltAnimator;
    protected float slideTimer;
    protected float direction;
    protected int level;

    protected override void move()
    {
        Vector2 pos = gameObject.transform.position;
        direction = -direction;
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
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
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
        slideTimer = 0;
    }
    protected override void Start()
    {
        base.Start();
        quiltAnimator = gameObject.GetComponent<Animator>();
        if (level == 1) quiltAnimator.Play("Quilt1animation");
        else if (level == 2) quiltAnimator.Play("Quilt2animation");
        else if (level == 3) quiltAnimator.Play("Quilt3animation");
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

            if (playerDistance < targetDistance)
            {
                moveTowardsPlayer();
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
}
