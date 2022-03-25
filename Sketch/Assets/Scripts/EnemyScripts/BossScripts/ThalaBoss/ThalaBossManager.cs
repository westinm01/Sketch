using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThalaBossManager : MonoBehaviour
{
    public ChronolithCombat Chronolith;
    public WormSpawn worms;
    public ClockSpawner clocks;
    public float attackTimer;
    private float attackPhase; 
    private float attackTime;
    private int phase = 1;
    // Start is called before the first frame update
    void Start()
    {
        attackPhase = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //if ( attackTime <= attackTimer )
        //{
            switch(attackPhase)
            {
                case 0:
                    if ( Chronolith.health < 4 )
                    {
                        attackPhase = 1;    
                    }
                    break;
                case 1: 
                    if ( Chronolith.health < 3 )
                    {
                        attackPhase = 2;
                    }
                    worms.enabled = true;
                    break;
                case 2: 
                    clocks.enabled = true; 
                    break; 
            }
        //}
    }
}
