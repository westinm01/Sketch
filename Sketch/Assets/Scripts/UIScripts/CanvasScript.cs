using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject UIElements;
    [SerializeField] private GameObject drawModeIndicator;
    [SerializeField] private GameObject eraseModeIndicator;


    private ChangePencilMode mode;

    void Awake(){
        mode = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangePencilMode>();
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
