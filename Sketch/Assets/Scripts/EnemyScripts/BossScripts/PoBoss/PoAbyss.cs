using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoAbyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PoBoss")
        {
            collision.gameObject.GetComponent<PoBoss>().PoBossTakeDamage();
        }
    }
}
