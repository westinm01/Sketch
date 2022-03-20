using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawn : MonoBehaviour
{
    public GameObject worm; 
    private float spawnTimer = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( spawnTimer <= 0f)
        {
            float rand = Random.Range(-8.31f, 8.31f);
            Instantiate(worm, new Vector2(rand, 3.8f), Quaternion.identity);
            spawnTimer = 2f; 
        }
        else
        {
            spawnTimer -= Time.deltaTime;    
        }
    }
}
