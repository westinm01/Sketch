using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shape_Erase : MonoBehaviour
{
    [HideInInspector] public bool canDrawShapeErase = false;
    [HideInInspector] public Animator anim;

    Vector3Int recentMapTile;
    public Tilemap map;
    public Tilemap WallMap;
    public GameObject Am;
    public float attackDelay;
    float timer = 0f;
    private Dictionary<Vector3Int, TileBase> terrainDict = new Dictionary<Vector3Int, TileBase>();
    private GameManager gm;

    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        // map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        // WallMap = GameObject.Find("WallMap").GetComponent<Tilemap>();
        
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
        if (gm.isPaused){
            return;
        }
        
        if (timer > 0){
            timer -= Time.deltaTime;
            return;
        }
        // Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Alpha2) && !canDrawShapeErase)
        {
            anim.Play("Am_Erase");

            recentMapTile = map.WorldToCell(gameObject.transform.position);

            //Debug.Log(recentMapTile);
            //if (terrainDict.ContainsKey(recentMapTile))
            //{
            if (WallMap.GetTile(recentMapTile) == null && WallMap.GetTile(recentMapTile + Vector3Int.right) == null && WallMap.GetTile(recentMapTile + Vector3Int.left) == null && WallMap.GetTile(recentMapTile + Vector3Int.up) == null)
            {
                map.SetTile(recentMapTile, null);
            }
            else
            {
                recentMapTile = WallMap.WorldToCell(gameObject.transform.position);
                WallMap.SetTile(recentMapTile, null);
                WallMap.SetTile(recentMapTile + Vector3Int.up, null);
                WallMap.SetTile(recentMapTile + Vector3Int.left, null);
                WallMap.SetTile(recentMapTile + Vector3Int.left + Vector3Int.up, null);
                WallMap.SetTile(recentMapTile + Vector3Int.right, null);
                WallMap.SetTile(recentMapTile + Vector3Int.right + Vector3Int.up, null);
                //Debug.Log(recentMapTile);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !canDrawShapeErase)
        {
            anim.Play("Am_Erase");
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.parent.position, new Vector2(4, 4), 0);
            if (hitEnemies.Length > 0) timer = attackDelay;
            foreach(Collider2D hitEnemy in hitEnemies)
            {
                if(hitEnemy.gameObject.tag == "Enemy")
                {
                    hitEnemy.GetComponent<EnemyCombat>().enemyTakeDamage(Am.GetComponent<Rigidbody2D>());
                    return;
                }
                if(hitEnemy.gameObject.tag == "Boss")
                {
                    if (hitEnemy.GetComponent<FlashonMovement>())
                    {
                        hitEnemy.GetComponent<FlashonMovement>().bossTakeDamage(Am.GetComponent<Rigidbody2D>());
                    }
                    return;
                }
                else
                {
                    EraseRecentShape();
                }
            }
        }
        // if (Input.GetKeyDown(KeyCode.Alpha3) && !canDrawShapeErase && timer <= 0)
        // {
        //     anim.Play("Am_Erase");
        //     Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.parent.position, new Vector2(4, 4), 0);
        //     if (hitEnemies.Length > 0) timer = attackDelay;
        //     foreach(Collider2D hitEnemy in hitEnemies)
        //     {
        //         if(hitEnemy.gameObject.tag == "Enemy")
        //         {
        //             hitEnemy.GetComponent<EnemyCombat>().enemyTakeDamage(Am.GetComponent<Rigidbody2D>());
        //             return;
        //         }
        //         if(hitEnemy.gameObject.tag == "Boss")
        //         {
        //             hitEnemy.GetComponent<BossCombat>().bossTakeDamage(Am.GetComponent<Rigidbody2D>());
        //             return;
        //         }
        //     }
        // }
        //Debug.Log(timer);
    }

    void EraseRecentShape()
    {
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.5f, 2), 0);
        foreach (Collider2D hitColliders in hitObjects)
        {
            if (hitColliders.name != "Tilemap" && hitColliders.tag != "Wall" && hitColliders.gameObject.tag != "Enemy" && hitColliders.gameObject.tag != "Unerasable" && hitColliders.gameObject.tag != "Boss"){
                Destroy(hitColliders.gameObject);
                return;
            }
        }
        // if (hitObjects.Length > 0 && hitObjects[0].gameObject.name != "Tilemap" && hitObjects[0].gameObject.tag != "Enemy") 
        // {
        //     Destroy(hitObjects[0].gameObject);
        // }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 2, 0));
        Gizmos.DrawWireCube(transform.parent.position, new Vector3(3, 4, 0));
    }
}
