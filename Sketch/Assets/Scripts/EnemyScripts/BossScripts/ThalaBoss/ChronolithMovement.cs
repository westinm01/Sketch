using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronolithMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float rightSide;
    public float leftSide;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        rb.velocity = new Vector2 (speed, 0);
    }

    private void move()
    {
        // float rightSide = 11;
        // float leftSide = -11;
        if ( gameObject.transform.position.x > rightSide && rb.velocity.x > 0 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        }
        else if ( gameObject.transform.position.x < leftSide && rb.velocity.x < 0 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(speed, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        move(); 
        //Debug.Log(gameObject.transform.position.x);
    }
}
