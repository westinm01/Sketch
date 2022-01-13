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
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        maxLives = StaticInfo.health;
        life = maxLives;
        hearts = _canvas.GetComponentsInChildren<Heart>();
        // Debug.Log(hearts.Length);
        for (int i=0; i < maxLives; i++){
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
            //gameobject.getcomponent<am_movement>().enabled = false;
            //gameobject.getcomponent<changepencilmode>().enabled = false;
            //gameobject.getcomponent<amcombat>().enabled = false;
            //gameobject.getcomponent<heartsystem>().enabled = false;
            //gameobject.getcomponent<amabyss>().enabled = false;
            //gameobject.getcomponent<animator>().enabled = false;
            //gameobject.getcomponentinchildren<ground_check>().enabled = false;
            //gameobject.getcomponentinchildren<shape_creation>().enabled = false;
            //gameobject.getcomponentinchildren<shape_erase>().enabled = false;
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
