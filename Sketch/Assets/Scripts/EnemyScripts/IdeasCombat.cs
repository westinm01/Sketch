using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasCombat : EnemyCombat
{
    public Projectile lightRay;
    public void attack(float direction){
        Projectile newRay = Instantiate(lightRay, gameObject.transform.position, Quaternion.identity);
        if (direction > 0){
            newRay.direction = new Vector2(1, 0);
        }
        else{
            newRay.direction = new Vector2(-1, 0);
        }
    }
}
