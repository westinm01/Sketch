using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthalBoss : BossCombat
{
    public GameObject[] tiles;
    public GameObject currTile;
    public Animator anim;
    int tile = 0;
    public float delayTime;
    float timer = 0;
    int counter = 0;
    bool canChangeTile = true;

    protected override void Update()
    {
        if (timer >= delayTime && canChangeTile)
        {
            StartCoroutine(MusicSync());
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
            Destroy(GameObject.Find("Barrier"));
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

    public IEnumerator MusicSync()
    {
        anim.Play("Bang");
        yield return new WaitForSeconds(0.6f);
        changeTile();
        StopAllCoroutines();
    }
}
