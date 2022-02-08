using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    GameObject nextTarget;
    public float speed;
    GameObject am;
    public GameObject floor, wall;

    private void Start()
    {
        timer = delay;
        sr = GetComponent<SpriteRenderer>();
        nextTarget = positions[1].gameObject;
        am = GameObject.Find("am-forward3");
    }
    protected override void Update()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, nextTarget.transform.position, speed * Time.deltaTime);
        getNextTarget();
    }


    void flipGravity()
    {
        GameObject map = GameObject.Find("Map");
        float temp;
        temp = Random.Range(0, 4);
        while (rotation == temp)
        {
            temp = Random.Range(0, 4);
        }
        rotation = temp * 90;
        map.transform.rotation = Quaternion.Euler(0, 0, rotation);
        getNextTarget();
        if (rotation == 0 || rotation == 360)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            am.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rotation == 90)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = -90;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            am.transform.rotation = Quaternion.Euler(0, 0, 360);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 360);
        }
        else if (rotation == 180)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = -180;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            am.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rotation == 270)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 270;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 90;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            am.transform.rotation = Quaternion.Euler(0, 0, 360);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 360);
        }

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
            nextTarget = positions[1].gameObject;
        }
        else if (Mathf.Abs((transform.position - positions[1].position).magnitude) < 0.25)
        {
            nextTarget = positions[2].gameObject;
        }
        else if (Mathf.Abs((transform.position - positions[2].position).magnitude) < 0.25)
        {
            nextTarget = positions[3].gameObject;
        }
        if (Mathf.Abs((transform.position - positions[3].position).magnitude) < 0.25)
        {
            nextTarget = positions[0].gameObject;
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
