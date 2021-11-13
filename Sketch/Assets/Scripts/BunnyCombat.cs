using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCombat : EnemyCombat
{
    protected BunnyMovement bMove;
    protected override void OnCollisionEnter2D(Collision2D collision){
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){   // if Am is in draw mode
                if (level == 2){    //level already increased by base function
                    bMove.jumpTime = 2; 
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny2_0");
                }
                else if (level == 3){
                    bMove.jumpTime = 1.5f;
                    bMove.maxSpeed = 2;
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny3_0");
                }
            }
            else{           //Am is in erase mode
                if (level == 1){ // level already decreased by base function
                    bMove.jumpTime = 2.5f; 
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny1_0");
                }
                else if (level == 2){
                    bMove.jumpTime = 2; 
                    bMove.maxSpeed = 1;
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny2_0");
                }
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        bMove = gameObject.GetComponent<BunnyMovement>();
    }
}
