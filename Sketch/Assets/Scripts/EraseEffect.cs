using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseEffect : MonoBehaviour
{
    private static ParticleSystem particles;

    void Start(){
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    public static void PlayEraseEffect(Vector3 position){
        particles.transform.position = position;
        particles.Play();
    }
}
