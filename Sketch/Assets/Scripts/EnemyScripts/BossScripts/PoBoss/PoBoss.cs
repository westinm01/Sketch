using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoBoss : BossCombat
{
    private float timer = 21;
    private float time;
    public Animator anim;
    GameObject am;
    public Transform[] teleportPoints;
    bool canTeleport = true;
    float sleeptimer = 3f;
    float sleeptime = 0;
    int tp1 = -1, tp2 = -1, tp3 = -1;

    protected override void Start()
    {
        maxHealth = health;
        am = GameObject.Find("am-forward3");
        time = 18f;
    }
    protected override void Update()
    {
        Debug.Log(time);
        if (time >= 0 && time < 12f)
        {
            if (sleeptime < 1.5f)
            {
                am.GetComponent<Am_Movement>().enabled = true;
                Debug.Log("awake");
            }
            if (sleeptime < 0.7f)
            {
                anim.Play("awaitAnim");
            }
            if (sleeptime >= 0.7f) anim.Play("coverAnim");
            if (sleeptime >= 1.5f)
            {
                phase2();
                Debug.Log("sleep");
            }
            if (sleeptime >= sleeptimer) sleeptime = 0;

            sleeptime += Time.deltaTime;
            canTeleport = true;

        }
        else if (time >= 12f && time < 18f)
        {
            phase1();

        }
        else if (time >= 18f && time < timer)
        {
            if (canTeleport)
            {
                phase3();
            }

        }
        if (time >= timer)
        {
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
        }


        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }
    }

    public override void bossTakeDamage(Rigidbody2D playerRigidBody)
    {
        PoBossTakeDamage();
    }

    public void PoBossTakeDamage()
    {
        health--;
        anim.Play("hurtAnim");
        if (health <= 0)
        {
            Debug.Log("Boss is dead");
            if (endFlag != null)
            {
                Invoke("InstantiateEndFlag", 2f);
                // GameObject.Find("EndOfLevel").SetActive(true);
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
        time = 18f;
        canTeleport = true;
    }

    private void phase1()
    {
        anim.Play("awaitAnim");
        am.GetComponent<Am_Movement>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -9);
    }

    private void phase2()
    {
        //anim.Play("coverAnim");
        am.GetComponent<Rigidbody2D>().velocity *= new Vector2(0, 1);
        am.GetComponent<Am_Movement>().enabled = false;
        am.GetComponent<Animator>().Play(null);
    }

    private void phase3()
    {
        am.GetComponent<Am_Movement>().enabled = true;
        anim.Play("teleportAnim");
        Invoke("teleport", 1.7f);
        canTeleport = false;

    }

    private void teleport()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        int rand = Random.Range(0, teleportPoints.Length);
        if (tp1 != -1 && tp2 != -1 && tp3 != -1)
        {
            tp1 = -1;
            tp2 = -1;
            tp3 = -1;
        }

        while (rand == tp1 || rand == tp2 || rand == tp3)
        {
            rand = Random.Range(0, teleportPoints.Length);
        }
        if (tp1 == -1) tp1 = rand;
        else if (tp2 == -1) tp2 = rand;
        else if (tp3 == -1) tp3 = rand;
        
        transform.position = teleportPoints[rand].position;
        anim.Play("ReverseTeleportAnim");
    }
}
