using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePencilMode : MonoBehaviour
{
    // GameObject Pencil;
    // GameObject drawIndicator, eraseIndicator;
    private CanvasScript canvas;
    public bool canDraw = true;

    // Start is called before the first frame update
    void Start()
    {
        canDraw = true;
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>();
        canvas.UpdateIndicators();
        // Pencil = GameObject.Find("Pencil");
        // drawIndicator = GameObject.Find("Mode Indicator").transform.GetChild(0).gameObject;
        // eraseIndicator = GameObject.Find("Mode Indicator").transform.GetChild(1).gameObject;

        // eraseIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticControls.GetKeyDown("SwitchMode"))
        {
            canDraw = !canDraw;
            canvas.UpdateIndicators();
            // if (canDraw)
            // {
            //     // Pencil.transform.localRotation = Quaternion.Euler(0, 0, 15);
            //     drawIndicator.SetActive(true);
            //     eraseIndicator.SetActive(false);
            // }
            // else if (!canDraw)
            // {
            //     // Pencil.transform.localRotation = Quaternion.Euler(0, 0, 195);
            //     eraseIndicator.SetActive(true);
            //     drawIndicator.SetActive(false);
            // }
            gameObject.GetComponentInChildren<Shape_Creation>().canDrawShapeCreation = canDraw;
            gameObject.GetComponentInChildren<Shape_Erase>().canDrawShapeErase = canDraw;
            gameObject.GetComponentInChildren<Shape_Highlight>().canDrawShapeErase = canDraw;
        }
    }
}
