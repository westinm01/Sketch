using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage;
    public bool DisappearOnHit;
    public Rigidbody2D enemyRigidBody;
    private void Start(){
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, damage); // Am only takes 1 damage for now
                Debug.Log("jdfgnjkdfngjks collision");
                if (DisappearOnHit){
                    Debug.Log("Destroying ahzjsdn");
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, damage);
                Debug.Log("jdfgnjkdfngjks trigger");
                if (DisappearOnHit){
                    Debug.Log("Destroying ahzjsdn");
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
