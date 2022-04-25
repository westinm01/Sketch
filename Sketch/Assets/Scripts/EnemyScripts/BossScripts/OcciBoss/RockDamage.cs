using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDamage : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    [HideInInspector] public float stunTimer = 0f;
    public float stunTime = 1.0f;
    public int health = 4;
    public SpriteRenderer sr;
    float maxHealth;
    private void Start()
    {
        maxHealth = health;
    }
    public virtual void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Boss is dead");
        }
        flashRed();
        Invoke("stopFlash", 0.1f);
        stunTimer = 0f;
    }

    public virtual bool isStunned()
    {
        return stunTimer < stunTime;
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned())
            {
                if (!collision.gameObject.GetComponent<AmCombat>().isStunned())
                {   // if Am is in draw mode
                    collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, 1); // Am only takes 1 damage for now
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned())
            {
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

    void flashRed()
    {
        // sr.color = new Color(1f, 0f, 0f, health / maxHealth);
        sr.color = new Color(1f, 1f, 1f, 0.05f);
    }

    void stopFlash()
    {
        sr.color = new Color(1f, 1f, 1f, health / maxHealth);
    }
}
