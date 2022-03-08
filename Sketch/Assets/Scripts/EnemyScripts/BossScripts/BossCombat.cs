using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody; 
    [HideInInspector] public float stunTimer = 0f;
    public float stunTime = 1.0f;
    public int health = 4;
    public SpriteRenderer sr;
    public GameObject endFlag;          // Optional, add endFlag prefab if you want to spawn endFlag after killing the boss
    public Vector3 endFlagPos;
    public float maxHealth;
    protected virtual void Start()
    {
        maxHealth = health;
    }

    public void InstantiateEndFlag(){
        Instantiate(endFlag, endFlagPos, Quaternion.identity);
    }

    public virtual void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        health--;
        if (health == 0)
        {
            Debug.Log("Boss is dead");
            if (endFlag != null){
                Invoke("InstantiateEndFlag", 2f);
                gameObject.SetActive(false);
                Destroy(this.gameObject, 2f);
            }
            else{
                Destroy(this.gameObject);
            }
        }
        FlashRed();
        Invoke("StopFlash", 0.1f);
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
                    // Debug.Log("Boss collision");
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
                    // Debug.Log("Boss trigger");
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

    virtual protected void FlashRed()
    {
        // sr.color = new Color(1f, 0f, 0f, health / maxHealth);
        sr.color = new Color(1f, 1f, 1f, 0.05f);
    }

    virtual protected void StopFlash()
    {
        sr.color = new Color(1f, 1f, 1f, (1.0f * health) / maxHealth);
    }
}