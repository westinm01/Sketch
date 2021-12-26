using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    public GameObject Am;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Am.GetComponent<AmAbyss>().Respawn());
            // Am.GetComponent<Animator>().SetBool("isStunned", true);
            Am.GetComponent<AmCombat>().stunAm();
            Am.GetComponent<Am_Movement>().canJump = false;
            Am.GetComponent<HeartSystem>().TakeDamage(1);

        }
        else if (collision.gameObject.tag == "SpawnedShape")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}

