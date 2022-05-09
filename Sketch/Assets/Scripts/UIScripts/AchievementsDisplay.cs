using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsDisplay : MonoBehaviour
{
    public int levelIndex;
    private GameObject pro;
    private GameObject trace;
    private GameObject spotless;
    private GameObject pacifist;

    // Start is called before the first frame update
    void Awake()
    {
        DataSave.LoadData();
        pro = gameObject.transform.GetChild(0).gameObject;
        trace = gameObject.transform.GetChild(1).gameObject;
        spotless = gameObject.transform.GetChild(2).gameObject;
        pacifist = gameObject.transform.GetChild(3).gameObject;

        if (StaticInfo.achievementBool[levelIndex, 0]){
            // pro.SetActive(true);
            pro.GetComponent<AchievementIcon>().activateAchievement();
        }
        if (StaticInfo.achievementBool[levelIndex, 1]){
            // trace.SetActive(true);
            trace.GetComponent<AchievementIcon>().activateAchievement();

        }
        if (StaticInfo.achievementBool[levelIndex, 2]){
            // spotless.SetActive(true);
            spotless.GetComponent<AchievementIcon>().activateAchievement();

        }
        if (StaticInfo.achievementBool[levelIndex, 3]){
            // pacifist.SetActive(true);
            pacifist.GetComponent<AchievementIcon>().activateAchievement();
        }
    }
}
