using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosMovement : MonoBehaviour
{
    public float dashSpeed;
    public float climbSpeed;
    public GameObject idleColliders;
    public GameObject dashColliders;
    public GameObject climbColliders;
    public Vector3 inactivePosition;
    private float topOfWeb = 28;
    private bool isIdle = true;
    private Animator anim;
    private Rigidbody2D rb;
    private WebSpawner spawner;
    private GameObject am;
    private GameObject currWeb;
    public void Dash(){
        idleColliders.SetActive(false);
        dashColliders.SetActive(true);
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(15, 21.5f);
        anim.Play("PhobosWalk");
        rb.velocity = new Vector2(-dashSpeed, 0);
    }

    public void ClimbDown(){
        Debug.Log("climbing down: " + currWeb);
        if (currWeb != null){
            Vector2 posDiff = am.transform.position - gameObject.transform.position;
            if (posDiff.x < 0){     // Face towards am
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else{
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            anim.Play("PhobosNoStringClimb");
            climbColliders.SetActive(true);
            idleColliders.SetActive(false);
            gameObject.transform.position = new Vector3(currWeb.gameObject.transform.position.x, topOfWeb);   // Spawns phobos at top of web
            rb.gravityScale = 0;
            rb.velocity = new Vector3(0, -climbSpeed);
        }
    }

    public void ClimbUp(){
        rb.velocity = new Vector3(0, climbSpeed);
    }
    public void SelectRandomWeb(){
        currWeb = null;
        List<GameObject> webs = new List<GameObject>();     // List of active webs
        foreach (GameObject gm in spawner.spawnedWebs){
            if (gm != null){
                webs.Add(gm);
            }
        }
        if (webs.Capacity > 0){                             // If a spawned web exists
            currWeb = webs[Random.Range(0, webs.Capacity)]; // Select a web at random
        }
    }

    public void ResetToIdle(GameObject currCollider){
        anim.Play("phobosIdle");
        currCollider.SetActive(false);
        idleColliders.SetActive(true);
        rb.gravityScale = 1;
        rb.velocity = Vector2.zero;
        gameObject.transform.position = inactivePosition;
        isIdle = true;
    }

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spawner = gameObject.GetComponent<WebSpawner>();
        am = GameObject.FindGameObjectWithTag("Player");
        // Dash();
        // spawner.SpawnWebs();
        // SelectRandomWeb();
        // ClimbDown();
    }

    void Update(){
        if (isIdle){
            // Dash();
            // Debug.Log("Wtf");
            // SelectRandomWeb();
            // ClimbDown();
        }
        if (gameObject.transform.position.x <= -20){    // If reached end of dash
            gameObject.transform.position = new Vector3(2, 21.5f);
            ResetToIdle(dashColliders);
        }
        if (currWeb != null && gameObject.transform.position.y <= currWeb.transform.GetChild(0).transform.position.y){  // If climbing down and end of string is reached
            ClimbUp();    
        }
        if (gameObject.transform.position.y >= topOfWeb){   // If climbing up and reached top of web
            ResetToIdle(climbColliders);
        }
    }
}
