using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFlood : MonoBehaviour
{
    public bool isActive;
    public float initialDelay;      // How long it takes for the flood to start
    public float spawnDelay;        // How often spiders spawn during the flood
    public int spidersSpawned;      // How many spiders to spawn
    public float eventDuration;     // How long the event lasts

    public GameObject spider;
    public GameObject cage;
    public Vector3[] spawnPoints;
    public GameObject spawnedCage;
    public GameObject scary;
    private float spawnTimer = 0;
    private float delayTimer = 0;
    private float eventTimer;
    private int spiderCount;

    public void PlayEvent(){
        isActive = true;
        spawnTimer = 0;
        delayTimer = 0;
        spiderCount = 0;
        eventTimer = 0;
        spawnedCage = Instantiate(cage, new Vector2(-2, 29), Quaternion.identity);
        scary.SetActive(true);
    }

    public void EndEvent(){
        Destroy(spawnedCage.gameObject);
        isActive = false;
        scary.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
            if (delayTimer >= initialDelay){
                if (spawnTimer >= spawnDelay && spiderCount <= spidersSpawned){
                    foreach (Vector3 point in spawnPoints){
                        Instantiate(spider, point, Quaternion.identity);
                        spiderCount++;
                    }
                    spawnTimer = 0;
                }
                else{
                    spawnTimer += Time.deltaTime;
                }
            }
            else{
                delayTimer += Time.deltaTime;
            }

            if (eventTimer >= eventDuration){
                EndEvent();
            }
            else{
                eventTimer += Time.deltaTime;
            }
        }
    }
}
