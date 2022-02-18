using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduBossMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float attackTime;

    private float attackTimer;
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackTimer = 0;
    }

    private void Jump(){
        anim.Play("MeduStomp");
        rb.velocity = new Vector2(0, jumpHeight);
    }

    private void Slap(){
        gameObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 2) * 180, 0);
        anim.Play("MeduSlap");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer >= attackTime){
            // Jump();
            Slap();
            attackTimer = 0;
        }
        else{
            attackTimer += Time.deltaTime;
        }
    }
}
