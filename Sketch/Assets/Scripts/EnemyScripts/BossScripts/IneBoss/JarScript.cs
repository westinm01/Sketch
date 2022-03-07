using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    private PolygonCollider2D coll;
    private Animator anim;
    private Rigidbody2D rb;
    private EnemyGroundCheck groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        coll = gameObject.GetComponent<PolygonCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = gameObject.GetComponentInChildren<EnemyGroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("JarFall") && (groundCheck.isGrounded || transform.position.y <= -6)){
            anim.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("JarCracked")){
            rb.gravityScale = 0;
            coll.enabled = false;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("JarDestroyed")){
            Destroy(this.gameObject);
        }
    }
}
