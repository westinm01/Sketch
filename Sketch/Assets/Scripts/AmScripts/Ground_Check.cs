using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            this.gameObject.GetComponentInParent<Am_Movement>().canJump = true;
            this.gameObject.GetComponentInParent<Am_Movement>().anim.SetBool("IsJumping", false);
        }
    }
}
