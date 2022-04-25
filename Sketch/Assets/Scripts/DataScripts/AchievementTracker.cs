using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    private static int initialNumEnemies;
    private static GameObject am;

    void Awake(){
        DataSave.LoadData();
        am = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        initialNumEnemies = enemies.Length;
    }
    public static bool CheckPro(){
        return StaticInfo.health == am.GetComponent<HeartSystem>().life;
    }

    public static bool CheckTrace(){
        GameObject shape = GameObject.FindGameObjectWithTag("SpawnedShape");
        return shape == null;
    }

    public static bool CheckSpotless(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Enemies length: " + enemies.Length);
        return enemies.Length == 0;
    }

    public static bool CheckPacifist(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == initialNumEnemies;
    }
}
