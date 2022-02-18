using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PituBoss : BossCombat
{
    int stage = 1;
    float timer = 25;
    float time;
    public float speed;
    public Transform stage1Position, stage2Position;
    bool isTransitioning;
    public GameObject spear, spearSpawnPosition;
    public float spearSpawnRate;
    float spearTime = 0;
    public Transform[] circle;
    int nextPoint;
    public float circleSpeed, circleSpawnRate, circleProjectileSpeed;
    public GameObject circleProjectile;
    float circleTime = 0;
    public Animator animator;
    public Sprite ballSprite;


    // Update is called once per frame
    protected override void Update()
    {
        
        if (time > 0 && time <= 5)
        {
            stage = 1;
            Stage1();
            spearTime = spearSpawnRate;
            animator.enabled = true;
            animator.Play("IdleAnimation");
        }

        else if (time > 5 && time <= 15)
        {
            Stage2();
            if (spearTime >= spearSpawnRate && !isTransitioning)
            {
                animator.Play("SpinAnimation");
                spawnSpear();
                spearTime = 0f;
            }
            else
            {
                spearTime += Time.deltaTime;
            }
            stage = 2;
            nextPoint = 0;
            circleTime = circleSpawnRate;

        }

        else if (time > 15 && time <= 25)
        {
            stage = 3;
            animator.enabled = false;
            sr.sprite = ballSprite;
            Stage3();
            if (circleTime >= circleSpawnRate && !isTransitioning)
            {
                spawnCircleProjectile();
                circleTime = 0f;
            }
            else
            {
                circleTime += Time.deltaTime;
            }

        }


        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }

        if (time >= timer)
        {
            time = 0;
        }
        else if (!isTransitioning) time += Time.deltaTime;
    }

    void Stage1()
    {
        if (Vector3.Distance(stage1Position.position, gameObject.transform.position) < 0.05)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            isTransitioning = false;
            return;
        }
        isTransitioning = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stage1Position.position, speed);
    }

    void Stage2()
    {
        if (Vector3.Distance(stage2Position.position, gameObject.transform.position) < 0.05)
        {
            isTransitioning = false;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stage2Position.position, speed);
            return;
        }
        isTransitioning = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stage2Position.position, speed);
    }

    void spawnSpear()
    {
        float randomAngle = Random.Range(-50, 50);
        GameObject spearObj = Instantiate(spear, spearSpawnPosition.transform.position, Quaternion.Euler(0, 0, 0));
        spearObj.GetComponent<Spear>().setDirection(randomAngle);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void Stage3()
    {
        if (Vector3.Distance(circle[nextPoint].position, transform.position) < 0.01f)
        {
            if (nextPoint + 1 >= circle.Length)
            {
                nextPoint = 0;
            }
            else nextPoint++;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, circle[nextPoint].position, circleSpeed);
        }
    }

    void spawnCircleProjectile()
    {
        GameObject circleObj = Instantiate(circleProjectile, transform.position, Quaternion.Euler(0, 0, 0));
        circleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(circleProjectileSpeed, 0);

        circleObj = Instantiate(circleProjectile, transform.position, Quaternion.Euler(0, 0, 90));
        circleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, circleProjectileSpeed);

        circleObj = Instantiate(circleProjectile, transform.position, Quaternion.Euler(0, 0, 180));
        circleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-circleProjectileSpeed, 0);

        circleObj = Instantiate(circleProjectile, transform.position, Quaternion.Euler(0, 0, -90));
        circleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -circleProjectileSpeed);
    }
}
