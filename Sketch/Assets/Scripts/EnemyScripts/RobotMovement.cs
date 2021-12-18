using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : EnemyMovement
{
    public int moveDistance;
    // Update is called once per frame
    protected override void Update()
    {
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            moveSpeed = 0;
        }
        
    }
}
