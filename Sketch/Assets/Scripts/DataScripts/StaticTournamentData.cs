using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTournamentData : MonoBehaviour
{

    public static bool[] bossBool = { false, false, false, false, false, false, false, false, false, false, false, false };
    public static int health = StaticInfo.health;



    public static void ResetData(){
        DataSave.LoadData();
        for (int i=0; i < bossBool.Length; i++){
            bossBool[i] = false;
        }
        health = StaticInfo.health;
    }

    public static void WinTournament(){
        DataSave.LoadData();
        StaticInfo.hasWon = true;
        DataSave.SaveData();
    }
}
