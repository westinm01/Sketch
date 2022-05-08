using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySpawner : MonoBehaviour
{
    public GameObject enemy; 
    public float spawnInterval;
    private float spawnTimer = 2f; 
    public float height;
    public float xMin;
    public float xMax;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer=spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if ( spawnTimer <= 0f)
        {
            float rand = Random.Range(xMin, xMax);
            Instantiate(enemy, new Vector2(rand, height), Quaternion.identity);
            spawnTimer = spawnInterval; 
        }
        else
        {
            spawnTimer -= Time.deltaTime;    
        }
    }
}
