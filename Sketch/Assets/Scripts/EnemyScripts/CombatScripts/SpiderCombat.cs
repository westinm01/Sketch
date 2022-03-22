using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCombat : EnemyCombat
{
    public override void enemyTakeDamage(Rigidbody2D playerRigidBody){
        EraseEffect.PlayEraseEffect(gameObject.transform.position);
        Destroy(this.gameObject);
    }

    public override void enemyLevelUp(){
        // Do nothing
    }
}
