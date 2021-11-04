using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Erase : MonoBehaviour
{
    [HideInInspector] public bool canDrawShapeErase = false;
    GameObject recentSpawnedShape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Alpha1) && !canDrawShapeErase)
        {
            Destroy(recentSpawnedShape);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnedShape")
        {
            recentSpawnedShape = collision.gameObject;
            Debug.Log(recentSpawnedShape);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        recentSpawnedShape = null;
    }
}
