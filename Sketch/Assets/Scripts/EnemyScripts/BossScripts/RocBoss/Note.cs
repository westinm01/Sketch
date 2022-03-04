using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject note1, note2, note3, emp;

    void Start()
    {
        //InstantiateGameObjects();    
    }

    
    
    public void InstantiateGameObjects(){
        System.Random random= new System.Random();
        int noteNum = random.Next(1,4);
        switch(noteNum){
            case 1:
                emp = Instantiate(note1, transform.position, transform.rotation);
                break;
            case 2:
                emp = Instantiate(note2, transform.position, transform.rotation);
                break;
            case 3:
                emp = Instantiate(note3, transform.position, transform.rotation);
                break;
        }
        
        emp.transform.Translate(new Vector3(0,0,-1));
        Debug.Log("Note created");
    }
}
