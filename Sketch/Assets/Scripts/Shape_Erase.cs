using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shape_Erase : MonoBehaviour
{
    [HideInInspector] public bool canDrawShapeErase = false;
    GameObject recentSpawnedShape;
    public Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindObjectOfType<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Alpha1) && !canDrawShapeErase)
        {
            Destroy(recentSpawnedShape);
            map.SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
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
