using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmCombat : MonoBehaviour
{
    public float timeStunned;
    public float timeInvincible;
    public float flashFrequency;    // How often Am flashes when invincible
    private float stunTime;
    public Vector2 knockbackDistance;
    public bool isInvincible;
    private Animator anim;
    private SpriteRenderer sr;
    // private ChangePencilMode mode;

    void Start(){
        // mode = GetComponent<ChangePencilMode>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        isInvincible = false;
    }

    public bool isStunned(){
        return stunTime < timeStunned;
    }

    public void stunAm(){
        // Debug.Log("Stunning Am");
        if (anim.GetBool("isDrawMode")){
            anim.Play("Am_Stunned");
        }
        stunTime = 0;
    }

    public IEnumerator makeInvincible(){
        float invincibleTimer = 0;
        float flashTimer = 0;
        isInvincible = true;
        while (invincibleTimer < timeInvincible){
            if (flashTimer > timeInvincible/flashFrequency){
                Color newColor = sr.color;
                if (sr.color.a == 0.1f){
                    // Debug.Log("Setting alpha to 0");
                    newColor.a = 1;
                }
                else{
                    // Debug.Log("Setting alpha to 1");
                    newColor.a = 0.1f;
                }
                sr.color = newColor;
                flashTimer = 0;
            }

            flashTimer += Time.deltaTime;
            invincibleTimer += Time.deltaTime;
            yield return null;
        }
        Color alpha1 = sr.color;
        alpha1.a = 1;
        sr.color = alpha1;

        isInvincible = false;
    }

    public void getHit(Rigidbody2D enemyRigidBody, int damage){
        Debug.Log("Called getHit");
        if (isInvincible){
            return;
        }


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
        StartCoroutine(makeInvincible());
        stunAm();
    }

    void Update(){
        if (isStunned()){
            stunTime += Time.deltaTime;
        }
    }
}
