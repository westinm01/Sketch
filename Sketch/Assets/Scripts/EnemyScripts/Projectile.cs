using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float maxDuration;
    public int damage;
    public bool disappearOnHit;

    private float duration;
    private Rigidbody2D rb;

    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Collision it " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(rb, damage); // Am only takes 1 damage for now
                if (disappearOnHit){
                    Destroy(this.gameObject);
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Trigger hit " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(rb, damage);
                if (disappearOnHit){
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        duration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        if (duration > maxDuration){
            Debug.Log(maxDuration);
            Destroy(this.gameObject);
        }
    }
}
