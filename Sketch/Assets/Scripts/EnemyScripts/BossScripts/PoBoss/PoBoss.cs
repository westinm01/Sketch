using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoBoss : BossCombat
{
    private float timer = 30f;
    private float time;
    public Animator anim;
    GameObject am;
    public Transform[] teleportPoints;

    protected override void Start()
    {
        maxHealth = health;
        am = GameObject.Find("am-forward3");
    }
    protected override void Update()
    {
        if (time >= 0 && time < 10f)
        {


        }
        else if (time >= 10f && time < 20f)
        {


        }
        else if (time >= 20f && time < timer)
        {


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


    private void phase1()
    {
        anim.Play("");
    }

    private void phase2()
    {
        anim.Play("");
        am.GetComponent<Am_Movement>().enabled = false;
    }

    private void phase3()
    {
        am.GetComponent<Am_Movement>().enabled = true;
        anim.Play("");
        teleport();

    }

    private void teleport()
    {
        int rand = Random.Range(0, teleportPoints.Length);
        transform.position = teleportPoints[rand].position;
    }
}
