using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Am_Movement movement;
    public Shape_Creation shapeCreation;
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log("Ground check collision");
        if (collision.gameObject.layer == 3 && movement.rb.velocity.y <= 0)
        {
            // this.gameObject.GetComponentInParent<Am_Movement>().canJump = true;
            // this.gameObject.GetComponentInParent<Am_Movement>().anim.SetBool("IsJumping", false);
            movement.canJump = true;
            movement.anim.SetBool("IsJumping", false);

            if (collision.name != "CrescentObject(Clone)")
            {
                shapeCreation.crescentJump = 1;
            }
        }
    }
}
