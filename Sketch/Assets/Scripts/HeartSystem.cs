using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts;
    public GameObject Am;
    public int life;
    private bool dead;

    // Update is called once per frame

    private void Start()
    {
        life = hearts.Length;
    }
    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(hearts[life].gameObject);
        if ( life < 1 )
        {
            dead = true;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player" )
        {
            TakeDamage(1);
        }
    }*/
    void Update()
    {
        if ( dead == true )
        {
            Debug.Log("We are dead");
        }
    }
}
