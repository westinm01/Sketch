using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1_falling_rocks : MonoBehaviour
{
    public GameObject Rockprefab;
    public GameObject BossCheck;

    public Vector2 center;
    public Vector2 size;


    int interval=1;
    public float nextTime=0;
        
    // Start is called before the first frame update
    void Start()
    {
        nextTime = interval;

        //SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {   
        BossCheck = GameObject.FindWithTag("Boss");

        if (Time.time >= nextTime && BossCheck != null ) {
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
