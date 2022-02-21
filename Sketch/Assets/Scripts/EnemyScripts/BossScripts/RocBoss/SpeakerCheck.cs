using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    bool isVulnerable;
    void Start()
    {
        isVulnerable=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Speaker"){//might change
            isVulnerable= false;
        }
        else{
            isVulnerable=true;
        }
        Debug.Log(isVulnerable);
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag=="Speaker"){//might change
            isVulnerable=true;
        }
        else{
            isVulnerable= false;
        }
        Debug.Log(isVulnerable);
    }
}
