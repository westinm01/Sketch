using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocker_Anim : MonoBehaviour
{
    private Animator anim; 
    private GameManager gm;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        while ( !gm.isPaused)
        {
            if ( time % 2 == 0 )
            {
                anim.Play("Rocker_Blink");
            }
        }
    }
}
