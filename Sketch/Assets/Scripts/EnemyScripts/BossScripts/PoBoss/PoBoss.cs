using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoBoss : BossCombat
{
    private float timer = 30;
    private float time;
    public Animator anim;
    GameObject am;
    public Transform[] teleportPoints;
    bool canTeleport = true;

    protected override void Start()
    {
        maxHealth = health;
        am = GameObject.Find("am-forward3");
    }
    protected override void Update()
    {
        if (time >= 0 && time < 6f)
        {
            phase1();

        }
        else if (time >= 6f && time < 18f)
        {
            float sleeptimer = 3f;
            float sleeptime = 0;
            Debug.Log(sleeptime);
            if (sleeptime < 1.5f)
            {
                am.GetComponent<Am_Movement>().enabled = true;
                Debug.Log("awake");
                anim.Play("awaitAnim");
            }
            else
            {
                phase2();
                Debug.Log("sleep");
            }
            if (sleeptime >= sleeptimer) sleeptime = 0;

            sleeptime += Time.deltaTime;
            canTeleport = true;

        }
        else if (time >= 18f && time < timer)
        {
            phase3();
            canTeleport = false;

        }
        if (time >= timer)
        {
            time = 0f;
        }
        else time += Time.deltaTime;


        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }
    }

    public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        health--;
        anim.Play("hurtAnim");
        if (health <= 0)
        {
            Debug.Log("Boss is dead");
            if (endFlag != null)
            {
                Invoke("InstantiateEndFlag", 2f);
                gameObject.SetActive(false);
                Destroy(this.gameObject, 2f);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        FlashRed();
        Invoke("StopFlash", 0.1f);
        stunTimer = 0f;
    }

    private void phase1()
    {
        anim.Play("awaitAnim");
    }

    private void phase2()
    {
        anim.Play("coverAnim");
        am.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        am.GetComponent<Am_Movement>().enabled = false;
    }

    private void phase3()
    {
        am.GetComponent<Am_Movement>().enabled = true;
        if (canTeleport) teleport();

    }

    private void teleport()
    {
        anim.Play("teleportAnim");
        int rand = Random.Range(0, teleportPoints.Length);
        transform.position = teleportPoints[rand].position;

    }
}
