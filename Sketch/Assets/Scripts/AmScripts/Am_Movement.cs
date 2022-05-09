using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Am_Movement : MonoBehaviour
{

    [HideInInspector] public Rigidbody2D rb;
    public float horizontalSpeed;
    public float jumpHeight;
    public float shortHopConstant;          // How effective shorthopping is
    public float shortHopWindow;            // How much time the player has to release the jump key and fall faster
    public Animator anim;
    public TrailRenderer trail;
    [HideInInspector] public bool canJump = true;
    public bool isFrozen = false;
    private ChangePencilMode mode;
    private AmCombat combat;
    private bool right = true;
    private GameManager gm;
    private Vector2 m_Velocity = Vector2.zero;
    private float jumpTimer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        DataSave.LoadData();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        mode = gameObject.GetComponent<ChangePencilMode>();
        trail = gameObject.GetComponent<TrailRenderer>();
        combat = gameObject.GetComponent<AmCombat>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        trail.time = -2;
    }

    protected virtual IEnumerator ShortHop(){
        jumpTimer = shortHopWindow;
        canJump = false;
        anim.SetBool("IsJumping", true);
        rb.AddForce(new Vector2(0, jumpHeight));

        // Check to see if button is still being pressed
        while (StaticControls.GetButton("Jump") && jumpTimer >= 0){
            jumpTimer -= Time.deltaTime;
            yield return null;
        }

        // If button let go early, make Am fall faster
        if (jumpTimer > 0f){
            rb.AddForce(new Vector2(0, -shortHopConstant));
        }
    }

    public IEnumerator FreezeAm(float timeFrozen){
        Debug.Log("Freezing am");
        isFrozen = true;
        yield return new WaitForSeconds(timeFrozen);
        isFrozen = false;
        Debug.Log("Unfreezing am");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (gm.isPaused || isFrozen){
            return;
        }
        // Debug.Log("isStunned: " + anim.GetBool("isStunned"));
        // Debug.Log("isDrawMode: " + anim.GetBool("isDrawMode"));
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
        // Vector2 targetVelocity = Vector2.zero;
        // if (StaticControls.GetKeyDown("Right")){
        //     targetVelocity = new Vector2(1, 0);
        // }
        // else if (StaticControls.GetKeyDown("Left")){
        //     targetVelocity = new Vector2(-1, 0);
        // }
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, 0.05f);
        //speed for animation

        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * horizontalSpeed));
        if (Input.GetAxisRaw("Horizontal") > 0)
        // if (StaticControls.GetKeyDown("Right"))
        {
            // Debug.Log("Right key pressed");
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
        // else if (StaticControls.GetKeyDown("Left"))
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

        if(StaticControls.GetButton("Jump") && canJump)
        {
            StartCoroutine(ShortHop());
        }
        // if (Input.GetButtonDown("Jump") && canJump){
        //     rb.AddForce(new Vector2(0, jumpHeight));
        //     canJump = false;
        //     anim.SetBool("IsJumping", true);
        // }

        if(StaticControls.GetKeyDown("Right")) {
            right = true;
        }
        if(StaticControls.GetKeyDown("Left")) {
            right = false;
        }

        if (StaticInfo.health == 15){
            if(Input.GetKey("p") && rb.velocity.y < .5) {
            trail.time = 2;
                rb.drag = 15;
                int a = 0;
                if(right) a = 1;
                else a = -1;
                rb.velocity = Vector3.right * 15 *  a;
            } else {
                trail.time = -2;
                rb.drag = 0;
            }
        }
    }
}