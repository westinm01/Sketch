using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerBossMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float attackTimer; 
    private float attackPhase;
    public GameObject FistCollider; 
    [SerializeField] private float attackTime; 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackTimer = 0;
        attackPhase = 0;
    }

    private void FistAttack()
    {
        anim.Play("AphFistAttack 2");
        FistCollider.SetActive(true);
    }

    private void ScreamAttack()
    {
        anim.Play("AphScream");
        FistCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( attackTime <= attackTimer )
        {
            switch(attackPhase)
            {
                case 0:
                    FistAttack();
                    attackPhase = 1;
                    break;
                case 1:
                    ScreamAttack();
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
