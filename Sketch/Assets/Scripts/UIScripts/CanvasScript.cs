using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject UIElements;
    [SerializeField] private GameObject drawModeIndicator;
    [SerializeField] private GameObject eraseModeIndicator;

    [SerializeField] private TextMeshProUGUI currShapeText;
    [SerializeField] private TextMeshProUGUI prevShapeText;
    [SerializeField] private TextMeshProUGUI nextShapeText;



    private ChangePencilMode mode;

    void Awake(){
        mode = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangePencilMode>();
        currShapeText.text = PlayerPrefs.GetString("PlaceBlock").ToLower();
        prevShapeText.text = PlayerPrefs.GetString("SwitchLeft").ToLower();
        nextShapeText.text = PlayerPrefs.GetString("SwitchRight").ToLower();
    }

    public void UpdateIndicators(){
        if (mode.canDraw){
            drawModeIndicator.SetActive(true);
            eraseModeIndicator.SetActive(false);
        }
        else{
            drawModeIndicator.SetActive(false);
            eraseModeIndicator.SetActive(true);
        }
    }

    public void DisableUI(){
        UIElements.SetActive(false);
    }

    public void EnableUI(){
        UIElements.SetActive(true);
    }
}
