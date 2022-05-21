using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo
{
    public static int[] levelInt = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // each index represents a region and the number represents how many levels have been completed in that region.
    public static bool[] levelBool = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };  // each index represents a level corresponding with the build manager index list.
    public static int health = 3;
    public static bool[] bossBool = { false, false, false, false, false, false, false, false, false, false, false, false };
    public static int saveProfle = 1;
    public static bool[,] achievementBool = {{false, false, false, false}, {false, false, false, false}, {false, false, false, false},   // Othal
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Roc
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Medu
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Pitu
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Ippoc
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Dal
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Tempra
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Wer
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Thala
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Ine
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false},    // Occi
                                            {false, false, false, false}, {false, false, false, false}, {false, false, false, false}};   // Po

    public static float playTime = 0;

    public static bool hasWon = false;
    public static bool playedCutscene = false;

    public static void ResetLevelInt(){
        for (int i=0; i < levelInt.Length; i++){
            levelInt[i] = 0;
        }
    }
}
