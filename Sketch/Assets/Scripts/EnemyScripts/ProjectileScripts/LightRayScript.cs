using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRayScript : MonoBehaviour
{
    public Transform FirePos;
    public float width;
    public float beamDuration;
    public int damage;
    private LineRenderer lr;
    private Rigidbody2D enemyRigidBody;
    // private MeshCollider meshColl;
    private Camera mainCamera;
    private Vector3 end;
    private bool hitAm;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        // meshColl = lr.gameObject.GetComponent<MeshCollider>();
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        lr.startWidth = width;
        lr.endWidth = width;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Fire(Vector3 target){
        end = target;
        hitAm = false;
        lr.enabled = true;
        // UpdateMeshCollider();
        // Debug.Log(pos.position);
        // Debug.Log(target);
        lr.SetPosition(0, FirePos.position);
        lr.SetPosition(1, target);
    }

    // public void UpdateMeshCollider(){
    //     // meshColl.isTrigger = true;
    //     Mesh m = new Mesh();
    //     lr.BakeMesh(m, mainCamera, true);
    //     meshColl.sharedMesh = m;
    // }

    // public void OnCollisionStay2D(Collision2D collision){
    //     Debug.Log("Collision detected");
    //     if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
    //         Debug.Log("Hit " + collision.gameObject.name);
    //         // if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
    //         //     collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, damage);
    //         //     if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){
    //         //         Debug.Log("Am hit in draw mode");
    //         //     }
    //         // }
    //     }
    // }

    // public  void OnTriggerEnter2D(Collider2D collision){
    //     if (collision.gameObject.tag == "Player" && collision.gameObject.layer == 0){
    //         Debug.Log("Hit " + collision.gameObject.name);
    //         // if (!collision.gameObject.GetComponent<AmCombat>().isStunned()){   // if Am is in draw mode
    //         //     collision.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, damage);
    //         //     if (collision.gameObject.GetComponent<ChangePencilMode>().canDraw){
    //         //         Debug.Log("Am hit in draw mode");
    //         //     }
    //         // }
    //     }
    // }

    public void stopFiring(){
        lr.enabled = false;
        hitAm = false;
    }

    void Update(){
        if (lr.enabled && !hitAm){
            Vector3 direction = end - gameObject.transform.position;
            Ray r = new Ray(this.transform.position, direction.normalized);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 20);
            // Debug.Log(hits.Length);
            foreach(RaycastHit2D hit in hits){
                if (hit.collider.tag == "SpawnedShape"){
                    return;
                }
                if (hit.collider.tag == "Player"){
                    hit.collider.gameObject.GetComponent<AmCombat>().getHit(enemyRigidBody, damage);
                    hitAm = true;
                    return;
                }
            }
        }
    }
}
