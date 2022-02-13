using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCage : MonoBehaviour
{
    public GameObject cage;
    public Rigidbody2D down;
    public float minY;
    private GameObject spawnCage;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        down = GetComponent<Rigidbody2D>();
    }
    public void StartFight()
    {
        spawnCage = Instantiate(cage, new Vector2(-2, 29), Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            anim.Play("WebCage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( minY <= spawnCage.transform.position.y )
        {
            down.velocity = new Vector2(0, -2f);
        }
    }
}
