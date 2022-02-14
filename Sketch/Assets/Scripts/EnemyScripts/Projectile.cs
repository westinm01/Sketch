using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float maxDuration;
    public float followTime;
    public int damage;
    public bool disappearOnHit;
    public bool followAm;

    private float duration;
    private Rigidbody2D rb;
    private GameObject am;

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
        else if (collision.gameObject.tag != "Enemy" && disappearOnHit){
                    Destroy(this.gameObject);
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
        am = GameObject.FindGameObjectWithTag("Player");
        if (direction.x > 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        duration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (followAm && followTime > 0){
            Vector3 currPos = gameObject.transform.position;
            Vector3 amPos = am.transform.position;
            Vector3 force = amPos - currPos;
            force = force.normalized;
            force *= 3;
            rb.AddForce(force);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
            followTime -= Time.deltaTime;
        }
        duration += Time.deltaTime;
        if (duration > maxDuration){
            Destroy(this.gameObject);
        }
    }
}
