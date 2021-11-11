using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Creation : MonoBehaviour
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject Circle;
    public GameObject Arrow;
    public GameObject SpawnLocation;
    [HideInInspector] public bool canDrawShapeCreation = true;

    public float arrowSpeed;

    public float arrowLifeSpan;

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
        if (Input.GetKeyDown(KeyCode.Alpha3) && collisionCount <= 0 && canDrawShapeCreation)
        {
            Instantiate(Circle, SpawnLocation.transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && collisionCount <= 0 && canDrawShapeCreation)
        {
            GameObject createdArrow;
            createdArrow = Instantiate(Arrow, SpawnLocation.transform.position, transform.rotation);
            if (transform.rotation.y == -1 || transform.rotation.y == 1)
            {
                createdArrow.transform.rotation = Quaternion.Euler(0, 180, 0);
                createdArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed, 0);
            }
            else
            {
                createdArrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                createdArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed, 0);
            }
            Destroy(createdArrow, arrowLifeSpan);
        }
    }
}
