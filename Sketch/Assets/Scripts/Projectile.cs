using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float maxDistance;
    public int damage;

    private float distTraveled;
    private Rigidbody2D rb;

    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Collision it " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(rb, damage); // Am only takes 1 damage for now
                Destroy(this.gameObject);
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Trigger hit " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(rb, damage);
                Destroy(this.gameObject);
            }
        }
    }

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        distTraveled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distTraveled += Time.deltaTime * speed;
        if (maxDistance != 0 && distTraveled > maxDistance){
            Destroy(this.gameObject);
        }
    }
}
