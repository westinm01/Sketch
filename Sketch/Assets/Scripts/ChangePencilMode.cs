using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePencilMode : MonoBehaviour
{
    GameObject Pencil;
    bool canDraw = true;

    // Start is called before the first frame update
    void Start()
    {
        Pencil = GameObject.Find("Pencil");
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
            Pencil.transform.localRotation = Quaternion.Euler(0, 0, 15);
        }
        else if (!canDraw)
        {
            Pencil.transform.localRotation = Quaternion.Euler(0, 0, 195);
        }
        gameObject.GetComponentInChildren<Shape_Creation>().canDrawShapeCreation = canDraw;
        gameObject.GetComponentInChildren<Shape_Erase>().canDrawShapeErase = canDraw;
    }
}
