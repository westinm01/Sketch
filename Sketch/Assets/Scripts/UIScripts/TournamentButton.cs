using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentButton : MonoBehaviour
{
    void OnEnable(){
        if (StaticInfo.health != 15){
            this.gameObject.SetActive(false);
        }
    }
}
