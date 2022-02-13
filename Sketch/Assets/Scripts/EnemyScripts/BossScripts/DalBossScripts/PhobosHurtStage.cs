using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosHurtStage : BossCombat
{
    public BossCombat boss;

    public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        boss.bossTakeDamage(playerRigidBody);
    }
}
