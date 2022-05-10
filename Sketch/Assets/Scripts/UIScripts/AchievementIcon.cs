using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementIcon : MonoBehaviour
{
    public Sprite filledImage;
    public Sprite blankImage;
    public void activateAchievement(){
        gameObject.GetComponent<SpriteRenderer>().sprite = filledImage;
    }

    public void DeactivateAchievement(){
        gameObject.GetComponent<SpriteRenderer>().sprite = blankImage;
    }
}
