using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    Image img;
    int i = 0;
    bool on = false;
    int state = 0; // 0, 1, 2
    int r, g, b = 0;
    int rup, gup, bup;

    int holdDown = 0;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(on) {
            if(++i%17 == 0) img.color = getColor();
        }
        
        if(Input.GetKey(KeyCode.W)) {
            holdDown++;
        } else {
            holdDown = 0;
        }

        if(holdDown >= 1500) {
            on = !on;
            if(on == false) {
                img.color = new Color32(255,255,255,0);
            }
            holdDown = 0;
        }
        
    }

    byte ran() {
        return (byte)Random.Range(0, 255);
    }

    Color32 getColor() {
        if(state == 0) {
            r = ran();
            g = ran();
            b = ran();
            rup = (r < 150) ? 1 : -1;
            gup = (g < 150) ? 1 : -1;
            bup = (b < 150) ? 1 : -1;
        } else {
            r += (rup * 5);
            g += (gup * 17);
            b += (bup * 17);
        }
        state++;
        if(state == 3) state = 0;
        return new Color32((byte)r,(byte)g,(byte)b,150);
    }
}
