using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerBossMovement : MonoBehaviour
{
    private Animator anim;
    public GameObject amPlayer;
    private Rigidbody2D rb;
    private Rigidbody2D enemyRb;
    private float attackTimer; 
    private float attackPhase;
    public float swoop;
    public GameObject FistCollider; 
    private GameObject am; 
    [SerializeField] private float attackTime; 
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
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(9.3f, 5);
    }
    private void ScreamAttackLeft()
    {
        rb.velocity = Vector2.zero; 
        anim.Play("AphScream");
        FistCollider.SetActive(false);
        rb.gravityScale = 0; 
        gameObject.transform.position = new Vector3(-9.3f, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if ( attackTime <= attackTimer )
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
