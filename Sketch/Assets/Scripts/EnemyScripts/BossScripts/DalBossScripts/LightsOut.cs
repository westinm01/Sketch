using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    private PhobosManager manager;
    public GameObject spiders;
    public GameObject lightbulb;
    // public Vector3 lightbulbPos;
    public bool isActive;
    public float minX;
    public float maxX;
    float timeBetweenSpawn = 3f; 
    public void PlayEvent(){
        // manager.DarkenScreen();
        isActive = true;
        Invoke("SpawnLightBulb", 2f);
    }

    public void EndEvent(){
        isActive = false;
        manager.BrightenScreen();
        manager.DisableSpotlight();
    }

    public void SpawnLightBulb(){
        float randX = Random.Range(minX, maxX);
        Vector3 oldPos = lightbulb.transform.position;
        lightbulb.gameObject.transform.position = new Vector3(randX, oldPos.y);
        lightbulb.gameObject.SetActive(true);
        // Instantiate(lightbulb, lightbulbPos, Quaternion.identity);
    }

    void Start(){
        manager = gameObject.GetComponent<PhobosManager>();
        isActive = false;
    }

    void Update(){
        if (isActive){
            if ( timeBetweenSpawn <= 0f )
            {
                var temp = Instantiate(spiders, new Vector2(-11.5f, 23), Quaternion.identity);
                var temp2 = Instantiate(spiders, new Vector2(9, 20), Quaternion.identity);
                var temp3 = Instantiate(spiders, new Vector2(9, 23), Quaternion.identity);
                timeBetweenSpawn = 3f;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }
    }
}
