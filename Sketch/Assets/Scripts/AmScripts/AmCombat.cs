using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmCombat : MonoBehaviour
{
    public float timeStunned;
    private float stunTime;
    public Vector2 knockbackDistance;

    public bool isStunned(){
        return stunTime < timeStunned;
    }

    public void stunAm(){
        Debug.Log("Stunning Am");
        stunTime = 0;
    }

    public void getHit(Rigidbody2D enemyRigidBody, int damage){
        Debug.Log("Called getHit");
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

        stunAm();
    }

    void Update(){
        if (isStunned()){
            stunTime += Time.deltaTime;
        }
    }
}
