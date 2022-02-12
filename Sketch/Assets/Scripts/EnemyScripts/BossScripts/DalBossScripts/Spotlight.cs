using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public GameObject objectToFollow;

    void Update(){
        gameObject.transform.position = objectToFollow.transform.position;
    }
}
