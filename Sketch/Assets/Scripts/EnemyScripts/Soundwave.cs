using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundwave : Projectile
{
    [SerializeField] private GameObject Wave1;
    [SerializeField] private GameObject Wave2;
    [SerializeField] private GameObject Wave3;
    [SerializeField] private GameObject Wave4;
    private Animator anim;
    public float timeBetweenWaves;

    public IEnumerator StartSoundwave(){
        anim.Play("SoundwaveEnter");
        Wave1.SetActive(true);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave2.SetActive(true);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave3.SetActive(true);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave4.SetActive(true);
    }

    public IEnumerator EndSoundwave(){
        anim.Play("SoundwaveExit");
        Wave4.SetActive(false);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave3.SetActive(false);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave2.SetActive(false);
        yield return new WaitForSeconds(timeBetweenWaves);
        Wave1.SetActive(false);
    }

    public override void Bounce()
    {
        Wave1.SetActive(false);
        Wave2.SetActive(false);
        Wave3.SetActive(false);
        Wave4.SetActive(false);
        // if (direction.x < 0){
        //     gameObject.transform.position += new Vector3(0.5f, 0);
        // }
        // else{
        //     gameObject.transform.position -= new Vector3(0.5f, 0);
        // }
        base.Bounce();
        anim.Play("SoundwaveExit");
        StartCoroutine(StartSoundwave());
    }

    protected new void Start(){
        base.Start();
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(StartSoundwave());
    }
}
