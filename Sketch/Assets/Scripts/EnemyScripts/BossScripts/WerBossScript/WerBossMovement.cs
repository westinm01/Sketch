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
    public ProjectileReflector reflector;

    private Rigidbody2D rb;
    private Rigidbody2D enemyRb;
    private float attackTimer; 
    private float attackPhase;
    private bool isStunned = false;
    public int timesHitBySoundwave = 0;
    public float swoop;
    public GameObject FistCollider; 
    private GameObject am; 
    [SerializeField] private float attackTime; 
    [SerializeField] private int maxReflections;    // How many times the boss can reflect the soundwave before taking damage
    [SerializeField] private float stunTime;        // How long the boss gets stunned for
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackTimer = 0;
        attackPhase = 0;
        am = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FistAttackRight()
    {
        //rb.gravityScale = 0.5f; 
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = new Vector3(9.3f, 5);
        Vector3 target = am.transform.position;
        yield return new WaitForSeconds(1);
        Vector3 newVelocity = target - gameObject.transform.position;
        newVelocity = newVelocity.normalized;
        newVelocity = newVelocity * swoop;
        rb.velocity = newVelocity;
        anim.Play("AphFistAttack 2");
        FistCollider.SetActive(true);
        //rb.velocity = new Vector3(-swoop, 0);
    }
    private IEnumerator FistAttackLeft()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        gameObject.transform.position = new Vector3(-9.3f, 5);
        Vector3 target = am.transform.position;
        yield return new WaitForSeconds(1);
        Vector3 newVelocity = target - gameObject.transform.position;
        newVelocity = newVelocity.normalized;
        newVelocity = newVelocity * swoop;
        rb.velocity = newVelocity;
        anim.Play("AphFistAttack 2");
        FistCollider.SetActive(true);
    }

    private void ScreamAttackRight()
    {
        reflector.timesReflected = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(9.3f, 5);
        Invoke("SpawnRightSoundwave", 1f);
        attackTimer -= 2f;       // Give the boss some extra time during scream
    }
    private void SpawnRightSoundwave(){
        Instantiate(soundWave, rightSoundwavePos.transform.position, Quaternion.identity);
    }

    private void ScreamAttackLeft()
    {
        reflector.timesReflected = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0; 
        gameObject.transform.position = new Vector3(-9.3f, 5);
        Invoke("SpawnLeftSoundwave", 1f);
        attackTimer -= 2f;      // Give the boss some extra time during scream
    }
    private void SpawnLeftSoundwave(){
        Instantiate(soundWave, leftSoundwavePos.transform.position, Quaternion.identity);
    }

    public IEnumerator GetStunned(){
        isStunned = true;
        anim.Play("AphHurt");
        rb.gravityScale = 1;
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
        anim.Play("AphIdle");
        rb.gravityScale = 0;
        attackTimer = 0;
        reflector.enabled = true;
        reflector.timesReflected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reflector.timesReflected >= maxReflections){
            reflector.enabled = false;
        }


        if ( attackTime <= attackTimer && !isStunned)
        {
            switch(attackPhase)
            {
                case 0:
                    StartCoroutine(FistAttackRight());
                    attackPhase = 1;
                    break;
                case 1:
                    ScreamAttackLeft();
                    attackPhase = 2;
                    break;
                case 2:
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
