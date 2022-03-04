using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCage : MonoBehaviour
{
    // public GameObject cage;
    public float minY;
    // private GameObject spawnCage;
    private Rigidbody2D down;
    private Animator anim;
    public BoxCollider2D openCollider;
    public GameObject closedCollider;
    public GameObject getInText;
    public GameObject topPart;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        down = GetComponent<Rigidbody2D>();
    }
    // public void StartFight()
    // {
    //     spawnCage = Instantiate(cage, new Vector2(-2, 29), Quaternion.identity);
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            anim.Play("WebCage");
            closedCollider.SetActive(true);
            openCollider.enabled = false;
            getInText.SetActive(false);
            topPart.GetComponent<Animator>().Play("TopOpen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( minY <= gameObject.transform.position.y )
        {
            down.velocity = new Vector2(0, -2f);
        }
        else{
            down.velocity = Vector2.zero;
        }
    }
}
