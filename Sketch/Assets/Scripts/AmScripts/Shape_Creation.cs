using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Creation : MonoBehaviour
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject Circle;
    public GameObject Arrow;
    public GameObject Crescent;
    public GameObject SpawnLocation;
    [HideInInspector] public bool canDrawShapeCreation = true;
    public float arrowSpeed;
    public float arrowLifeSpan;
    public float crescentSpeed;
    public float crescentLifeSpan;
    public Animator anim;
    void start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(collisionCount);
        if (Input.GetKeyDown(KeyCode.Alpha1) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Square, SpawnLocation.transform.position, transform.rotation);
            anim.SetBool("IsDrawing", true);
        }
        if ( Input.GetKeyUp(KeyCode.Alpha1) )
        {
                anim.SetBool("IsDrawing", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Triangle, SpawnLocation.transform.position, transform.rotation);
            anim.SetBool("IsDrawing", true);
        }
        if ( Input.GetKeyUp(KeyCode.Alpha2) )
        {
                anim.SetBool("IsDrawing", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Circle, SpawnLocation.transform.position, transform.rotation);
            anim.SetBool("IsDrawing", true);
        }
        if ( Input.GetKeyUp(KeyCode.Alpha3) )
        {
                anim.SetBool("IsDrawing", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && isClear() && canDrawShapeCreation)
        {
            GameObject createdArrow;
            createdArrow = Instantiate(Arrow, SpawnLocation.transform.position, transform.rotation);
            anim.SetBool("IsDrawing", true);
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
        if ( Input.GetKeyUp(KeyCode.Alpha4) )
        {
                anim.SetBool("IsDrawing", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && isClear() && canDrawShapeCreation)
        {
            GameObject createdCrescent;
            createdCrescent = Instantiate(Crescent, SpawnLocation.transform.position, transform.rotation);
            anim.SetBool("IsDrawing", true);
            if (transform.rotation.y == -1 || transform.rotation.y == 1)
            {
                createdCrescent.transform.rotation = Quaternion.Euler(0, 180, 90);
                createdCrescent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, crescentSpeed);
            }
            else
            {
                createdCrescent.transform.rotation = Quaternion.Euler(0, 0, 90);
                createdCrescent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, crescentSpeed);
            }
            Destroy(createdCrescent, crescentLifeSpan);
        }
        if ( Input.GetKeyUp(KeyCode.Alpha5) )
        {
                anim.SetBool("IsDrawing", false);
        }
    }

    bool isClear()
    {
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.8f, 2.05f), 0);
        if (hitObjects.Length == 0)
        {
            return true;
        }
        else return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.8f, 2.05f, 1));
    }
}
