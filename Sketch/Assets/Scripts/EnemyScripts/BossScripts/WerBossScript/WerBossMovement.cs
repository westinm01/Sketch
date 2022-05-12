using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerBossMovement : MonoBehaviour
{
    private Animator anim;
    public GameObject amPlayer;
    public GameObject soundWave;
    public Transform leftSoundwavePos;
    public Transform rightSoundwavePos;
    public Transform LeftAttackTarget;
    public Transform RightAttackTarget;
    public ProjectileReflector reflector;

    private Rigidbody2D rb;
    private Rigidbody2D enemyRb;
    public float attackTimer; 
    private float attackPhase;
    public bool isStunned = false;
    public float swoop;
    public float soundwaveSpeedIncrease;    // How much faster the soundwaves get in phase 2
    public float swoopSpeedIncrease;        // How much faster the boss gets in phase 2
    public GameObject FistCollider; 
    private GameObject am; 
    private Soundwave wave;
    private BossCombat combat;

    public GameObject text; 

    [SerializeField] private float attackTime; 
    [SerializeField] private int maxReflections;    // How many times the boss can reflect the soundwave before taking damage
    public float stunTime;        // How long the boss gets stunned for
    private int phase = 1;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        combat = gameObject.GetComponent<BossCombat>();
        attackTimer = attackTime;
        attackPhase = 0;
        am = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FistAttackRight()
    {
        //rb.gravityScale = 0.5f; 
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = new Vector3(9.3f, 5);
        Vector3 target = am.transform.position;
        // rb.gravityScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        if (!isStunned){
            Vector3 newVelocity = target - gameObject.transform.position;
            newVelocity = newVelocity.normalized;
            newVelocity = newVelocity * swoop;
            rb.velocity = newVelocity;
            anim.Play("AphFistAttack 2");
            FistCollider.SetActive(true);
        }
        // rb.gravityScale = 0;

        //rb.velocity = new Vector3(-swoop, 0);
    }
    private IEnumerator FistAttackLeft()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        gameObject.transform.position = new Vector3(-9.3f, 5);
        Vector3 target = am.transform.position;
        // rb.gravityScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        if (!isStunned){
            Vector3 newVelocity = target - gameObject.transform.position;
            newVelocity = newVelocity.normalized;
            newVelocity = newVelocity * swoop;
            rb.velocity = newVelocity;
            anim.Play("AphFistAttack 2");
            FistCollider.SetActive(true);
        }
        // rb.gravityScale = 0;
    }

    private void ScreamAttackRight()
    {
        reflector.enabled = true;
        reflector.timesReflected = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(9.3f, 5);
        Invoke("SpawnRightSoundwave", 1f);
    }
    private void SpawnRightSoundwave(){
        wave = Instantiate(soundWave, rightSoundwavePos.transform.position, Quaternion.identity).GetComponent<Soundwave>();
        text.SetActive(true);
        wave.direction = am.transform.position - transform.position;
        // wave.RotateTowardDirection();
        if (phase == 2){
            wave.speed += soundwaveSpeedIncrease;
        }
    }

    private void ScreamAttackLeft()
    {
        reflector.enabled = true;
        reflector.timesReflected = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0; 
        gameObject.transform.position = new Vector3(-9.3f, 5);
        Invoke("SpawnLeftSoundwave", 1f);
    }
    private void SpawnLeftSoundwave(){
        wave = Instantiate(soundWave, leftSoundwavePos.transform.position, Quaternion.identity).GetComponent<Soundwave>();
        text.SetActive(true);
        wave.direction = am.transform.position - transform.position;
        // wave.RotateTowardDirection();
        if (phase == 2){
            wave.speed += soundwaveSpeedIncrease;
        }
    }

    public IEnumerator GetStunned(){
        isStunned = true;
        anim.Play("AphHurt");
        rb.gravityScale = 1;
        yield return new WaitForSeconds(stunTime);
        Debug.Log("Stun over");
        isStunned = false;
        anim.Play("AphIdle");
        rb.gravityScale = 0;
        // attackTimer = 0;
        reflector.enabled = true;
        reflector.timesReflected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reflector.timesReflected >= maxReflections){
            reflector.enabled = false;
        }

        if (combat.health <= 12 && phase == 1){
            phase = 2;
            swoop += swoopSpeedIncrease;
            maxReflections++;
        }
        if ( attackTime <= attackTimer && !isStunned && wave == null)
        {
            switch(attackPhase)
            {
                case 0:
                    text.SetActive(false);
                    StartCoroutine(FistAttackRight());
                    attackPhase = 1;
                    break;
                case 1:
                    ScreamAttackLeft();
                    attackPhase = 2;
                    break;
                case 2:
                    text.SetActive(false);
                    StartCoroutine(FistAttackLeft());
                    attackPhase = 3;
                    break;
                case 3:
                    ScreamAttackRight();
                    attackPhase = 0;
                    break;
                default:
                    Debug.Log("WerBoss attackPhase out of bounds");
                    break;
            }
            attackTimer = 0;
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }
}
