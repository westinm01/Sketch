using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronolithCombat : BossCombat
{
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
