using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Data
{
    public int[] levelInt = { 0, 0, 0, 0, 0 }; // each index represents a region and the number represents how many levels have been completed in that region.
    public bool[] levelBool = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };  // each index represents a level corresponding with the build manager index list.
    public int health = 3;
    

    public Data(int[] levelInts, bool[] levelBools, int healths)
    {
        Array.Copy(levelInts, levelInt, levelInt.Length);
        Array.Copy(levelBools, levelBool, levelBool.Length);
        health = healths;
    }
}