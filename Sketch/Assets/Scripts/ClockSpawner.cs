using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{
    public GameObject clock;
    public Transform spawnPos1;
    public Transform spawnPos2;

    public float spawnDelay;
    private float spawnTimer = 0;

    public void SpawnClocks(){
        Instantiate(clock, spawnPos1.position, Quaternion.identity);
        Instantiate(clock, spawnPos2.position, Quaternion.identity);
    }

    void Update(){
        if (spawnTimer >= spawnDelay){
            SpawnClocks();
            spawnTimer = 0;
        }
        else{
            spawnTimer += Time.deltaTime;
        }
    }
}
