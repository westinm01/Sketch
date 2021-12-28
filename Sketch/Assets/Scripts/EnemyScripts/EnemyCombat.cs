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
    public float recoilForce = 3;

    public GameObject level1Form;
    public GameObject level2Form;
    public GameObject level3Form;
    public float stunTimer = 0f;
    public float stunTime = 1.0f;

    // public virtual void stunEnemy(Rigidbody2D playerRigidBody){
    //     Debug.Log("Enemy was hit");
    //     Vector2 direction = playerRigidBody.transform.right;
    //     Debug.Log(direction);
    //     // Debug.Log(collision.attachedRigidbody.velocity.normalized);
    //     // if (playerRigidBody.velocity.normalized.Equals(Vector2.zero)){
    //     //     direction = -enemyRigidBody.velocity.normalized;
    //     // }
    //     // else{
    //     //     direction = playerRigidBody.velocity.normalized;
    //     // }
    //     enemyRigidBody.velocity = new Vector2(100, 100);
    //     stunTimer = 0;
    // }
    public virtual bool isStunned(){
        return stunTimer < stunTime;
    }

    public virtual void enemyTakeDamage(Rigidbody2D playerRigidBody){
        GameObject newObj = this.gameObject;    //temporary gameobject holder
        Vector2 currPos = gameObject.transform.position;
        Vector2 currVelocity = enemyRigidBody.velocity;
        Destroy(this.gameObject);
        if (level == 1){
            return;
        }
        if (level == 2){
            newObj = (GameObject)Instantiate(level1Form, currPos, Quaternion.identity);
        }
        else if (level == 3){
            newObj = (GameObject)Instantiate(level2Form, currPos, Quaternion.identity);
        }
        newObj.GetComponent<Rigidbody2D>().velocity = playerRigidBody.transform.right * recoilForce;
        stunTimer = 0;
        // newObj.GetComponent<EnemyCombat>().stunEnemy(playerRigidBody);
        
    }

    public virtual void enemyLevelUp(){
        if (level == 3){
            return;
        }

        Vector2 currPos = gameObject.transform.position;
        Destroy(this.gameObject);
        if (level == 1){
            GameObject newObj = (GameObject)Instantiate(level2Form, currPos + new Vector2(0, 0.5f), Quaternion.identity);
        }
        else if (level == 2){
            GameObject newObj = (GameObject)Instantiate(level3Form, currPos + new Vector2(0, 0.5f), Quaternion.identity);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned()){
                if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                    collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, level); // Am only takes 1 damage for now
                    if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){
                        Debug.Log("Am hit in draw mode");
                        enemyLevelUp();
                    }
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
            Debug.Log("Hit " + collision.gameObject.name);
            if (!isStunned()){
                if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
                    collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, level);
                    if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){
                        Debug.Log("Am hit in draw mode");
                        enemyLevelUp();
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

    protected virtual void Update(){
        if (stunTimer < stunTime){
            stunTimer += Time.deltaTime;
        }
    }
}
