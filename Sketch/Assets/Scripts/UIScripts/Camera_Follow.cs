using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public GameObject Am;
    private bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        Am = GameObject.FindGameObjectWithTag("Player");
    }

    public void FreezeCamera(){
        isFrozen = true;
    }

    public void UnfreezeCamera(){
        isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFrozen){
            transform.position = new Vector3(Am.transform.position.x, Am.transform.position.y, -10);
        }
    }
}
