using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempraMovement : EnemyMovement
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    protected override void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(amPlayer);
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
            if ( enemyRigidBody.velocity.x < 0 )
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.Play("NeutralFly");
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
                move();
            }
        else
        {
            enemyRigidBody.velocity = Vector2.zero;
        }
    }
}
