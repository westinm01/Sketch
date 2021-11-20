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
    public double attackDelay;
    double timer = 0f;


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
        if (timer > 0) timer -= Time.deltaTime;

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
            EraseRecentShape();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !canDrawShapeErase && timer <= 0)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.parent.position, new Vector2(3, 4), 0);
            if (hitEnemies.Length > 0) timer = attackDelay;
            foreach(Collider2D hitEnemy in hitEnemies)
            {
                if(hitEnemy.gameObject.tag == "Enemy")
                {
                    hitEnemy.GetComponent<EnemyCombat>().enemyTakeDamage(Am.GetComponent<Rigidbody2D>());
                }
            }
        }
        //Debug.Log(timer);
    }

    void EraseRecentShape()
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
        Gizmos.DrawWireCube(transform.parent.position, new Vector3(3, 4, 0));
    }
}
