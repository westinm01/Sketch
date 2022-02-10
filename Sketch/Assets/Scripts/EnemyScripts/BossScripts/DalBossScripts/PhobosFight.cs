using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosFight : MonoBehaviour
{
    public PhobosMovement phobos;
    public void StartFight(){
        phobos.isActive = true;
    }
}
