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
    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.gameObject.tag == "Player" )
        {
            Instantiate(jar, gameObject.transform.position - new Vector3(0, 2, 0), gameObject.transform.rotation );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
