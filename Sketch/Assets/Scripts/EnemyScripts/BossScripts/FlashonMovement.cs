using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashonMovement : BossCombat
{
    public float delay;
    float timer;
    bool canRotate = false;
    public float rotateSpeed;
    public GameObject Camera;
    SpriteRenderer sr;
    float rotation;
    public Transform[] positions;
    Vector3 nextTarget;
    public float speed;

    private void Start()
    {
        timer = delay;
        sr = GetComponent<SpriteRenderer>();
        nextTarget = positions[1].position;
    }
    protected override void Update()
    {
        Camera.transform.rotation = Quaternion.RotateTowards(Camera.transform.rotation, Quaternion.Euler(0, 0, rotation), rotateSpeed);
        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }

        if (timer < 0)
        {
            flipGravity();
            timer = delay;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextTarget, speed * Time.deltaTime);
        getNextTarget();
    }


    void flipGravity()
    {
        float temp = Random.Range(0, 4) * 90;
        while (rotation == temp)
        {
            temp = Random.Range(0, 4) * 90;
        }
        rotation = temp;
    }

    public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Boss is dead");
        }
        else if (health == 3)
        {
            delay = 6;
            sr.color = new Color(0.8f, 0.8f, 0.8f);
        }
        else if (health == 2)
        {
            delay = 4;
            sr.color = new Color(0.7f, 0.7f, 0.7f);
        }
        else if (health == 1)
        {
            delay = 2;
            sr.color = new Color(0.6f, 0.6f, 0.6f);
        }
        timer = -1;
        stunTimer = 0f;
    }

    void getNextTarget()
    {
        if (Mathf.Abs((transform.position - positions[0].position).magnitude) < 0.25)
        {
            nextTarget = positions[1].position;
        }
        else if (Mathf.Abs((transform.position - positions[1].position).magnitude) < 0.25)
        {
            nextTarget = positions[2].position;
        }
        else if (Mathf.Abs((transform.position - positions[2].position).magnitude) < 0.25)
        {
            nextTarget = positions[3].position;
        }
        if (Mathf.Abs((transform.position - positions[3].position).magnitude) < 0.25)
        {
            nextTarget = positions[0].position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(positions[0].position, positions[1].position);
        Gizmos.DrawLine(positions[1].position, positions[2].position);
        Gizmos.DrawLine(positions[2].position, positions[3].position);
        Gizmos.DrawLine(positions[3].position, positions[0].position);
    }
}
