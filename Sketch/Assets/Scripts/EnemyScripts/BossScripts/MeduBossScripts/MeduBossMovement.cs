using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduBossMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float attackTime;
    [SerializeField] private float crouchTime;
    [SerializeField] private GameObject HeadCollider;
    [SerializeField] private Vector3 initHeadPosition;  // Initial position of head
    [SerializeField] private Vector3 crouchHeadPosition;// Position of head while crouched
    [SerializeField] private GameObject leftHand;
    [SerializeField] private Vector3 leftHandInitPos;   // Initial position of left hand
    [SerializeField] private Vector3 leftHandUpPos;     // Position of left hand when slapping with right hand
    [SerializeField] private GameObject rightHand;
    [SerializeField] private Vector3 rightHandInitPos;  // Initial position of right hand
    [SerializeField] private GameObject groundPos;      // Position of the ground
    [SerializeField] private GameObject cam;
    [SerializeField] private Projectile shockwave;
    [SerializeField] private GameObject groundHitbox;
    [SerializeField] private float groundHitboxActiveTime;

    private float attackTimer;
    private float crouchTimer;
    private int attackPhase;
    private Animator anim;
    private Rigidbody2D rb;
    private BossCombat combat;
    private AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        combat = gameObject.GetComponentInChildren<BossCombat>();
        aud = gameObject.GetComponent<AudioSource>();
        attackTimer = 0;
        crouchTimer = 0;
        attackPhase = 0;
    }

    private void Jump(){
        anim.Play("MeduStomp");
        rb.velocity = new Vector2(0, jumpHeight);
        Invoke("CreateShockwaves", 0.5f);   // Boss lands after roughly 0.5 seconds
        Invoke("CallShakeScreen", 0.5f);
        Invoke("ActivateGroundHitbox", 0.5f);
    }

    private void CreateShockwaves(){
        Debug.Log("Creating shockwaves");
        aud.Play();
        Projectile leftShock = Instantiate(shockwave, groundPos.transform.position + new Vector3(0, 0.5f), Quaternion.identity).GetComponent<Projectile>();
        Projectile rightShock = Instantiate(shockwave, groundPos.transform.position + new Vector3(0, 0.5f), Quaternion.identity).GetComponent<Projectile>();
        leftShock.direction = new Vector2(-1, 0);
        rightShock.direction = new Vector2(1, 0);
    }

    private void CallShakeScreen(){
        StartCoroutine(ShakeScreen(1, 3));
    }
    IEnumerator ShakeScreen(float shakeTime, float intensity){
        Vector3 origPos = cam.transform.position;
        Rigidbody2D cambody = cam.GetComponent<Rigidbody2D>();
        float shakeTimer = 0;
        float timeBetweenShakes = 0.1f;
        float timer = 0;
        Vector2 direction = new Vector2(0, intensity);
        while (shakeTimer < shakeTime){
            if (timer >= timeBetweenShakes){
                direction = -direction;
                cambody.velocity = direction;
                timer = 0;
            }
            timer +=  Time.deltaTime;
            shakeTimer += Time.deltaTime;
            yield return null;
        }
        cambody.velocity = Vector2.zero;
        cam.transform.position = origPos;
    }

    IEnumerator ActivateGroundHitbox(){
        groundHitbox.SetActive(true);
        yield return new WaitForSeconds(groundHitboxActiveTime);
        groundHitbox.SetActive(false);
    }

    private void Slap(){
        // gameObject.transform.rotation = Quaternion.Euler(0, Random.Range(0, 2) * 180, 0);
        anim.Play("MeduSlapDown");
        aud.Play();
        crouchTimer = 0;
        Invoke("CallShakeScreen", 0.5f);
        StartCoroutine(SlapRight());
    }
    IEnumerator SlapRight(){
        // gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        while (rightHand.transform.position != groundPos.transform.position){
            HeadCollider.transform.position = Vector2.MoveTowards(HeadCollider.transform.position, crouchHeadPosition, 7 * Time.deltaTime);
            leftHand.transform.position = Vector2.MoveTowards(leftHand.transform.position, leftHandUpPos, 7 * Time.deltaTime);
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, groundPos.transform.position, 7 * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Right hand has reached new pos");
        yield return new WaitForSeconds(crouchTime);
        Debug.Log("Done waiting");

        // Move colliders back to the idle position
        while (rightHand.transform.position != rightHandInitPos){
            HeadCollider.transform.position = Vector2.MoveTowards(HeadCollider.transform.position, initHeadPosition, 7 * Time.deltaTime);
            leftHand.transform.position = Vector2.MoveTowards(leftHand.transform.position, leftHandInitPos, 7 * Time.deltaTime);
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, rightHandInitPos, 7 * Time.deltaTime);
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
            switch(attackPhase){
                case 0:
                    Jump();
                    attackPhase = 1;
                    break;
                case 1:
                    Jump();
                    attackPhase = 2;
                    break;
                case 2:
                    // Jump();
                    Slap();
                    gameObject.GetComponent<MeduSpawnEnemy>().spawnEnemy();
                    attackPhase = 0;
                    break;
                default:
                    Debug.Log("MeduBoss attackPhase out of bounds");
                    break;
            }
            attackTimer = 0;
        }
        else{
            attackTimer += Time.deltaTime;
        }
    }
}
