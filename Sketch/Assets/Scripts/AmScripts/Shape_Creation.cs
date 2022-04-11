using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape_Creation : MonoBehaviour
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject Circle;
    public GameObject Arrow;
    public GameObject Crescent;
    public GameObject SpawnLocation;
    [HideInInspector] public bool canDrawShapeCreation = true;
    public float arrowSpeed;
    public float arrowLifeSpan;
    public float crescentSpeed;
    public float crescentLifeSpan;
    [HideInInspector] public Animator anim;
    [HideInInspector] public AudioSource AmAudio;
    
    public int crescentJump = 1;

    public AudioClip[] clips;
    private GameManager gm;
    private Am_Movement movement;

    public GameObject[] Shapes = new GameObject[5];
    private GameObject currShape;

    void Start()
    {
        currShape = Circle;
        Shapes[0] = GameObject.Find("Shape1");
        Shapes[1] = GameObject.Find("Shape2");
        Shapes[2] = GameObject.Find("Shape3");
        Shapes[3] = GameObject.Find("Shape4");
        Shapes[4] = GameObject.Find("Shape5");

        anim = gameObject.GetComponentInParent<Animator>();
        AmAudio = gameObject.GetComponentInParent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        movement = GetComponentInParent<Am_Movement>();

    }
    // Update is called once per frame

    void PlayRandomDraw(){
        AudioClip player = clips[Random.Range(0, clips.Length - 1)];
        AmAudio.clip = player;
        AmAudio.Play();
    }

    void Update()
    {
        if (gm.isPaused || movement.isFrozen) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            /*
            Shapes[0].GetComponent<Animator>().Play("Shape1Left");
            Shapes[1].GetComponent<Animator>().Play("Shape2Left");
            Shapes[2].GetComponent<Animator>().Play("Shape3Left");
            Shapes[3].GetComponent<Animator>().Play("Shape4Left");
            Shapes[4].GetComponent<Animator>().Play("Shape5Left");
            */

            shiftRight();
            

            //shiftLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            shiftLeft();
        }

        if (Input.GetKeyDown(KeyCode.F) && isClear() && canDrawShapeCreation)
        {
            if (currShape != Arrow && currShape != Crescent)
            {
                Instantiate(currShape, SpawnLocation.transform.position, transform.rotation);
                anim.Play("Am_Draw");
                this.PlayRandomDraw();
            }

            else if (currShape == Arrow)
            {
                GameObject createdArrow;
                createdArrow = Instantiate(Arrow, SpawnLocation.transform.position, transform.rotation);
                anim.Play("Am_Draw");
                this.PlayRandomDraw();
                if (transform.rotation.y == -1 || transform.rotation.y == 1)
                {
                    createdArrow.transform.rotation = Quaternion.Euler(0, 180, 0);
                    createdArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed, 0);
                }
                else
                {
                    createdArrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                    createdArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed, 0);
                }
                Destroy(createdArrow, arrowLifeSpan);
            }

            else if (currShape == Crescent && crescentJump > 0)
            {
                --crescentJump;
                GameObject createdCrescent;
                createdCrescent = Instantiate(Crescent, SpawnLocation.transform.position, transform.rotation);
                anim.Play("Am_Draw");
                this.PlayRandomDraw();
                if (transform.rotation.y == -1 || transform.rotation.y == 1)
                {
                    //createdCrescent.transform.rotation = Quaternion.Euler(0, 180, 90);
                    createdCrescent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, crescentSpeed);
                }
                else
                {
                    //createdCrescent.transform.rotation = Quaternion.Euler(0, 0, 90);
                    createdCrescent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, crescentSpeed);
                }
                Destroy(createdCrescent, crescentLifeSpan);
            }
        }
        //Debug.Log(collisionCount);
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Square, SpawnLocation.transform.position, transform.rotation);
            anim.Play("Am_Draw");
            this.PlayRandomDraw();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Triangle, SpawnLocation.transform.position, transform.rotation);
            anim.Play("Am_Draw");
            this.PlayRandomDraw();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isClear() && canDrawShapeCreation)
        {
            Instantiate(Circle, SpawnLocation.transform.position, transform.rotation);
            anim.Play("Am_Draw");
            this.PlayRandomDraw();
        }
        */
    }

    bool isClear()
    {
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.8f, 2.05f), 0);
        // foreach (Collider2D hit in hitObjects){
        //     Debug.Log(hit.name);
        // }
        if (hitObjects.Length == 0)
        {
            return true;
        }
        else return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.8f, 2.05f, 1));
    }

    private void shiftLeft()
    {
        

        
        Sprite temp = Shapes[0].GetComponent<Image>().sprite;
        Shapes[0].GetComponent<Image>().sprite = Shapes[1].GetComponent<Image>().sprite;
        Shapes[1].GetComponent<Image>().sprite = Shapes[2].GetComponent<Image>().sprite;
        Shapes[2].GetComponent<Image>().sprite = Shapes[3].GetComponent<Image>().sprite;
        Shapes[3].GetComponent<Image>().sprite = Shapes[4].GetComponent<Image>().sprite;
        Shapes[4].GetComponent<Image>().sprite = temp;
        updateCurrShape();
        
        

    }

    private void shiftRight()
    {
        /*
        for (int i = 0; i < 5; i++)
        {
            if (i == 4)
            {
                var currPos = Shapes[i].GetComponent<RectTransform>().position;
                var targetPos = Shapes[0].GetComponent<RectTransform>().position;
                Debug.Log(Shapes[i].GetComponent<RectTransform>().anchoredPosition);
                Shapes[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(75, 100);
                Shapes[i].GetComponent<RectTransform>().ForceUpdateRectTransforms();
                Debug.Log(Shapes[i].GetComponent<RectTransform>().anchoredPosition);
                
                //StartCoroutine(shapeRight(currPos, targetPos, Shapes[i].gameObject));
            }
            
            else
            {
                var currPos = Shapes[i].gameObject.GetComponent<RectTransform>().position;
                var targetPos = Shapes[i + 1].gameObject.GetComponent<RectTransform>().position;
                StartCoroutine(shapeRight(currPos, targetPos));
            }
            
            Debug.Log(i);
        }
        */

        Sprite temp = Shapes[4].GetComponent<Image>().sprite;
        Shapes[4].GetComponent<Image>().sprite = Shapes[3].GetComponent<Image>().sprite;
        Shapes[3].GetComponent<Image>().sprite = Shapes[2].GetComponent<Image>().sprite;
        Shapes[2].GetComponent<Image>().sprite = Shapes[1].GetComponent<Image>().sprite;
        Shapes[1].GetComponent<Image>().sprite = Shapes[0].GetComponent<Image>().sprite;
        Shapes[0].GetComponent<Image>().sprite = temp;
        updateCurrShape();
    }

    private void updateCurrShape()
    {
        string selected = Shapes[2].GetComponent<Image>().sprite.name;

        switch (selected)
        {
            case "SquareSprite":
                {
                    currShape = Square;
                    break;
                }
            case "TriangleSprite":
                {
                    currShape = Triangle;
                    break;
                }
            case "CircleSprite":
                {
                    currShape = Circle;
                    break;
                }
            case "Arrow":
                {
                    currShape = Arrow;
                    break;
                }
            case "Crescent":
                {
                    currShape = Crescent;
                    break;
                }
        }
    }

    /*
    IEnumerator shapeRight(Vector2 curr, Vector2 target, GameObject i)
    {
        while(curr != target)
        {
            Debug.Log(curr + " " + target);
            curr = Vector2.MoveTowards(curr, target, 3f * Time.deltaTime);
            i.GetComponent<RectTransform>().anchoredPosition = curr;
            Debug.Log("working");
            yield return null;
        }
    }
    */
}
