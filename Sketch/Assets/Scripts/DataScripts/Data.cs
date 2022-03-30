using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Data
{
    public int[] levelInt = { 0, 0, 0, 0, 0, 0, 0, 0, 0 , 0, 0, 0 }; // each index represents a region and the number represents how many levels have been completed in that region.
    public bool[] levelBool = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };  // each index represents a level corresponding with the build manager index list.
    public int health = 3;
    public bool[] bossBool = { false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[,] achievementBool = {{false, false, false, false}, {false, false, false, false}, {false, false, false, false},   // Othal
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
    

    public Data(int[] levelInts, bool[] levelBools, int healths, bool[] bossBools, bool[,] achievementBools)
    {
        Array.Copy(levelInts, levelInt, levelInt.Length);
        Array.Copy(levelBools, levelBool, levelBool.Length);
        Array.Copy(bossBools, bossBool, bossBool.Length);
        health = healths;
        Array.Copy(achievementBools, achievementBool, achievementBool.Length);
    }
}