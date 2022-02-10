using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosMovement : MonoBehaviour
{
    public float dashSpeed;     // How fast Phobos charges at player
    public float climbSpeed;    // How fast Phobos climbs up and down webs
    public float attackTime;    // How long am has to delete all the webs before attacking
    public float climbFrequency; // How often Phobos will climb on webs
    public float hurtTime;       // How long Phobos stays hurt for
    public float spawnDelay;     // How long it takes for Phobos to spawn after clearing webs
    public bool isActive;
    public GameObject idleColliders;
    public GameObject dashColliders;
    public GameObject climbColliders;
    public GameObject hurtColliders;
    public Vector3 inactivePosition;
    private float topOfWeb = 28;
    private float attackTimer;
    private float climbTimer;
    private float hurtTimer;
    private float spawnTimer;
    public bool isDashing = false;
    public bool isClimbing = false;
    public bool isHurt = false;
    private bool spawnedWebs = false;
    private bool websCleared = false;
    private Animator anim;
    private Rigidbody2D rb;
    private WebSpawner spawner;
    private GameObject am;
    private GameObject currWeb;
    private List<GameObject> activeWebs;
    public void Dash(){
        climbColliders.SetActive(false);
        idleColliders.SetActive(false);
        dashColliders.SetActive(true);
        rb.gravityScale = 0;
        gameObject.transform.position = new Vector3(15, 21.3f);
        anim.Play("PhobosWalk");
        rb.velocity = new Vector2(-dashSpeed, 0);
        isDashing = true;
    }

    public void ClimbDown(){
        if (currWeb != null){
            // Vector2 posDiff = am.transform.position - gameObject.transform.position;
            // if (posDiff.x < 0){     // Face towards am
            //     gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            // }
            // else{
            //     gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            // }

            anim.Play("PhobosNoStringClimb");
            climbColliders.SetActive(true);
            idleColliders.SetActive(false);
            gameObject.transform.position = new Vector3(currWeb.gameObject.transform.position.x, topOfWeb);   // Spawns phobos at top of web
            rb.gravityScale = 0;
            isClimbing = true;
            rb.velocity = new Vector3(0, -climbSpeed);
        }
    }

    public void ClimbUp(){
        rb.velocity = new Vector3(0, climbSpeed);
    }
    public void UpdateWebs(){
        activeWebs = new List<GameObject>();
        foreach (GameObject gm in spawner.spawnedWebs){
            if (gm != null){
                activeWebs.Add(gm);
            }
        }
        if (activeWebs.Capacity == 0){
            websCleared = true;
        }
    }
    public void SelectRandomWeb(){
        currWeb = null;
        if (activeWebs.Capacity > 0){                                   // If a spawned web exists
            currWeb = activeWebs[Random.Range(0, activeWebs.Capacity)]; // Select a web at random
        }
    }

    public void SpawnInScene(){
        rb.velocity = Vector2.zero;
        gameObject.transform.position = new Vector3(2, 21.5f);
    }

    public void MoveOutOfScene(){
        anim.Play("phobosIdle");
        idleColliders.SetActive(true);
        rb.gravityScale = 1;
        rb.velocity = Vector2.zero;
        gameObject.transform.position = inactivePosition;
    }

    public void BecomeVulnerable(){
        isClimbing = false;
        climbTimer = 0;
        attackTimer = 0;
        climbColliders.SetActive(false);
        hurtColliders.SetActive(true);
        rb.gravityScale = 1;
        anim.Play("PhobosHurt");
        isHurt = true;
        // SpawnInScene();
    }

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spawner = gameObject.GetComponent<WebSpawner>();
        am = GameObject.FindGameObjectWithTag("Player");
        attackTimer = attackTime;
        hurtTimer = hurtTime;
    }

    void Update(){
        if (isActive){
            if (!spawnedWebs && !isDashing){  // If webs haven't been spawned in yet
                attackTimer = 0;
                climbTimer = 0;
                spawnTimer = 0;
                spawner.SpawnWebs();
                spawnedWebs = true;
                websCleared = false;
            }

            if (hurtTimer < hurtTime){
                hurtTimer += Time.deltaTime;
                if (hurtTimer >= hurtTime){
                    hurtColliders.SetActive(false);
                    spawner.ClearWebs();
                    spawnedWebs = false;
                    climbTimer = 0;
                    attackTimer = 0;
                    MoveOutOfScene();
                    isHurt = false;
                }
                else{
                    return;     // If hurt, don't do anything else
                }
            }

            if (!websCleared){  // Update active list of webs if they haven't been cleared yet
                UpdateWebs();
            }
            else if (!isDashing && !isHurt){
                climbTimer = 0;     // If webs are cleared, don't climb down
                if (spawnTimer >= spawnDelay){
                    SpawnInScene();
                }
                else{
                    spawnTimer += Time.deltaTime;
                }
            }

            if (climbTimer >= climbFrequency && attackTime - attackTimer > 2){ // Make sure phobos has enough time to climb down before attacking
                Debug.Log("Climbing down");
                SelectRandomWeb();
                ClimbDown();
                climbTimer = 0;
            }
            else if (!isDashing){
                climbTimer += Time.deltaTime;
            }

            if (attackTimer >= attackTime){
                if (websCleared){       // If webs are cleared before attacking
                    spawnedWebs = false;
                    MoveOutOfScene();   // Don't attack
                }
                else{
                    climbTimer = 0;     // Make sure climb doesn't interrupt dash
                    Debug.Log("Attacking");
                    Dash();
                    spawner.ClearWebs();
                    spawnedWebs = false;
                }
                attackTimer = 0;
            }
            else{
                attackTimer += Time.deltaTime;
            }
        }


        if (gameObject.transform.position.x <= -20 && isDashing){    // If reached end of dash
            Debug.Log("End of dash reached");
            dashColliders.SetActive(false);
            // gameObject.transform.position = new Vector3(2, 21.5f);
            isDashing = false;
            MoveOutOfScene();
        }
        if (currWeb == null && isClimbing){
            climbColliders.SetActive(false);
            BecomeVulnerable();
        }
        if (currWeb != null && gameObject.transform.position.y <= currWeb.transform.GetChild(0).transform.position.y && isClimbing && rb.velocity.y < 0){  // If climbing down and end of string is reached
            Debug.Log("Bottom of web reached");
            ClimbUp();
        }
        if (isClimbing && gameObject.transform.position.y >= topOfWeb && rb.velocity.y > 0){   // If climbing up and reached top of web
            Debug.Log("Top of web reached");
            climbColliders.SetActive(false);
            currWeb = null;
            isClimbing = false;
            MoveOutOfScene();
        }
    }
}
