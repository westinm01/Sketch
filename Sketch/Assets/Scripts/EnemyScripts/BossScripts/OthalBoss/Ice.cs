using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (collision.gameObject.transform.rotation.y != 0)
            {
                Debug.Log("y");
                rb.AddForce(new Vector3(-50, 0, 0));
            }
            else if (collision.gameObject.transform.rotation.y == 0f)
            {
                rb.AddForce(new Vector3(50, 0, 0));
            }
        }
        else if (collision.gameObject.tag == "SpawnedShape")
        {
            Destroy(collision.gameObject);
        }
    }
}
