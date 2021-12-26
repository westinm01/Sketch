using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AmAbyss : MonoBehaviour
{
    public float bounce;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 3)
        {
            respawnPoint.transform.position = transform.parent.position;
            respawnPoint.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            respawnPoint.transform.parent = null;
            respawnPoint.transform.position = transform.parent.position + new Vector3(-1,0,0);
        }
    }
    */
    public IEnumerator Respawn()
    {
        GetComponent<Rigidbody2D>().velocity *= new Vector2(0, -1.1f);
        //GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, 600f));
        //transform.parent.position = respawnPoint.transform.position;
        //  GetComponentInParent<Am_Movement>().enabled = false;
        //yield return new WaitForSeconds(1);
        //GetComponentInParent<Am_Movement>().enabled = true;
        yield return null;
    }

       
}
