using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    GameObject Am;
    void Start()
    {
        Am = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Am.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f);
            Am.GetComponent<Animator>().Play("Am_Stunned");
            Am.GetComponent<AmCombat>().stunAm();
            Am.GetComponent<Am_Movement>().canJump = false;
            Am.GetComponent<HeartSystem>().TakeDamage(1);

        }
        else if (collision.gameObject.tag == "SpawnedShape")
        {
            Destroy(collision.gameObject);
        }

    }
}
