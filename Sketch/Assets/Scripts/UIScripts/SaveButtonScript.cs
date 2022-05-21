using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveButtonScript : MonoBehaviour
{

    public int saveState;
    public Text levelsDone;
    public Text playTimeText;
    public GameObject confirmationPanel;
    public GameObject heart;
    public GameObject star;

    private int numRegions = 12;
    private int numLevels = 36;
    private int numAchievements = 4;

    void OnEnable(){
        UpdateSaveText();
    }

    public void setSaveState(int state){
        StaticInfo.saveProfle = state;
        DataSave.LoadData();
    }

    public void OpenConfirmationPanel(){
        int oldSave = StaticInfo.saveProfle;
        StaticInfo.saveProfle = saveState;
        DataSave.LoadData();

        int totalLevelsDone = 0;
        for (int i=0; i < numRegions; i++){
            totalLevelsDone += StaticInfo.levelInt[i];
            if (StaticInfo.bossBool[i] == true) ++totalLevelsDone;
        }

        if (totalLevelsDone != 0){              // If the save file isn't empty, ask for confirmation
            StaticInfo.saveProfle = oldSave;
            DataSave.LoadData();
            confirmationPanel.SetActive(true);
        }
        else{                                   // Save file is already empty, go straight to load
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(2);
        }
    }

    public void deleteSaveData(int state){
        int oldSave = StaticInfo.saveProfle;
        StaticInfo.saveProfle = state;
        DataSave.LoadData();

        for (int i=0; i < numRegions; i++){
            StaticInfo.levelInt[i] = 0;
            StaticInfo.bossBool[i] = false;
        }
        for (int i=0; i < numLevels; i++){
            StaticInfo.levelBool[i] = false;
        }
        for (int i=0; i < numLevels; i++){
            for (int j=0; j < numAchievements; j++){
                StaticInfo.achievementBool[i, j] = false;
            }
        }
        StaticInfo.health = 3;
        StaticInfo.playTime = 0;
        StaticInfo.hasWon = false;
        StaticInfo.playedCutscene = false;
        DataSave.SaveData();
        UpdateSaveText();
        StaticInfo.saveProfle = oldSave;
        DataSave.LoadData();
        UpdateSaveText();
    }

    public void UpdateSaveText(){
        int oldSave = StaticInfo.saveProfle;
        StaticInfo.saveProfle = saveState;
        DataSave.LoadData();

        int totalLevelsDone = 0;
        for (int i=0; i < numRegions; i++){
            totalLevelsDone += StaticInfo.levelInt[i];
            if (StaticInfo.bossBool[i] == true) ++totalLevelsDone;
        }
        levelsDone.text = "Levels done: " + totalLevelsDone;

        float xPos = -1.75f;
        float yPos = 0;
        float xOffset = 0.25f;
        Vector3 curPos = gameObject.transform.position;

        for (int i=0; i < StaticInfo.health; i++){
            Heart newHeart = Instantiate(heart, curPos + new Vector3(xPos, yPos), Quaternion.identity).GetComponent<Heart>();
            newHeart.transform.SetParent(gameObject.transform);
            newHeart.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            newHeart.restoreHeart();
            xPos += xOffset;
        }

        float hours = StaticInfo.playTime / 3600;
        float minutes = (hours - (int)(hours)) * 60;        // Convert leftover hours into minutes
        float seconds = (minutes - (int)(minutes)) * 60;    // Convert leftover minutes into seconds
        string hoursString = ((int)(hours)).ToString("00");
        string minutesString = ((int)(minutes)).ToString("00");
        string secondsString = ((int)(seconds)).ToString("00");

        playTimeText.text = hoursString + ":" + minutesString + ":" + secondsString;

        if (StaticInfo.health == 15){
            star.SetActive(true);
        }
        else{
            star.SetActive(false);
        }

        StaticInfo.saveProfle = oldSave;
        DataSave.LoadData();
    }

}
