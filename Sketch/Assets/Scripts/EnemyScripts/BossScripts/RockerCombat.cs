using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerCombat : BossCombat
{
    // Start is called before the first frame update
    public GameObject speaker;
    
    protected override void Update(){
        base.Update();
        if(this.GetComponent<Transform>().position.y>1.1f){
            speaker.GetComponent<Transform>().position=new Vector3(6.69f,-3.01f,1f);
        }

    }
     public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        
        Vector2 ve=new Vector2(0,475);
        enemyRigidBody.AddForce(ve);
        //this.GetComponent<Transform>().position=new Vector3(6.34f,1f,0f);
        //this.transform.GetChild(0).GetComponent<Transform>().position=new Vector3(0.23f,-1.39f,0f);
        //Vector2 v = new Vector2(-1000000,0);
        //speaker.GetComponent<Rigidbody2D>().AddForce(v);//AddForce(v);
        //jump
        
        base.bossTakeDamage(playerRigidBody);
        //Debug.Log("Jump");
        
    }
}
