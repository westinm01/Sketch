using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduBossMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float attackTime;
    [SerializeField] private float crouchTime;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private Vector3 leftHandPos;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private Vector3 rightHandPos;
    [SerializeField] private Transform groundPos;


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

    private void Jump(){
        anim.Play("MeduStomp");
        rb.velocity = new Vector2(0, jumpHeight);
    }

    private void Slap(){
        anim.Play("MeduSlapDown");
        crouchTimer = 0;
        int randSlap = Random.Range(0, 2);
        switch (randSlap){
            case 0:
                StartCoroutine(SlapRight());
                break;
            case 1:
                StartCoroutine(SlapRight());
                break;
            default:
                break;
        }
    }

    IEnumerator SlapRight(){
        // gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        while (rightHand.transform.position != groundPos.transform.position){
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, groundPos.transform.position, 6 * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Right hand has reached new pos");
        yield return new WaitForSeconds(crouchTime);
        Debug.Log("Done waiting");
        while (rightHand.transform.position != rightHandPos){
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, leftHandPos, 6 * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Right hand has returned to initial position");
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
            // Jump();
            Slap();
            attackTimer = 0;
        }
        else{
            attackTimer += Time.deltaTime;
        }
    }
}
