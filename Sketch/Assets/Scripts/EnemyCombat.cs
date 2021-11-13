using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    protected Rigidbody2D enemyRigidBody;
    public int level = 1;
    protected Animator animator;
    protected Vector3 evolutionScale;
    protected EnemyMovement movement;
    protected Vector2 knockbackForce;

    public float stunTimer = 1.0f;
    public float stunTime = 1.0f;

    public virtual void stun(Rigidbody2D playerRigidBody){
        Vector2 direction;
        // Debug.Log(collision.attachedRigidbody.velocity.normalized);
        if (playerRigidBody.velocity.normalized.Equals(Vector2.zero)){
            direction = -enemyRigidBody.velocity.normalized;
        }
        else{
            direction = playerRigidBody.velocity.normalized;
        }
        enemyRigidBody.velocity = direction * knockbackForce;
        stunTimer = 0;
    }
    public virtual bool isStunned(){
        return stunTimer < stunTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){   // if Am is in draw mode
                Debug.Log("Am hit in draw mode");
                collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody);
                if (level == 1){
                    level++;
                    gameObject.transform.localScale += evolutionScale;
                }
                else if (level == 2){
                    level++;
                    gameObject.transform.localScale += evolutionScale;
                }
            }
            else{       // Am is in erase mode
                if (!isStunned()){
                    stun(collision.gameObject.GetComponent<Rigidbody2D>());
                    if (level == 1){
                        Debug.Log("Destroying object");
                        Destroy(this.gameObject);
                    }
                    else if (level == 2){
                        level--;
                        gameObject.transform.localScale -= evolutionScale;
                    }
                    else if (level == 3){
                        level--;
                        gameObject.transform.localScale -= evolutionScale;
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        movement = gameObject.GetComponent<EnemyMovement>();
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        evolutionScale = new Vector3(0.3f, 0.3f, 0.3f);
        knockbackForce = new Vector2(4, 4);

    }

    protected virtual void Update(){
        if (stunTimer < stunTime){
            stunTimer += Time.deltaTime;
        }
    }
}
