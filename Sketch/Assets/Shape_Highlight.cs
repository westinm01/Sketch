using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Highlight : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool canDrawShapeErase = false;
    List<SpriteRenderer> current = new List<SpriteRenderer>();
    List<SpriteRenderer> previous = new List<SpriteRenderer>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canDrawShapeErase) {
            previous.Clear();
            current.Clear();
            return;
        }
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.parent.position, new Vector2(4, 4), 0);
        foreach(Collider2D hitEnemy in hitEnemies)
            {
                if(hitEnemy.gameObject.tag == "Enemy")
                {
                    if(hitEnemy == null) continue;
                    SpriteRenderer sr = hitEnemy.GetComponent<SpriteRenderer>();
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);
                    current.Add(sr);
                    return;
                }
            }

        foreach(SpriteRenderer s in previous) {
            if(s == null) continue;
            if(current.IndexOf(s) == -1) {
                s.color = new Color(s.color.r, s.color.g, s.color.b, 1f);
            }
        }
        
        previous.Clear();
        foreach(SpriteRenderer s in current) {
            if(s == null) continue;
            previous.Add(s);
        }
        current.Clear();
    }
}
