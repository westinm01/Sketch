using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticControls
{
    static Dictionary<string, KeyCode> keyMapping;
    static string[] keyMaps = new string[9]
    {
        "Left",
        "Right",
        "Jump",
        "PlaceBlock",
        "SwitchLeft",
        "SwitchRight",
        "EraseBlock",
        "ErasePlatform",
        "SwitchMode"
    };

    static KeyCode[] defaults = new KeyCode[9]
    {
        KeyCode.A,
        KeyCode.D,
        KeyCode.Space,
        KeyCode.F,
        KeyCode.Q,
        KeyCode.E,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Tab
    };

    static StaticControls(){
        InitializeDictionary();
    }

    private static void InitializeDictionary(){
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i=0; i < keyMaps.Length; i++){
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key){
        if (!keyMapping.ContainsKey(keyMap)){
            Debug.Log("invalid keymap");
            // throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap){
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetButton(string keyMap){
        return Input.GetKey(keyMapping[keyMap]);
    }
}
