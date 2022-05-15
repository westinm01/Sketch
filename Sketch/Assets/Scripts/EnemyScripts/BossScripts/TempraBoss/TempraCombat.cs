using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempraCombat : BossCombat
{
    private Animator anim;
    private TempraMovement movement;
    // Start is called before the first frame update
    protected override void Start()
    {
        movement = gameObject.GetComponent<TempraMovement>();
        anim = gameObject.GetComponent<Animator>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "SpawnedShape" || collision.gameObject.tag == "Player" && movement.currentPhase == "neutral" )
        {
            movement.currentPhase = "happy";
            anim.Play("NeutralHappy");
            Debug.Log("Turn into Happy");
            gameObject.GetComponent<Rigidbody2D>().velocity = collision.transform.right * 2;
            if (collision.gameObject.tag == "SpawnedShape"){
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!collision.gameObject.GetComponent<AmCombat>().isStunned())
            {   // if Am is in draw mode
                // Debug.Log("Boss collision");
                collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, 1); // Am only takes 1 damage for now
            }
        }
    }

    public override void bossTakeDamage(Rigidbody2D playerrigidbody)
    {
        if ( movement.currentPhase == "happy" )
        {
            sr.color = new Color(1f, 1f, 1f, (1.0f * health) / maxHealth);
            base.bossTakeDamage(playerrigidbody);
            movement.timerChange(); 
            movement.currentPhase = "angry";
            anim.Play("HappyToAngry");
            
        } 
    }
    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
