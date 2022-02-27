using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGeneration : MonoBehaviour
{
    //timer & indices
    private float timer;
    private int a;
    private int b;
    private int c;
    public Note note;
    public GameObject rocker;
    private Animator ani;
    //arrays...
    private List<float> intro1= new List<float>();
    private List<float> intro2= new List<float>();
    private List<float> a1= new List<float>();
    private List<float> a2= new List<float>();
    private List<float> a3= new List<float>();
    private List<float> b1= new List<float>();
    private List<float> b2= new List<float>();
    private List<List<float>> parts= new List<List<float>>();
    private List<int> introPart=new List<int>();
    private List<int> aPart = new List<int>();
    private List<int> aPart2= new List<int>();
    private List<int> bPart = new List<int>();
    private List<List<int>> simplifiedParts = new List<List<int>>();
    private List<int> song= new List<int>();
    
    void Start()
    {
        timer=0;
        a=0;
        b=0;
        c=0;
        ani = rocker.gameObject.GetComponent<Animator>();
        //intro1 definition
        intro1.Add(6f/3f);
        intro1.Add(1f/3f);
        intro1.Add(8f/3f);
        //intro2 definition
        intro2.Add(7f/3f);
        intro2.Add(1f/3f);
        intro2.Add(4f/3f);
        intro2.Add(2f/3f);
        intro2.Add(2.5f/3f);
        //a1 definition
        a1.Add(1f/3f);
        a1.Add(1f/3f);
        a1.Add(1f/6f);
        a1.Add(1f/3f);
        a1.Add(3f/2f);
        //a2 definition
        a2.Add(2f/3f);
        a2.Add(2f/3f);
        a2.Add(2f/3f);
        a2.Add(2f/3f);
        //a3 definition
        a3.Add(1f/3f);
        a3.Add(1f/3f);
        a3.Add(1f/3f);
        a3.Add(1f/6f);
        a3.Add(1f/3f);
        a3.Add(1f/6f);
        a3.Add(1f/3f);
        a3.Add(1f/3f);
        a3.Add(1f/3f);
        //b definition
        b1.Add(4f/3f);
        b1.Add(2f/3f);
        b1.Add(2f/3f);
        b1.Add(8f/3f);//may need to be less like 5/3
        //b2 definition
        b2.Add(8f/3f);
        
        //parts definition
        parts.Add(intro1);
        parts.Add(intro2);
        parts.Add(a1);
        parts.Add(a2);
        parts.Add(a3);
        parts.Add(b1);
        parts.Add(b2);

        //introPart definition
        introPart.Add(0);
        introPart.Add(1);
        //aPart definition
        aPart.Add(2);
        aPart.Add(2);
        aPart.Add(2);
        aPart.Add(3);
        //aPart2 definitin
        aPart2.Add(2);
        aPart2.Add(2);
        aPart2.Add(2);
        aPart2.Add(4);
        //bPart definition
        bPart.Add(5);
        bPart.Add(5);
        bPart.Add(5);
        bPart.Add(5);
        //bPart.Add(6);

        //simplifiedParts definition
        simplifiedParts.Add(introPart);
        simplifiedParts.Add(aPart);
        simplifiedParts.Add(aPart2);
        simplifiedParts.Add(bPart);
        
        //song definition
        song.Add(0); //introPart (intro1 & 2)
        song.Add(0);
        song.Add(0);
        song.Add(1); //aPart (a1 & a2)
        song.Add(2);
        song.Add(1);
        song.Add(2);
        song.Add(3); //bPart (b1 & b2)
        song.Add(0); //introPart (intro1 & 2)
        song.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        timer=timer + Time.deltaTime;
        //Debug.Log(timer);
        List<int> sp = simplifiedParts[song[c]];
        List<float> p=parts[sp[b]];
        
        
        if(timer>=p[a]){
            /*if(!rocker.isVulnerable()){
                PlayNote();
                PlayAnim();
            }*/
            if(ani!=null){
                note.InstantiateGameObjects();//plays the note
            
                ani.SetBool("isSinging",true);//animates Rocker
            }
            timer=0; 
            Debug.Log(c);
            a++;
            if(a>=p.Count){
                a=0;
                b++;
                if(b>=sp.Count){
                    b=0;
                    c++;
                }
                if(c>=song.Count){
                    a=0;
                    b=1;
                    c=1;// if song is over, this is where we start.
                }
            }
            //ani.SetBool("isSinging",false);
            
        }
               
    }
}
