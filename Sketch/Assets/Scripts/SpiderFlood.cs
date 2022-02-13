using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFlood : MonoBehaviour
{
    public bool isActive;
    public float initialDelay;      // How long it takes for the flood to start
    public float spawnDelay;        // How often spiders spawn during the flood
    public GameObject spider;
    public Transform[] spawnPoints;
    private float spawnTimer = 0;
    private float delayTimer = 0;

    public void PlayEvent(){
        isActive = true;
        spawnTimer = 0;
        delayTimer = 0;
    }

    public void EndEvent(){
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
            if (delayTimer >= initialDelay){
                if (spawnTimer >= spawnDelay){
                    foreach (Transform point in spawnPoints){
                        Instantiate(spider, point);
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
        }
    }
}
