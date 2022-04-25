using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronolithCombat : BossCombat
{
    public override void bossTakeDamage(Rigidbody2D playerRigidBody){
        gameObject.GetComponent<Animator>().Play("BossHurt");
        base.bossTakeDamage(playerRigidBody);
        if (health == 0){
            GameObject[] worms = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] clocks = GameObject.FindGameObjectsWithTag("Unerasable");
            foreach (GameObject worm in worms){
                Destroy(worm);
            }
            foreach (GameObject clock in clocks){
                Destroy(clock);
            }
        }
        gameObject.GetComponent<ChronolithMovement>().UnfreezeBoss();
    }

    protected override void OnCollisionEnter2D(Collision2D collision){
        // if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
        //     Debug.Log("Hit " + collision.gameObject.name);
        //     if (!isStunned()){
        //         if (!collision.gameObject.GetComponent<AmCombat>().isStunned())
        //         {   // if Am is in draw mode
        //             // Debug.Log("Boss trigger");
        //             collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, 1); // Am only takes 1 damage for now
        //         }
        //     }
        // }
    }
}
