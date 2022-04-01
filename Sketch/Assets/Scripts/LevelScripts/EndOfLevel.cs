using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    private void Awake()
    {
        DataSave.LoadData();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinGame(collision);
            Debug.Log(StaticInfo.playTime);
            // GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        }
    }

    public static void UpdateAchievements(int currentLevel){
        // Debug.Log(currentLevel);
        if (AchievementTracker.CheckPro()){
            StaticInfo.achievementBool[currentLevel, 0] = true;
        }
        if (AchievementTracker.CheckTrace()){
            StaticInfo.achievementBool[currentLevel, 1] = true;

        }
        if (AchievementTracker.CheckSpotless()){
            StaticInfo.achievementBool[currentLevel, 2] = true;

        }
        if (AchievementTracker.CheckPacifist()){
            StaticInfo.achievementBool[currentLevel, 3] = true;
        }
    }

    public static void WinGame(Collider2D collision)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel <= 37)
        {
            StaticInfo.levelBool[currentLevel - 2] = true;
            UpdateAchievements(currentLevel - 2);
        }
        else if (currentLevel == 38)
        {
            StaticInfo.bossBool[0] = true;
        }

        else if (currentLevel == 39)
        {
            StaticInfo.bossBool[1] = true;
        }

        else if (currentLevel == 40)
        {
            StaticInfo.bossBool[2] = true;
        }

        else if (currentLevel == 41)
        {
            StaticInfo.bossBool[3] = true;
        }

        else if (currentLevel == 42)
        {
            StaticInfo.bossBool[4] = true;
        }

        else if (currentLevel == 43)
        {
            StaticInfo.bossBool[5] = true;
        }

        else if (currentLevel == 44)
        {
            StaticInfo.bossBool[6] = true;
        }

        else if (currentLevel == 45)
        {
            StaticInfo.bossBool[7] = true;
        }

        else if (currentLevel == 46)
        {
            StaticInfo.bossBool[8] = true;
        }

        else if (currentLevel == 47)
        {
            StaticInfo.bossBool[9] = true;
        }

        else if (currentLevel == 48)
        {
            StaticInfo.bossBool[10] = true;
        }

        else if (currentLevel == 49)
        {
            StaticInfo.bossBool[11] = true;
        }
        DataSave.SaveData();

        // Time.timeScale = 0;

        // collision.gameObject.GetComponent<Am_Movement>().enabled = false;
        // collision.gameObject.GetComponent<ChangePencilMode>().enabled = false;
        // collision.gameObject.GetComponent<AmCombat>().enabled = false;
        // collision.gameObject.GetComponent<HeartSystem>().enabled = false;
        // collision.gameObject.GetComponent<AmAbyss>().enabled = false;
        // collision.gameObject.GetComponent<Animator>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Ground_Check>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Shape_Creation>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Shape_Erase>().enabled = false;
        SceneManager.LoadScene(1);
    }
}
