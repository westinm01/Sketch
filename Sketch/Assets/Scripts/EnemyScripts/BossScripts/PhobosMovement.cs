using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosMovement : MonoBehaviour
{
    public float dashSpeed;
    public GameObject idleColliders;
    public GameObject dashColliders;
    private Animator anim;
    private Rigidbody2D rb;
    public void Dash(){
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(15, 21.5f);
        anim.Play("PhobosWalk");
        idleColliders.SetActive(false);
        dashColliders.SetActive(true);
        rb.velocity = new Vector2(-dashSpeed, 0);
    }

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Dash();
    }

    void Update(){
        if (gameObject.transform.position.x <= -20){
            gameObject.transform.position = new Vector3(2, 21.5f);
            anim.Play("phobosIdle");
            idleColliders.SetActive(true);
            dashColliders.SetActive(false);
            rb.gravityScale = 1;
            rb.velocity = Vector2.zero;
        }
    }
}
