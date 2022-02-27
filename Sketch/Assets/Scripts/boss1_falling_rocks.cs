using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1_falling_rocks : MonoBehaviour
{
    public GameObject Rockprefab;

    public Vector2 center;
    public Vector2 size;


    bool BossAlive = true;

    int interval = 1;
    float nextTime = 0;
        
    // Start is called before the first frame update
    void Start()
    {
        //SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextTime && BossAlive) {
            SpawnRocks();
            nextTime += interval;
        }

    }   

    public void SpawnRocks() {
        Vector2 pos = center + new Vector2(Random.Range(-16, 16), 3);

        Instantiate(Rockprefab, pos, Quaternion.identity);

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }


}
