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
    public Color IppocCompletionColor;
    public Color DalCompletionColor;
    public Color TempraCompletionColor;
    public Color WerCompletionColor;
    public Color ThalaCompletionColor;
    public Color IneCompletionColor;
    public Color OcciCompletionColor;
    public Color PoCompletionColor;

    public void selectMap(GameObject selected){
        if (currSelected != null){
            currSelected.SetActive(false);
        }
        currSelected = selected;
        currSelected.SetActive(true);
    }
    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }


    private void Start()
    {
        UpdateMap();
        SaveMap();
        //Debug.Log(StaticInfo.levelInt[0]);
        //Debug.Log(StaticInfo.levelInt[1]);
        //Debug.Log(StaticInfo.levelInt[2]);
        //Debug.Log(StaticInfo.levelInt[3]);

        if (StaticInfo.bossBool[0] == true) GameObject.Find("Othal").GetComponent<Image>().color = OthalCompletionColor;

        if (StaticInfo.bossBool[1] == true) GameObject.Find("Roc").GetComponent<Image>().color = RocCompletionColor;

        if (StaticInfo.bossBool[2] == true) GameObject.Find("Medu").GetComponent<Image>().color = MeduCompletionColor;

        if (StaticInfo.bossBool[3] == true) GameObject.Find("Pitu").GetComponent<Image>().color = PituCompletionColor;

        if (StaticInfo.bossBool[4] == true) GameObject.Find("Ippoc").GetComponent<Image>().color = IppocCompletionColor;

        if (StaticInfo.bossBool[5] == true) GameObject.Find("Dal").GetComponent<Image>().color = DalCompletionColor;

        if (StaticInfo.bossBool[6] == true) GameObject.Find("Tempra").GetComponent<Image>().color = TempraCompletionColor;

        if (StaticInfo.bossBool[7] == true) GameObject.Find("Wer").GetComponent<Image>().color = WerCompletionColor;

        if (StaticInfo.bossBool[8] == true) GameObject.Find("Thala").GetComponent<Image>().color = ThalaCompletionColor;

        if (StaticInfo.bossBool[9] == true) GameObject.Find("Ine").GetComponent<Image>().color = IneCompletionColor;

        if (StaticInfo.bossBool[10] == true) GameObject.Find("Occi").GetComponent<Image>().color = OcciCompletionColor;

        if (StaticInfo.bossBool[11] == true) GameObject.Find("Po").GetComponent<Image>().color = PoCompletionColor;


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
            gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
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
            gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
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
            gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
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
            gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(7).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(7).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[12] == true)
        {
            StaticInfo.levelInt[4] = 1;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[13] == true)
        {
            StaticInfo.levelInt[4] = 2;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[14] == true)
        {
            StaticInfo.levelInt[4] = 3;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[15] == true)
        {
            StaticInfo.levelInt[5] = 1;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[16] == true)
        {
            StaticInfo.levelInt[5] = 2;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[17] == true)
        {
            StaticInfo.levelInt[5] = 3;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(9).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(9).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[18] == true)
        {
            StaticInfo.levelInt[6] = 1;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[19] == true)
        {
            StaticInfo.levelInt[6] = 2;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[20] == true)
        {
            StaticInfo.levelInt[6] = 3;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(10).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(10).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[21] == true)
        {
            StaticInfo.levelInt[7] = 1;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[22] == true)
        {
            StaticInfo.levelInt[7] = 2;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[23] == true)
        {
            StaticInfo.levelInt[7] = 3;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(11).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(11).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[24] == true)
        {
            StaticInfo.levelInt[8] = 1;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[25] == true)
        {
            StaticInfo.levelInt[8] = 2;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[26] == true)
        {
            StaticInfo.levelInt[8] = 3;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(5).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(5).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[27] == true)
        {
            StaticInfo.levelInt[9] = 1;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[28] == true)
        {
            StaticInfo.levelInt[9] = 2;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[29] == true)
        {
            StaticInfo.levelInt[9] = 3;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[30] == true)
        {
            StaticInfo.levelInt[10] = 1;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[31] == true)
        {
            StaticInfo.levelInt[10] = 2;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[32] == true)
        {
            StaticInfo.levelInt[10] = 3;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }



        gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Button>().enabled = true;
        gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().color = Color.white;
        if (StaticInfo.levelBool[33] == true)
        {
            StaticInfo.levelInt[11] = 1;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(3).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[34] == true)
        {
            StaticInfo.levelInt[11] = 2;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(4).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().color = Color.white;
        }
        if (StaticInfo.levelBool[35] == true)
        {
            StaticInfo.levelInt[11] = 3;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetComponent<Image>().color = Color.white;
            gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        }

        // StaticInfo.health = (StaticInfo.levelInt[0] + StaticInfo.levelInt[1] + StaticInfo.levelInt[2]) / 3 + 3; //for each new region add data levelInt;
        StaticInfo.health = 3;
        foreach (bool bossCompleted in StaticInfo.bossBool){
            if (bossCompleted){
                StaticInfo.health++;
            }
        }
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
