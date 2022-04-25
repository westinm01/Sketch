using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronolithMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D bodyHitbox;
    private CircleCollider2D clockHitbox;
    public float speed;
    public float timeActive;    // How long it takes before the boss gets frozen
    public float freezeTime;    // How long the boss is frozen for
    public float rightSide;
    public float leftSide;
    public GameObject clock;
    public Color frozenClockColor;
    private bool isFrozen = false;
    private float activeTimer = 0;
    private Vector2 tempVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        bodyHitbox = gameObject.GetComponentInChildren<BoxCollider2D>();
        clockHitbox = gameObject.GetComponent<CircleCollider2D>();
        rb.velocity = new Vector2 (speed, 0);
    }

    private void move()
    {
        // float rightSide = 11;
        // float leftSide = -11;
        if ( gameObject.transform.position.x > rightSide && rb.velocity.x > 0 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        }
        else if ( gameObject.transform.position.x < leftSide && rb.velocity.x < 0 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private IEnumerator freezeBoss(){
        isFrozen = true;
        tempVelocity = rb.velocity;
        rb.velocity = Vector2.zero;
        bodyHitbox.enabled = false;
        clockHitbox.enabled = true;
        anim.enabled = false;
        clock.GetComponent<Animator>().enabled = false;
        // float alpha = gameObject.GetComponent<SpriteRenderer>().color.a;
        // frozenClockColor.a = alpha + 0.1f;
        clock.GetComponent<SpriteRenderer>().color = frozenClockColor;

        yield return new WaitForSeconds(freezeTime);
        if (isFrozen){
            UnfreezeBoss();
        }
    }

    private void EnableHitbox(){
        bodyHitbox.enabled = true;
    }

    public void UnfreezeBoss(){
        isFrozen = false;
        rb.velocity = tempVelocity;
        // bodyHitbox.enabled = true;
        Invoke("EnableHitbox", 1.5f);      // Enable hitbox after a delay to prevent play getting hit instantly
        clockHitbox.enabled = false;
        anim.enabled = true;
        clock.GetComponent<Animator>().enabled = true;
        // float alpha = gameObject.GetComponent<SpriteRenderer>().color.a;
        clock.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        activeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer <= timeActive && !isFrozen){
            move();
            activeTimer += Time.deltaTime;
        }
        else if (!isFrozen){
            StartCoroutine(freezeBoss());
        }
        //Debug.Log(gameObject.transform.position.x);
    }
}
