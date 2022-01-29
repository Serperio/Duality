using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    PlayerMovement pm;
    private string lastTrigger = "None";
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        if(axis > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (Mathf.Abs(axis) >= 0.01f)
        {
            anim.SetBool("Running",true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        #region Jumping and Falling
        if (rb.velocity.y == 0)
        {
            if (lastTrigger != "Ground")
            {
                anim.SetTrigger("Ground");
                lastTrigger = "Ground";
            }
        }
        else if(rb.velocity.y < 0)
        {
            if (lastTrigger != "Fall")
            {
                anim.SetTrigger("Fall");
                lastTrigger = "Fall";
            }
        }
        else
        {
            if (lastTrigger != "Jump")
            {
                anim.SetTrigger("Jump");
                lastTrigger = "Jump";
            }
        }
        #endregion
    }
    public void ChangeToJumpUp()
    {
        anim.SetTrigger("JumpUp");
    }
  


}
