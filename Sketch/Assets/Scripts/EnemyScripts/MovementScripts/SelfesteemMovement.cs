using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfesteemMovement : EnemyMovement
{
    protected float direction;
    protected float jumpCD = 2f;
    protected float jumpHeight = 6f;
    protected Animator SelfesteemAnimator;
    protected bool canJump = false, isTouchingGround = false;
    protected int level;

    protected float jumpTimer = 0;
    protected override void Update()
    {
        if (jumpTimer < jumpCD)
        {
            jumpTimer += Time.deltaTime;
        }
        else
        {
            canJump = true;
            jumpTimer = 0;
        }
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned())
        {

        }
        else if (playerDistance < targetDistance)
        {
            moveSpeed = maxSpeed;
            moveTowardsPlayer();
        }
        else
        {
            enemyRigidBody.velocity = Vector2.zero;
            if (level == 1) SelfesteemAnimator.Play("selfesteem1idle");
            else if (level == 2) SelfesteemAnimator.Play("selfesteem2idle");
            else if (level == 3) SelfesteemAnimator.Play("selfesteem3idle");
        }
    }

    protected override void Start()
    {
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        direction = maxSpeed;
        SelfesteemAnimator = gameObject.GetComponent<Animator>();
        level = gameObject.GetComponent<EnemyCombat>().level;
    }

    protected void moveTowardsPlayer()
    {
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        if (Mathf.Abs(pos.x - center.x) > 2f)
        {
            if (pos.x > center.x)
            {
                direction = -maxSpeed;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                direction = maxSpeed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (isTouchingGround && ((pos.y - center.y) < -0.2f) && canJump)
            {
                enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
                canJump = false;
                if (level == 1) SelfesteemAnimator.Play("selfesteem1jump");
                else if (level == 2) SelfesteemAnimator.Play("selfesteem2jump");
                else if (level == 3) SelfesteemAnimator.Play("selfesteem3jump");

            }
            else if (isTouchingGround)
            {
                enemyRigidBody.velocity = new Vector2(direction, enemyRigidBody.velocity.y);
                if (level == 1) SelfesteemAnimator.Play("selfesteem1walk");
                else if (level == 2) SelfesteemAnimator.Play("selfesteem2walk");
                else if (level == 3) SelfesteemAnimator.Play("selfesteem3walk");
            }
            else if (!isTouchingGround)
            {
                enemyRigidBody.velocity = new Vector2(direction, enemyRigidBody.velocity.y);
                if (level == 1) SelfesteemAnimator.Play("selfesteem1jump");
                else if (level == 2) SelfesteemAnimator.Play("selfesteem2jump");
                else if (level == 3) SelfesteemAnimator.Play("selfesteem3jump");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(3))
        {
            isTouchingGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.IsTouchingLayers(3))
        {
            isTouchingGround = false;
        }    
    }
}