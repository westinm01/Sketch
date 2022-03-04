using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int reflectCount;

    public void setDirection(float angle)
    {
        rb.velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * speed, Mathf.Sin(angle * Mathf.Deg2Rad) * speed);
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HeartSystem>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "SpawnedShape")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 4)
        {
            //Vector3 dir = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //Debug.Log(dir);
            //rb.velocity = dir * speed;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
            --reflectCount;
        }
        if (reflectCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
