using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Am_Movement : MonoBehaviour
{

    Rigidbody2D rb;

    public float horizontalSpeed;
    public float jumpHeight;

    [HideInInspector] public bool canJump = true;
    private Vector2 m_Velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Move the character by finding the target velocity
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.fixedDeltaTime, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, 0.05f);

        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0, jumpHeight));
            canJump = false;
        }
    }
}