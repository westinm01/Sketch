using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmCombat : MonoBehaviour
{
    public int amHealth;

    public void AmTakeDamage(int damage)
    {
        amHealth -= damage;
    }
    
}
