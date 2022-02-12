using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    private PhobosManager manager;
    public GameObject spiders;
    float timeBetweenSpawn = 3f; 
    public void PlayEvent(){
        manager.DarkenScreen();
    }

    void Start(){
        manager = gameObject.GetComponent<PhobosManager>();
    }

    void Update(){
        if ( timeBetweenSpawn <= 0f )
        {
            var temp = Instantiate(spiders, new Vector2(-8, 23), Quaternion.identity);
            var temp2 = Instantiate(spiders, new Vector2(-2, 20), Quaternion.identity);
            var temp3 = Instantiate(spiders, new Vector2(5, 23), Quaternion.identity);
            timeBetweenSpawn = 3f;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
