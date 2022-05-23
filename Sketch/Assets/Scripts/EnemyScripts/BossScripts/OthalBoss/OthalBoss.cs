using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthalBoss : BossCombat
{
    public GameObject gameManager;
    public GameObject[] tiles;
    public GameObject currTile;
    public Animator anim;
    int tile = 0;
    public float delayTime;
    float timer = 0;
    int counter = 0;
    bool canChangeTile = true;

    protected override void Start()
    {
        maxHealth = health;
        StartCoroutine(MusicSync());
    }
    protected override void Update()
    {
        if (timer >= delayTime && canChangeTile)
        {
            //StartCoroutine(AttackSync());
            timer = 0;
            ++counter;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (stunTimer < stunTime)
        {
            stunTimer += Time.deltaTime;
        }
        if (counter > 10)
        {
            canChangeTile = false;
            //Destroy(GameObject.Find("Barrier"));
        }
    }
    void changeTile()
    {
        int newTile = Random.Range(0, 3);
        while(tile == newTile)
        {
            newTile = Random.Range(0, 2);
        }
        tile = newTile;
        if (currTile != null) currTile.SetActive(false);
        currTile = tiles[tile];
        currTile.SetActive(true);
    }

    public IEnumerator AttackSync()
    {
        anim.Play("Bang");
        yield return new WaitForSeconds(0.28f);
        changeTile();
        StopCoroutine(AttackSync());
    }

    public IEnumerator MusicSync()
    {
        yield return new WaitForSeconds(7.57f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.73f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.75f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.95f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(1.3f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.94f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(1.87f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.96f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.93f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(1.88f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.92f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.96f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(1.86f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.95f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(0.92f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(1.88f); //30.07s
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.74f);
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.78f); //37.59s
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.73f); //41.32s
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.75f); //45.07
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.76f); //48.83
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3.74f); //52.57
        StartCoroutine(AttackSync());

        yield return new WaitForSeconds(3f);
        gameManager.GetComponent<AudioSource>().enabled = false;
        canChangeTile = false;
        Destroy(GameObject.Find("Barrier"));
        anim.Play("Tired");
    }
}
