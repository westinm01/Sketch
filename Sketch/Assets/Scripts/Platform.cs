using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool waitForAm;
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    private bool initialAmContact;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
        initialAmContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForAm && !initialAmContact){
            return;
        }

        if(transform.position== pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.tag == "Player"){
            initialAmContact = true;
        }
    }
}
