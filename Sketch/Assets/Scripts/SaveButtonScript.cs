using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveButtonScript : MonoBehaviour
{

    public int saveState;
    public Text levelsDone;
    public GameObject confirmationPanel;

    private int numRegions = 4;
    private int numLevels = 12;

    public void setSaveState(int state){
        StaticInfo.saveProfle = state;
    }

    public void OpenConfirmationPanel(){
        int oldSave = StaticInfo.saveProfle;
        StaticInfo.saveProfle = saveState;
        DataSave.LoadData();

        int totalLevelsDone = 0;
        for (int i=0; i < numRegions; i++){
            totalLevelsDone += StaticInfo.levelInt[i];
        }

        if (totalLevelsDone != 0){              // If the save file isn't empty, ask for confirmation
            StaticInfo.saveProfle = oldSave;
            DataSave.LoadData();
            confirmationPanel.SetActive(true);
        }
        else{                                   // Save file is already empty, go straight to load
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void deleteSaveData(int state){
        int oldSave = StaticInfo.saveProfle;
        StaticInfo.saveProfle = state;
        DataSave.LoadData();

        for (int i=0; i < numRegions; i++){
            StaticInfo.levelInt[i] = 0;
        }
        for (int i=0; i < numLevels; i++){
            StaticInfo.levelBool[i] = false;
        }
        StaticInfo.health = 3;

        DataSave.SaveData();

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
        }
        levelsDone.text = "Levels done: " + totalLevelsDone;

        StaticInfo.saveProfle = oldSave;
        DataSave.LoadData();
    }

    void Start(){
        UpdateSaveText();
    }
}
