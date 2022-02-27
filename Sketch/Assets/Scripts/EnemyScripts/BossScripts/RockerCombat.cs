using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerCombat : BossCombat
{
    // Start is called before the first frame update
    public GameObject speaker;
    
    
     public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        
        //Vector2 ve=new Vector2(0,600);
        //enemyRigidBody.AddForce(ve);
        this.GetComponent<Transform>().position=new Vector3(6.34f,1f,0f);
        //Vector2 v = new Vector2(-1000000,0);
        //speaker.GetComponent<Rigidbody2D>().AddForce(v);//AddForce(v);
        //jump
        speaker.GetComponent<Transform>().position=new Vector3(6.69f,-3.01f,1f);
        base.bossTakeDamage(playerRigidBody);
        //Debug.Log("Jump");
        
    }
}
