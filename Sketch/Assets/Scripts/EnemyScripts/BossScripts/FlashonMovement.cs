using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class FlashonMovement : BossCombat
{
    public float delay;
    float timer;
    public float rotateSpeed;
    public GameObject Camera;
    float rotation = 0;
    public Transform[] positions;
    GameObject nextTarget;
    public float speed;
    GameObject am;
    public GameObject floor, wall;
    public Animator animator;
    public bool isTournamentMode = false;
    public AudioSource aud;

    protected override void Start()
    {
        timer = delay;
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
            animator.Play("Flashon_Flash");
            Invoke("flipGravity", 0.25f);
            aud.Play();
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
        Invoke("whiteScreen", 0.0f);
        Invoke("normalScreen", 0.45f);
        GameObject map = GameObject.Find("Map");
        float temp;
        temp = Random.Range(0, 4);
        while (rotation == temp)
        {
            temp = Random.Range(0, 4);
        }
        rotation = temp * 90;
        map.transform.rotation = Quaternion.Euler(0, 0, rotation);
        if (rotation == 0 || rotation == 360)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            am.transform.rotation = Quaternion.Euler(0, 0, 0);
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rotation == 90)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = -90;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            am.transform.rotation = Quaternion.Euler(0, 0, 360);
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 360);
        }
        else if (rotation == 180)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = -180;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            am.transform.rotation = Quaternion.Euler(0, 0, 0);
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rotation == 270)
        {
            floor.GetComponent<PlatformEffector2D>().rotationalOffset = 270;
            floor.GetComponent<PlatformEffector2D>().surfaceArc = 360;
            wall.GetComponent<PlatformEffector2D>().rotationalOffset = 90;
            wall.GetComponent<PlatformEffector2D>().surfaceArc = 160;
            am.transform.rotation = Quaternion.Euler(0, 0, 360);
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, 360);
        }

    }

    public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        animator.Play("Flashon_Hurt");
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Boss is dead");

            if (isTournamentMode){
                TournamentEndofLevel.WinGame(am.GetComponent<Collider2D>());
            }
            else{
                EndOfLevel.WinGame(am.GetComponent<Collider2D>());

            }

        }
        else if (health == 3)
        {
            delay = 6;
            speed=speed+2;
            sr.color = new Color(1f, 1f, 1f, 0.75f);
        }
        else if (health == 2)
        {
            delay = 4;
            speed=speed+2;
            sr.color = new Color(1f, 1f, 1f, 0.50f);
        }
        else if (health == 1)
        {
            delay = 2;
            speed=speed+2;
            sr.color = new Color(1f, 1f, 1f, 0.25f);
        }
        stunTimer = 0f;
    }

    void getNextTarget()
    {
        if (Mathf.Abs((transform.position - positions[0].position).magnitude) < 0.05)
        {
            nextTarget = positions[1].gameObject;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180 + rotation);
        }
        else if (Mathf.Abs((transform.position - positions[1].position).magnitude) < 0.05)
        {
            nextTarget = positions[2].gameObject;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90 + rotation);

        }
        else if (Mathf.Abs((transform.position - positions[2].position).magnitude) < 0.05)
        {
            nextTarget = positions[3].gameObject;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0 + rotation);
        }
        if (Mathf.Abs((transform.position - positions[3].position).magnitude) < 0.05)
        {
            nextTarget = positions[0].gameObject;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 270 + rotation);
        }
    }
    
    void whiteScreen()
    {
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 1);
    }

    void normalScreen()
    {
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, -15);
    }    

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(positions[0].position, positions[1].position);
        Gizmos.DrawLine(positions[1].position, positions[2].position);
        Gizmos.DrawLine(positions[2].position, positions[3].position);
        Gizmos.DrawLine(positions[3].position, positions[0].position);
    }
}
