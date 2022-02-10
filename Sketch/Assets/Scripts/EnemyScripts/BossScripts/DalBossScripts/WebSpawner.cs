using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpawner : MonoBehaviour
{
    public GameObject web;
    public int websSpawned;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject[] spawnedWebs = new GameObject[5];    // Max of 5 webs


    public void SpawnWebs(){
        for (int i=0; i < websSpawned; i++){
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            spawnedWebs[i] = Instantiate(web, new Vector3(randX, randY), Quaternion.identity);
        }
    }

    public void ClearWebs(){
        foreach (GameObject gm in spawnedWebs){
            if (gm != null){
                Destroy(gm.gameObject);
            }
        }
    }
}
