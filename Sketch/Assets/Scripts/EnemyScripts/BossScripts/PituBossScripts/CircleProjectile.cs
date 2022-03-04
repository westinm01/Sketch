using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HeartSystem>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
