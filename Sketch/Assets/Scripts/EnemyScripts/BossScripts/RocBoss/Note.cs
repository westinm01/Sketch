using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject note1, emp;

    void Start()
    {
        //InstantiateGameObjects();    
    }

    
    
    public void InstantiateGameObjects(){
        emp = Instantiate(note1, transform.position, transform.rotation);
        emp.transform.Translate(new Vector3(0.5f,0,-1));
        Debug.Log("Note created");
    }
}
