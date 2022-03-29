using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementIcon : MonoBehaviour
{
    public Sprite filledImage;
    public void activateAchievement(){
        gameObject.GetComponent<SpriteRenderer>().sprite = filledImage;
    }
}
