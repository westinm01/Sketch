using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelector : MonoBehaviour
{
    public GameObject currSelected;
    public Color completionColor;

    public void selectMap(GameObject selected){
        if (currSelected != null){
            currSelected.SetActive(false);
        }
        currSelected = selected;
        currSelected.SetActive(true);
    }
    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }


    private void Start()
    {
        UpdateMap();
        SaveMap();
        //Debug.Log(levels[0]);

        if (StaticInfo.levelInt[0] == 3) GameObject.Find("Medu").GetComponent<Image>().color = completionColor;

        if (StaticInfo.levelInt[1] == 3) GameObject.Find("Pitu").GetComponent<Image>().color = completionColor;

        if (StaticInfo.levelInt[2] == 3) GameObject.Find("Rock").GetComponent<Image>().color = completionColor;
    }


    void UpdateMap()
    {
        DataSave.LoadData();

        if (StaticInfo.levelBool[0] == true) StaticInfo.levelInt[0] = 1;   //for each new region add a new 3 line block.
        if (StaticInfo.levelBool[1] == true) StaticInfo.levelInt[0] = 2;
        if (StaticInfo.levelBool[2] == true) StaticInfo.levelInt[0] = 3;

        if (StaticInfo.levelBool[3] == true) StaticInfo.levelInt[1] = 1;
        if (StaticInfo.levelBool[4] == true) StaticInfo.levelInt[1] = 2;
        if (StaticInfo.levelBool[5] == true) StaticInfo.levelInt[1] = 3;

        if (StaticInfo.levelBool[6] == true) StaticInfo.levelInt[2] = 1;
        if (StaticInfo.levelBool[7] == true) StaticInfo.levelInt[2] = 2;
        if (StaticInfo.levelBool[8] == true) StaticInfo.levelInt[2] = 3;

        StaticInfo.health = (StaticInfo.levelInt[0] + StaticInfo.levelInt[1] + StaticInfo.levelInt[2]) / 3 + 3; //for each new region add data levelInt;
    }

    void SaveMap()
    {
        DataSave.SaveData();
    }
}
