using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduBossMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float attackTime;
    [SerializeField] private float crouchTime;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    private float attackTimer;
    private float crouchTimer;
    private Animator anim;
    private Rigidbody2D rb;
    private BossCombat combat;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        combat = gameObject.GetComponentInChildren<BossCombat>();
        attackTimer = 0;
    }

    public void Jump(){
        anim.Play("MeduStomp");
        rb.velocity = new Vector2(0, jumpHeight);
    }

    private void Slap(){
        gameObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 2) * 180, 0);
        anim.Play("MeduSlapDown");
        crouchTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (combat == null){
            Destroy(this.gameObject);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("MeduCrouch")){
            if (crouchTimer >= crouchTime){     // Done crouching
                anim.enabled = true;
            }
            else{                               // Freeze the animation if crouching
                anim.enabled = false;
                crouchTimer += Time.deltaTime;
                attackTimer = 0;
            }
        }
        if (attackTimer >= attackTime){
            Jump();
            gameObject.GetComponent<MeduSpawnEnemy>().spawnEnemy();
            // Slap();
            attackTimer = 0;
        }
        else{
            attackTimer += Time.deltaTime;
        }
    }
}
