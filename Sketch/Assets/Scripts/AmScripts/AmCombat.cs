using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmCombat : MonoBehaviour
{
    private float stunTimer;
    private float stunTime;
    public Vector2 knockbackDistance;

    public bool isStunned(){
        return stunTimer < stunTime;
    }
    public void getHit(Rigidbody2D enemyRigidBody, int damage){
        for (int i = 0; i < damage; i++) GetComponent<HeartSystem>().TakeDamage(1);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 a = rb.velocity;
        Vector2 b = transform.position;

        Vector2 direction;

        /*if (rb.velocity.normalized.Equals(Vector2.zero))
        {
            direction = enemyRigidBody.velocity.normalized;
        }
        else
        {
            direction = -rb.velocity.normalized;
        }
        rb.velocity = direction * new Vector2(7, 5);
*/
        direction = (rb.position - enemyRigidBody.position).normalized;

        rb.velocity = direction * knockbackDistance;

        stunTime = 0.5f;
        stunTimer = 0;
    }

    void Update(){
        if (stunTimer < stunTime){
            stunTimer += Time.deltaTime;
        }
    }
}
