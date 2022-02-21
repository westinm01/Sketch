using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePencilMode : MonoBehaviour
{
    // GameObject Pencil;
    GameObject drawIndicator, eraseIndicator;
    public bool canDraw = true;

    // Start is called before the first frame update
    void Start()
    {
        // Pencil = GameObject.Find("Pencil");
        drawIndicator = GameObject.Find("Mode Indicator").transform.GetChild(0).gameObject;
        eraseIndicator = GameObject.Find("Mode Indicator").transform.GetChild(1).gameObject;

        eraseIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canDraw = !canDraw;
        }
        if (canDraw)
        {
            // Pencil.transform.localRotation = Quaternion.Euler(0, 0, 15);
            drawIndicator.SetActive(true);
            eraseIndicator.SetActive(false);
        }
        else if (!canDraw)
        {
            // Pencil.transform.localRotation = Quaternion.Euler(0, 0, 195);
            eraseIndicator.SetActive(true);
            drawIndicator.SetActive(false);
        }
        gameObject.GetComponentInChildren<Shape_Creation>().canDrawShapeCreation = canDraw;
        gameObject.GetComponentInChildren<Shape_Erase>().canDrawShapeErase = canDraw;
        gameObject.GetComponentInChildren<Shape_Highlight>().canDrawShapeErase = canDraw;
    }
}
