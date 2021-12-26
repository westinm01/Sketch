using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Am_Movement : MonoBehaviour
{

    [HideInInspector] public Rigidbody2D rb;
    public float horizontalSpeed;
    public float jumpHeight;
    public Animator anim;
    [HideInInspector] public bool canJump = true;
    private ChangePencilMode mode;
    private AmCombat combat;

    private GameManager gm;
    private Vector2 m_Velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        mode = gameObject.GetComponent<ChangePencilMode>();
        combat = gameObject.GetComponent<AmCombat>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isPaused){
            return;
        }
        
        if (gameObject.GetComponent<AmCombat>().isStunned()){
            anim.SetBool("isStunned", true);
            return;
        }
        else{
            anim.SetBool("isStunned", false);
        }
        
        if (mode.canDraw){
            anim.SetBool("isDrawMode", true);
        }
        else{
            anim.SetBool("isDrawMode", false);
        }
        // Move the character by finding the target velocity
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.fixedDeltaTime, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, 0.05f);
        //speed for animation

        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * horizontalSpeed));
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if ( anim.GetBool("IsJumping") == false && !anim.GetCurrentAnimatorStateInfo(0).IsName("Am_Erase") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Am_Draw"))
            {
                if (mode.canDraw){
                    anim.Play("Am_Walk");
                }
                else{
                    anim.Play("Am_Walk_Erase");
                }            
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if ( anim.GetBool("IsJumping") == false && !anim.GetCurrentAnimatorStateInfo(0).IsName("Am_Erase") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Am_Draw"))
            {
                if (mode.canDraw){
                    anim.Play("Am_Walk");
                }
                else{
                    anim.Play("Am_Walk_Erase");
                }
            }
        }

        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(0, jumpHeight));
            canJump = false;
            anim.SetBool("IsJumping", true);
        }
    }
}