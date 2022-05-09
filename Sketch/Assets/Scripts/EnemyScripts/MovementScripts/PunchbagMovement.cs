using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchbagMovement : EnemyMovement
{
    public float slideSpeed = 2;
    public float jumpHeight = 2;
    protected Animator punchAnimator;
    protected float slideTimer;
    protected float direction;
    protected int level;
    public GameObject prefab;

    protected void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player" && col.gameObject.layer == 0) {
            int lucky = Random.Range(0, 200);
            if (lucky == 0){
                for(int i = 0; i < 6; i++) Instantiate(prefab, new Vector3(Random.Range(col.gameObject.transform.position.x-5, col.gameObject.transform.position.x+5), col.gameObject.transform.position.y+10, 0), Quaternion.identity);
            }

        }
    }

    protected override void move(){
        Vector2 pos = gameObject.transform.position;
        direction = -direction;
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
        if (direction < 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        slideTimer = 0;
    }
    protected void moveTowardsPlayer(){
        Vector2 pos = gameObject.transform.position;
        center = amPlayer.transform.position;
        if (pos.x < center.x){
            direction = maxSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            direction = -maxSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        enemyRigidBody.velocity = new Vector2(direction, jumpHeight);
        slideTimer = 0;
    }
    protected override void Start()
    {
        base.Start();
        punchAnimator = gameObject.GetComponent<Animator>();
        slideTimer = slideSpeed;
        direction = maxSpeed;
        level = gameObject.GetComponent<EnemyCombat>().level;
    }
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if (gameObject.GetComponent<EnemyCombat>().isStunned()){
            moveSpeed = 0;
        }
        else if (slideTimer >= slideSpeed){
            moveSpeed = maxSpeed;
            if (level == 1){
                punchAnimator.Play("punchingbag1");
            }
            else if (level == 2){
                punchAnimator.Play("punchingbag2");
            }
            if (playerDistance < targetDistance){
                moveTowardsPlayer();
            }
            else{
                move();
            }
        }
        else if (slideTimer < slideSpeed){
            slideTimer += Time.deltaTime;
        }
    }
}
