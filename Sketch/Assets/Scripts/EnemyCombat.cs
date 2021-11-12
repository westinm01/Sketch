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


    protected virtual void takeDamage(Collider2D collision){
        // level--;
        movement.stun(collision);
    }

    public virtual bool isStunned(){
        return movement.stunTimer < movement.stunTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.attachedRigidbody.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 a = rb.velocity;
            Vector2 b = transform.position;

            Vector2 direction;

            if (rb.velocity.normalized.Equals(Vector2.zero))
            {
                direction = -enemyRigidBody.velocity.normalized;
            }
            else
            {
                direction = collision.attachedRigidbody.velocity.normalized;
            }
            rb.velocity = direction * 100;
            if (level > 4){   // if Am is in draw mode
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
                    takeDamage(collision);
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
    }

    // Update is called once per frame
     protected virtual void Update()
    {
    }
}
