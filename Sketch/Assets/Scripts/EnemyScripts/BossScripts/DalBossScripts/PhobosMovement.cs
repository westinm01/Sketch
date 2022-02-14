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
    public bool isDead;
    public int currPhase = 1;
    public GameObject idleColliders;
    public GameObject dashColliders;
    public GameObject climbColliders;
    public GameObject hurtColliders;
    public Vector3 inactivePosition;
    public BossCombat combat;
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

    public void EndPhase(){
        isActive = false;
    }

    void EnableHurtCollider(){
        hurtColliders.SetActive(true);
    }

    public void BecomeVulnerable(){
        isClimbing = false;
        climbTimer = 0;
        attackTimer = 0;
        hurtTimer = 0;
        climbColliders.SetActive(false);
        // hurtColliders.SetActive(true);
        Invoke("EnableHurtCollider", 0.25f);
        rb.gravityScale = 1;
        rb.velocity = Vector2.zero;
        anim.Play("PhobosFall");
        isHurt = true;
        // SpawnInScene();
    }

    public void UpdatePhase(){
            if (combat == null){
                Debug.Log("Boss is deadadeadaed");
                isDead = true;
                spawner.ClearWebs();
            }
            else if (combat.health == 10 && currPhase == 1){
                currPhase = 2;
                attackTime -= 1;
            }
            else if (combat.health == 5 && currPhase == 2){
                currPhase = 3;
                spawner.websSpawned += 1;
                attackTime -= 2;
                dashSpeed += 5;
            }
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
        if (isActive && !isDead){
            UpdatePhase();
            if (!spawnedWebs && !isDashing){  // If webs haven't been spawned in yet
                attackTimer = 0;
                climbTimer = 0;
                spawnTimer = 0;
                spawner.SpawnWebs();
                spawnedWebs = true;
                websCleared = false;
            }

            if (hurtTimer < hurtTime){      // Is hurt
                hurtTimer += Time.deltaTime;
                return;
            }
            if (isHurt && hurtTimer >= hurtTime){
                Debug.Log("Hurt time expired");
                hurtColliders.SetActive(false);
                spawner.ClearWebs();
                spawnedWebs = false;
                climbTimer = 0;
                attackTimer = 0;
                isHurt = false;
                MoveOutOfScene();
            }

            if (!websCleared){  // Update active list of webs if they haven't been cleared yet
                UpdateWebs();
            }
            else if (!isDashing && !isHurt){
                climbTimer = 0;     // If webs are cleared, don't climb down
                SpawnInScene();
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
                    climbTimer = 0;
                    attackTimer = 0;
                    MoveOutOfScene();   // Don't attack
                    EndPhase();
                    return;
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
            else if (!isHurt){
                attackTimer += Time.deltaTime;
            }

            if (gameObject.transform.position.x <= -20 && isDashing){    // If reached end of dash
                Debug.Log("End of dash reached");
                dashColliders.SetActive(false);
                // gameObject.transform.position = new Vector3(2, 21.5f);
                isDashing = false;
                MoveOutOfScene();
                EndPhase();
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
}
