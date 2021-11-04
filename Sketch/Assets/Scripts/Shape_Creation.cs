using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Creation : MonoBehaviour
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject SpawnLocation;
    [HideInInspector] public bool canDrawShapeCreation = true;

    private int collisionCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++collisionCount;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --collisionCount;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(collisionCount);
        if (Input.GetKeyDown(KeyCode.Alpha1) && collisionCount <= 0 && canDrawShapeCreation)
        {
            Instantiate(Square, SpawnLocation.transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && collisionCount <= 0 && canDrawShapeCreation)
        {
            Instantiate(Triangle, SpawnLocation.transform.position, transform.rotation);
        }
    }
}
