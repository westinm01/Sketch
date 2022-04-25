using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawned;         // Prefab of enemy to spawn
    public List<Transform> spawnLocations;  // Spawns 1 enemy per location
    private List<GameObject> spawnedEnemies;

    void Start(){
        spawnedEnemies = new List<GameObject>(spawnLocations.Count);
    }

    public void SpawnEnemy(){
        foreach (Transform spawn in spawnLocations){
            Vector3 pos = spawn.position;
            spawnedEnemies.Add(Instantiate(enemySpawned, pos, Quaternion.identity));
        }
    }

    public void ClearEnemies(){
        foreach (GameObject enemy in spawnedEnemies){
            if (enemy != null){
                Destroy(enemy);
            }
            spawnedEnemies.Remove(enemy);
        }
    }

    void Update(){
        if (Input.GetKeyDown("w")){
            SpawnEnemy();
        }
    }
}
