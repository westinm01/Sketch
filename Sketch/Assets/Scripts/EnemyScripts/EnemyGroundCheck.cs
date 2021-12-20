using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundCheck : MonoBehaviour
{
    public bool isGrounded;
    public bool touchingWall;
    private CircleCollider2D cap;

    void Start(){
        cap = gameObject.GetComponent<CircleCollider2D>();
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 3)
    //     {
    //         isGrounded = true;
    //     }
    //     else{
    //         isGrounded = false;
    //     }
    // }

    void CheckCollisions(){
        List<Collider2D> hitObjects = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        isGrounded = false;
        touchingWall = false;
        int length = cap.OverlapCollider(filter.NoFilter(), hitObjects);
        foreach(Collider2D hit in hitObjects){
            if (hit.name == "Tilemap"){
                isGrounded = true;
            }
            if (hit.tag == "SpawnedShape"){
                touchingWall = true;
            }
        }
    }
    void Update(){
        CheckCollisions();
    }
}