using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleKill : MonoBehaviour
{
    public int killVelocity;
    private Rigidbody2D body;
    void Start(){
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy" && body.velocity.y <= killVelocity){
            Destroy(collision.gameObject);
        }
    }
}
