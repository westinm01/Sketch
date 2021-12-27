using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas _canvas;
    public GameObject Am;
    public int life;
    public int maxLives = 3;
    public bool devMode = false;
    private Heart[] hearts;
    private bool dead;
    private GameManager gm;

    // Update is called once per frame

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        life = maxLives;
        hearts = _canvas.GetComponentsInChildren<Heart>();
        // Debug.Log(hearts.Length);
        for (int i=0; i < life; i++){
            hearts[i].restoreHeart();
        }
    }
    public void TakeDamage(int d)
    {
        if (devMode){
            return;
        }
        life -= d;
        hearts[life].loseHeart();
        // Destroy(hearts[life].gameObject);
        if ( life < 1 )
        {
            Debug.Log("Game is over");
            gm.GameOver();
            // dead = true;
            // Time.timeScale = 0;
            // gameObject.GetComponent<Am_Movement>().enabled = false;
            // gameObject.GetComponent<ChangePencilMode>().enabled = false;
            // gameObject.GetComponent<AmCombat>().enabled = false;
            // gameObject.GetComponent<HeartSystem>().enabled = false;
            // gameObject.GetComponent<AmAbyss>().enabled = false;
            // gameObject.GetComponent<Animator>().enabled = false;
            // gameObject.GetComponentInChildren<Ground_Check>().enabled = false;
            // gameObject.GetComponentInChildren<Shape_Creation>().enabled = false;
            // gameObject.GetComponentInChildren<Shape_Erase>().enabled = false;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player" )
        {
            TakeDamage(1);
        }
    }*/
    // void Update()
    // {
    //     if ( dead == true )
    //     {
    //         Debug.Log("We are dead");
    //     }
    // }
}
