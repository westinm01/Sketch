using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopGame(collision);
            GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        }
    }

    public void StopGame(Collider2D collision)
    {
        Time.timeScale = 0;
        collision.gameObject.GetComponent<Am_Movement>().enabled = false;
        collision.gameObject.GetComponent<ChangePencilMode>().enabled = false;
        collision.gameObject.GetComponent<AmCombat>().enabled = false;
        collision.gameObject.GetComponent<HeartSystem>().enabled = false;
        collision.gameObject.GetComponent<AmAbyss>().enabled = false;
        collision.gameObject.GetComponent<Animator>().enabled = false;
        collision.gameObject.GetComponentInChildren<Ground_Check>().enabled = false;
        collision.gameObject.GetComponentInChildren<Shape_Creation>().enabled = false;
        collision.gameObject.GetComponentInChildren<Shape_Erase>().enabled = false;
    }
}
