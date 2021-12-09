using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shape_Erase : MonoBehaviour
{
    [HideInInspector] public bool canDrawShapeErase = false;
    Vector3Int recentMapTile;
    public Tilemap map;
    public GameObject Am;
    private Dictionary<Vector3Int, TileBase> terrainDict = new Dictionary<Vector3Int, TileBase>();
    public Animator anim;

    void start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Awake()
    {
        map.CompressBounds();
        var bounds = map.cellBounds;
         //Debug.Log("Bounds:" + bounds);
         //Debug.Log("Bounds xMin : " + bounds.xMin);
         //Debug.Log("Bounds yMin : " + bounds.yMin);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                var px = bounds.xMin + x;
                var py = bounds.yMin + y;

                Vector3Int tempLoc = new Vector3Int(px, py, 0);
                if (map.HasTile(tempLoc))
                {
                    terrainDict.Add(tempLoc, map.GetTile(tempLoc));
                }
            }
        }
        foreach (var i in terrainDict)
        {
            //Debug.Log(i.Key.ToString() + ' ' + i.Value.ToString());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Am.transform.rotation.y != 0 && !canDrawShapeErase)
            {
                recentMapTile = map.WorldToCell(gameObject.transform.position)- new Vector3Int(0, 0, 0);
            }
            else if (!canDrawShapeErase)
            {
                recentMapTile = map.WorldToCell(gameObject.transform.position) - new Vector3Int(0, 0, 0);
            }
            //Debug.Log(recentMapTile);
            if (terrainDict.ContainsKey(recentMapTile) && !canDrawShapeErase)
            {
                map.SetTile(recentMapTile, null);
                terrainDict.Remove(recentMapTile);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !canDrawShapeErase)
        {
            RecentShape();
            anim.Play("Am_Attack");
        }
    }

    void RecentShape()
    {
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.5f, 2), 0);
        foreach (Collider2D hitColliders in hitObjects)
        {
            if (hitColliders.gameObject != GameObject.Find("Tilemap"))
            {
                Destroy(hitColliders.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 2, 0));
    }
}
