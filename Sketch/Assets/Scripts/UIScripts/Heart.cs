using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Heart : MonoBehaviour
{

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void loseHeart(){
        GetComponent<Image>().sprite = emptyHeart;
    }

    public void restoreHeart(){
        GetComponent<Image>().sprite = fullHeart;
    }
}
