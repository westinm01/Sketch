using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCombat : EnemyCombat
{
    protected override void OnTriggerEnter2D(Collider2D collision){
        base.OnTriggerEnter2D(collision);
        if (collision.attachedRigidbody.tag == "Player" && collision.gameObject.layer == 0){
            if (level > 3){   // if Am is in draw mode
                if (level == 2){    //level already increased by base function
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny2_0");
                }
                else if (level == 3){
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny3_0");
                }
            }
            else{           //Am is in erase mode
                if (level == 1){ // level already decreased by base function
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny1_0");
                }
                else if (level == 2){
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Art/Enemies/Bunny/SSbunny2_0");
                }
            }
        }
    }
}
