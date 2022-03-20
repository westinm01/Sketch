using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchWorm : EnemyMovement
{
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    protected override void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        base.Start(); 
    }

    // Update is called once per frame
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if ( playerDistance < targetDistance )
        {
            moveSpeed = maxSpeed;
            if ( gameObject.transform.position.y <= -3.8 )
            {
                if ( rb.velocity.x < 0 )
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                move();
            }
        }
        else
        {
            enemyRigidBody.velocity = Vector2.zero;
        }
    }
}
