using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomKeybindButton : MonoBehaviour
{
    public string action;
    private Text keyText;

    void Start(){
        gameObject.GetComponent<Button>().onClick.AddListener(WaitForInputWrapper);
    }

    void OnEnable(){
        keyText = GetComponentInChildren<Text>();
        UpdateText();
    }

    void UpdateText(){
        keyText.text = PlayerPrefs.GetString(action);
    }

    private void WaitForInputWrapper(){
        keyText.text = "";
        StartCoroutine(WaitForInput());
    }

    private IEnumerator WaitForInput(){
        float timer = 0;
        while (!Input.anyKeyDown && timer < 10){
            timer += Time.deltaTime;
            yield return null;
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            // Do nothing, exit without changing controls
        }
        else if (Input.GetKeyDown(KeyCode.Space)){
            StaticControls.SetKeyMap(action, KeyCode.Space);
        }
        else if (Input.GetKeyDown(KeyCode.Tab)){
            StaticControls.SetKeyMap(action, KeyCode.Tab);
        }
        else{
            for (int i=0; i < 10; i++){         // Check for numbers, convert to Alpha
                if (Input.GetKeyDown((KeyCode)(48 + i))){
                    Debug.Log(i + " key was pressed");
                    StaticControls.SetKeyMap(action, (KeyCode)(48 + i));
                    UpdateText();
                    yield break;                // Exit early to avoid setting keybind twice
                }
            }
            Debug.Log(Input.inputString);
            KeyCode currCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());  // Convert string to keyCode
            StaticControls.SetKeyMap(action, currCode);
            // keyText.text = Input.inputString;
        }
        UpdateText();
    }
}
