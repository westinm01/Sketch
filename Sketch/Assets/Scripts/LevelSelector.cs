using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelector : MonoBehaviour
{
    public GameObject currSelected;
    public Color OthalCompletionColor;
    public Color RocCompletionColor;
    public Color MeduCompletionColor;
    public Color PituCompletionColor;

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
        Debug.Log(StaticInfo.levelInt[0]);
        Debug.Log(StaticInfo.levelInt[1]);
        Debug.Log(StaticInfo.levelInt[2]);
        Debug.Log(StaticInfo.levelInt[3]);
        if (StaticInfo.levelInt[0] == 3) GameObject.Find("Othal").GetComponent<Image>().color = OthalCompletionColor;

        if (StaticInfo.levelInt[1] == 3) GameObject.Find("Roc").GetComponent<Image>().color = RocCompletionColor;

        if (StaticInfo.levelInt[2] == 3) GameObject.Find("Medu").GetComponent<Image>().color = MeduCompletionColor;

        if (StaticInfo.levelInt[3] == 3) GameObject.Find("Pitu").GetComponent<Image>().color = PituCompletionColor;

        
    }


    void UpdateMap()
    {
        DataSave.LoadData();

        gameObject.transform.GetChild(1).GetChild(8).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(8).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[0] == true)  //for each new region add a new 3 line block.
        {
            StaticInfo.levelInt[0] = 1;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[1] == true)
        {
            StaticInfo.levelInt[0] = 2;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[2] == true)
        {
            StaticInfo.levelInt[0] = 3;
        }



        gameObject.transform.GetChild(1).GetChild(6).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(6).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[3] == true)
        {
            StaticInfo.levelInt[1] = 1;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[4] == true)
        {
            StaticInfo.levelInt[1] = 2;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[5] == true)
        {
            StaticInfo.levelInt[1] = 3;
        }



        gameObject.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[6] == true)
        {
            StaticInfo.levelInt[2] = 1;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[7] == true) 
        {
            StaticInfo.levelInt[2] = 2;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[8] == true)
        {
            StaticInfo.levelInt[2] = 3;
        }



        gameObject.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[9] == true)
        {
            StaticInfo.levelInt[3] = 1;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[10] == true)
        {
            StaticInfo.levelInt[3] = 2;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[11] == true)
        {
            StaticInfo.levelInt[3] = 3;
        }

        StaticInfo.health = (StaticInfo.levelInt[0] + StaticInfo.levelInt[1] + StaticInfo.levelInt[2]) / 3 + 3; //for each new region add data levelInt;
    }

    public void goBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SaveMap()
    {
        DataSave.SaveData();
    }
}
