using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashonMovement : BossCombat
{
    public float delay;
    float timer;
    public bool canRotate = false;
    public float rotateSpeed;
    public GameObject Camera;

    private void Start()
    {
        timer = delay;
    }
    protected override void Update()
    {
        if (canRotate)
        {
            Camera.transform.rotation = Quaternion.RotateTowards(Camera.transform.rotation, Quaternion.Euler(0, 0, 180), rotateSpeed);
        }
        else if (!canRotate)
        {
            Camera.transform.rotation = Quaternion.RotateTowards(Camera.transform.rotation, Quaternion.Euler(0, 0, 0), rotateSpeed);
        }
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
    }


    void flipGravity()
    {
        /*
         * GameObject.Find("am-forward3").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Physics2D.gravity *= -1;
        Debug.Log("Flipped gravity");
        */
        //GameObject.Find("Main Camera").transform.rotation *= Quaternion.Euler(0, 0, 180);
        canRotate = !canRotate;
    }
}
