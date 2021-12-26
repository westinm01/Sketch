using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Am_Movement movement;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && movement.rb.velocity.y <= 0)
        {
            // this.gameObject.GetComponentInParent<Am_Movement>().canJump = true;
            // this.gameObject.GetComponentInParent<Am_Movement>().anim.SetBool("IsJumping", false);
            movement.canJump = true;
            movement.anim.SetBool("IsJumping", false);
        }
    }
}
