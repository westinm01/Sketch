using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelector : MonoBehaviour
{
    public GameObject currSelected;
    public Color defaultColor = Color.white;
    public Color grayedOutColor;
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

    public GameObject EndCutscene;

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


    protected virtual void OnEnable()
    {
        UpdateMap();
        SaveMap();
        //Debug.Log(StaticInfo.levelInt[0]);
        //Debug.Log(StaticInfo.levelInt[1]);
        //Debug.Log(StaticInfo.levelInt[2]);
        //Debug.Log(StaticInfo.levelInt[3]);

        if (StaticInfo.bossBool[0] == true){
            GameObject.Find("Othal").GetComponent<Image>().color = OthalCompletionColor;
        }
        else{
            GameObject.Find("Othal").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[1] == true){
            GameObject.Find("Roc").GetComponent<Image>().color = RocCompletionColor;
        }
        else{
            GameObject.Find("Roc").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[2] == true){
            GameObject.Find("Medu").GetComponent<Image>().color = MeduCompletionColor;
        }
        else{
            GameObject.Find("Medu").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[3] == true){
            GameObject.Find("Pitu").GetComponent<Image>().color = PituCompletionColor;
        }
        else{
            GameObject.Find("Pitu").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[4] == true){
            GameObject.Find("Ippoc").GetComponent<Image>().color = IppocCompletionColor;
        }
        else{
            GameObject.Find("Ippoc").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[5] == true){
            GameObject.Find("Dal").GetComponent<Image>().color = DalCompletionColor;
        }
        else{
            GameObject.Find("Dal").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[6] == true){
            GameObject.Find("Tempra").GetComponent<Image>().color = TempraCompletionColor;
        }
        else{
            GameObject.Find("Tempra").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[7] == true){
            GameObject.Find("Wer").GetComponent<Image>().color = WerCompletionColor;
        }
        else{
            GameObject.Find("Wer").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[8] == true){
            GameObject.Find("Thala").GetComponent<Image>().color = ThalaCompletionColor;
        }
        else{
            GameObject.Find("Thala").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[9] == true){
            GameObject.Find("Ine").GetComponent<Image>().color = IneCompletionColor;
        }
        else{
            GameObject.Find("Ine").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[10] == true){
            GameObject.Find("Occi").GetComponent<Image>().color = OcciCompletionColor;
        }
        else{
            GameObject.Find("Occi").GetComponent<Image>().color = defaultColor;
        }
        if (StaticInfo.bossBool[11] == true){
            GameObject.Find("Po").GetComponent<Image>().color = PoCompletionColor;
        }
        else{
            GameObject.Find("Po").GetComponent<Image>().color = defaultColor;
        }

    }


    void UpdateMap()
    {
        DataSave.LoadData();

        // Activate the first level of each region
        for (int i=0; i < 12; i++){
            gameObject.transform.GetChild(1).GetChild(i).GetChild(2).GetComponent<Button>().enabled = true;
            gameObject.transform.GetChild(1).GetChild(i).GetChild(2).GetComponent<Image>().color = Color.white;
        }

        // Check if what region levels have been completed and activate the correct levels
        StaticInfo.ResetLevelInt();
        Debug.Log(StaticInfo.levelBool[0]);
        Debug.Log(StaticInfo.levelBool[1]);
        Debug.Log(StaticInfo.levelBool[2]);

        for(int i=0; i < StaticInfo.levelBool.Length; i++){
            if (StaticInfo.levelBool[i]){
                StaticInfo.levelInt[i % 3]++;
                gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetComponent<Button>().enabled = true;
                gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetComponent<Image>().color = Color.white;
                if (i % 3 == 2){
                    gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            else{
                gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetComponent<Button>().enabled = false;
                gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetComponent<Image>().color = grayedOutColor;
                if (i % 3 == 2){
                    gameObject.transform.GetChild(1).GetChild(i / 3).GetChild((i % 3)+3).GetChild(1).GetComponent<SpriteRenderer>().color = grayedOutColor;
                }
            }
        }

        

        // gameObject.transform.GetChild(1).GetChild(8).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(8).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[0] == true)  //for each new region add a new 3 line block.
        // {
        //     StaticInfo.levelInt[0] = 1;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[1] == true)
        // {
        //     StaticInfo.levelInt[0] = 2;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[2] == true)
        // {
        //     StaticInfo.levelInt[0] = 3;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(8).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }

        // gameObject.transform.GetChild(1).GetChild(6).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(6).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[3] == true)
        // {
        //     StaticInfo.levelInt[1] = 1;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[4] == true)
        // {
        //     StaticInfo.levelInt[1] = 2;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[5] == true)
        // {
        //     StaticInfo.levelInt[1] = 3;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(6).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[6] == true)
        // {
        //     StaticInfo.levelInt[2] = 1;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[7] == true) 
        // {
        //     StaticInfo.levelInt[2] = 2;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[8] == true)
        // {
        //     StaticInfo.levelInt[2] = 3;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(2).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[9] == true)
        // {
        //     StaticInfo.levelInt[3] = 1;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[10] == true)
        // {
        //     StaticInfo.levelInt[3] = 2;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[11] == true)
        // {
        //     StaticInfo.levelInt[3] = 3;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(4).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(7).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(7).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[12] == true)
        // {
        //     StaticInfo.levelInt[4] = 1;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[13] == true)
        // {
        //     StaticInfo.levelInt[4] = 2;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[14] == true)
        // {
        //     StaticInfo.levelInt[4] = 3;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(7).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[15] == true)
        // {
        //     StaticInfo.levelInt[5] = 1;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[16] == true)
        // {
        //     StaticInfo.levelInt[5] = 2;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[17] == true)
        // {
        //     StaticInfo.levelInt[5] = 3;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(3).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(9).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(9).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[18] == true)
        // {
        //     StaticInfo.levelInt[6] = 1;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[19] == true)
        // {
        //     StaticInfo.levelInt[6] = 2;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[20] == true)
        // {
        //     StaticInfo.levelInt[6] = 3;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(9).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(10).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(10).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[21] == true)
        // {
        //     StaticInfo.levelInt[7] = 1;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[22] == true)
        // {
        //     StaticInfo.levelInt[7] = 2;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[23] == true)
        // {
        //     StaticInfo.levelInt[7] = 3;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(10).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(11).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(11).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[24] == true)
        // {
        //     StaticInfo.levelInt[8] = 1;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[25] == true)
        // {
        //     StaticInfo.levelInt[8] = 2;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[26] == true)
        // {
        //     StaticInfo.levelInt[8] = 3;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(11).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(5).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(5).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[27] == true)
        // {
        //     StaticInfo.levelInt[9] = 1;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[28] == true)
        // {
        //     StaticInfo.levelInt[9] = 2;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[29] == true)
        // {
        //     StaticInfo.levelInt[9] = 3;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(5).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[30] == true)
        // {
        //     StaticInfo.levelInt[10] = 1;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[31] == true)
        // {
        //     StaticInfo.levelInt[10] = 2;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[32] == true)
        // {
        //     StaticInfo.levelInt[10] = 3;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(0).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }



        // gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Button>().enabled = true;
        // gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>().color = Color.white;
        // if (StaticInfo.levelBool[33] == true)
        // {
        //     StaticInfo.levelInt[11] = 1;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(3).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[34] == true)
        // {
        //     StaticInfo.levelInt[11] = 2;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(4).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(4).GetComponent<Image>().color = Color.white;
        // }
        // if (StaticInfo.levelBool[35] == true)
        // {
        //     StaticInfo.levelInt[11] = 3;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetComponent<Button>().enabled = true;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetComponent<Image>().color = Color.white;
        //     gameObject.transform.GetChild(1).GetChild(1).GetChild(5).GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        // }

        // StaticInfo.health = (StaticInfo.levelInt[0] + StaticInfo.levelInt[1] + StaticInfo.levelInt[2]) / 3 + 3; //for each new region add data levelInt;
        StaticInfo.health = 3;
        foreach (bool bossCompleted in StaticInfo.bossBool){
            if (bossCompleted){
                StaticInfo.health++;
            }
        }

        if (StaticInfo.health == 15 && !StaticInfo.playedCutscene){
            StaticInfo.playedCutscene = true;
            EndCutscene.SetActive(true);
        }
    }

    public virtual void goBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SaveMap()
    {
        DataSave.SaveData();
    }

    public void EnterTournament(){
        StaticTournamentData.ResetData();
        LoadLevel("TournamentSelect");
    }
}
