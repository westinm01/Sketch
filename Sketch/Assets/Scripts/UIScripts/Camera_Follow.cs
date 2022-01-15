using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public GameObject Am;

    // Start is called before the first frame update
    void Start()
    {
        Am = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Am.transform.position.x, Am.transform.position.y, -10);
    }
}
