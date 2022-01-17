using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo
{
    public static int[] levelInt = { 0, 0, 0 }; // each index represents a region and the number represents how many levels have been completed in that region.  Change in staticinfo.cs and data.cs class
    public static bool[] levelBool = { false, false, false, false, false, false, false, false, false };  // each index represents a level corresponding with the build manager index list.
    public static int health = 3;
}
