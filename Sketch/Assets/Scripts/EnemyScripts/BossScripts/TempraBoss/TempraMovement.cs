using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempraMovement : EnemyMovement
{
    private Rigidbody2D rb;
    private Animator anim;
    public float happySpeed;
    public float neutralSpeed;
    public float angrySpeed;
    public string currentPhase; 
    private float timer;
    // Start is called before the first frame update
    protected override void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        amPlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(amPlayer);
        currentPhase = "neutral";
        timer = 0; 
        base.Start(); 
    }

    public void timerChange()
    {
        timer = 0; 
    }

    // Update is called once per frame
    protected override void Update()
    {
        Vector2 positionDifference = gameObject.transform.position - amPlayer.transform.position;
        float playerDistance = positionDifference.magnitude;
        if ( playerDistance < targetDistance )
        {
            if ( enemyRigidBody.velocity.x < 0 )
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
                move();
            }
        else
        {
            enemyRigidBody.velocity = Vector2.zero;
        }

        switch(currentPhase)
        {
            case "neutral":
                turnSpeed = neutralSpeed; 
                break;
            case "happy":
                turnSpeed = happySpeed;
                if ( timer >= 3 )
                {
                    timer = 0; 
                    currentPhase = "neutral";
                    anim.Play("HappyToNeutral");
                }
                else
                {
                    timer += Time.deltaTime; 
                }
                break;
            case "angry":
                turnSpeed = angrySpeed; 
                if ( timer >= 3 )
                {
                    currentPhase = "neutral";
                    Debug.Log("AngryToNeutral");
                    anim.Play("NeutralTurn");
                }
                else
                {
                    timer += Time.deltaTime; 
                }
                break;
        }
    }
}
