using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TournamentButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image img;

    [SerializeField] private Color grayedOutColor;
    void OnEnable(){
        if (StaticInfo.health != 15){
            img.color = grayedOutColor;
            button.enabled = false;
        }
        else{
            img.color = Color.white;
            button.enabled = true;
        }
    }
}
