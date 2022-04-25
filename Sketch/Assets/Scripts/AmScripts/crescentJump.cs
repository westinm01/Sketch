using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crescentJump : MonoBehaviour
{
    private Shape_Creation shapeCreation;

    private void Start()
    {
        GameObject.Find("SpawnCheck").GetComponent<Shape_Creation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CrescentObject(Clone)")
        {
            --shapeCreation.crescentJump;
        }
    }
}
