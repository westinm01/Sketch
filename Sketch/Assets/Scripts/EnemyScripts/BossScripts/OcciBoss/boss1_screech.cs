using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1_screech : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BossCombat bc;
    private float lastHealth;
    private GameObject[] shapes;

    [SerializeField]
    private Animator anim;

    public boss1_falling_rocks rox;
   
    void Start()
    {
        lastHealth=bc.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(bc.health<lastHealth && bc.health>0)
        {
            lastHealth = bc.health;
            anim.SetBool("isHit",true);
            shapes = GameObject.FindGameObjectsWithTag("SpawnedShape");
            foreach (GameObject shape in shapes){
                Rigidbody2D rb2 = shape.GetComponent<Rigidbody2D>();
                rb2.mass = 10;
                rb2.AddForce(transform.right * -9000f);
            }
            // rox.nextTime/=2;
            rox.timeBetweenRocks -= 0.1f;
            
        }
    }
}
