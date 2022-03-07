using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmDetection : MonoBehaviour
{
    public GameObject detectCollider;
    public GameObject boss;
    public GameObject jar;
    private BoxCollider2D bc; 
    private Rigidbody2D rb;
    private bool canSpawnJar;
    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        canSpawnJar = true;
    }

    private IEnumerator jarCooldown(){
        canSpawnJar = false;
        yield return new WaitForSeconds(5);
        canSpawnJar = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.gameObject.tag == "Player" && canSpawnJar)
        {
            Instantiate(jar, gameObject.transform.position - new Vector3(0, 3, 0), gameObject.transform.rotation );
            StartCoroutine(jarCooldown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
