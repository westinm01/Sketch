using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody; 
    [HideInInspector] public float stunTimer = 0f;
    public float stunTime = 1.0f;
    public int health = 4;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public virtual void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Boss is dead");
        }
        else if (health == 3)
        {
            sr.color = new Color(1f, 1f, 1f, 0.75f);
        }
        else if (health == 2)
        {
            sr.color = new Color(1f, 1f, 1f, 0.50f);
        }
        else if (health == 1)
        {
            sr.color = new Color(1f, 1f, 1f, 0.25f);
        }
        stunTimer = 0f;
    }

    public virtual bool isStunned()
    {
        return stunTimer < stunTime;
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned()){
                if (!collision.gameObject.GetComponent<AmCombat>().isStunned())
                {   // if Am is in draw mode
                    collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, 1); // Am only takes 1 damage for now
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned()){
                if (!collision.gameObject.GetComponent<AmCombat>().isStunned())
                {   // if Am is in draw mode
                    collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, 1); // Am only takes 1 damage for now
                }
            }
        }
    }

    protected virtual void Update()
    {
        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }
    }
}