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

    public static void InitializeDictionary(){
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i=0; i < keyMaps.Length; i++){
            if (!PlayerPrefs.HasKey(keyMaps[i])){
                PlayerPrefs.SetString(keyMaps[i], defaults[i].ToString());
            }
            KeyCode currCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keyMaps[i]));  // Convert saved playerPref string to keyCode
            keyMapping.Add(keyMaps[i], currCode);
        }
    }

    public static void ResetToDefault(){
        for (int i=0; i < keyMaps.Length; i++){
            PlayerPrefs.SetString(keyMaps[i], defaults[i].ToString());
        }
        InitializeDictionary();
    }

    public static KeyCode GetKeyCode(string keyMap){
        return keyMapping[keyMap];
    }

    public static int SetKeyMap(string keyMap, KeyCode key){
        if (!keyMapping.ContainsKey(keyMap)){
            Debug.Log("invalid keymap");
            return -1;
            // throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }
        keyMapping[keyMap] = key;
        PlayerPrefs.SetString(keyMap, key.ToString());
        Debug.Log(keyMap + " was successfully rebinded to " + key.ToString());
        return 0;
    }

    public static bool GetKeyDown(string keyMap){
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetButton(string keyMap){
        return Input.GetKey(keyMapping[keyMap]);
    }
}
