using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticControls
{
    static Dictionary<string, KeyCode> keyMapping;
    static string[] keyMaps = new string[3]
    {
        "Left",
        "Right",
        "Jump"
    };

    static KeyCode[] defaults = new KeyCode[3]
    {
        KeyCode.A,
        KeyCode.D,
        KeyCode.Space
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
}
