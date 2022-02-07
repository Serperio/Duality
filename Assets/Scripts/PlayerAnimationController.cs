using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    PlayerMovement pm;
    [SerializeField] private PlayerLadderMovement plm;
    [SerializeField] private LayerMask boxLayer;
    private string lastTrigger = "None";
    private int dir;

    [Header("Animator")]
    [SerializeField] private RuntimeAnimatorController purple;
    [SerializeField] private RuntimeAnimatorController red;
    [SerializeField] private RuntimeAnimatorController blue;
    [SerializeField] private RuntimeAnimatorController gray;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        plm = GetComponent<PlayerLadderMovement>();
    }
    private void Update()
    {
        anim.speed = 1;
        float axis = Input.GetAxis("Horizontal");
        if(axis > 0)
        {
            sr.flipX = true;
            dir = 1;
        }
        if (axis < 0)
        {
            sr.flipX = false;
            dir = -1;
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
        if (plm.IsClimbing)
        {


            if (lastTrigger != "Ladder")
            {
                anim.SetTrigger("Ladder");
                lastTrigger = "Ladder";
            }
            if (rb.velocity.y == 0)
            {
                anim.speed = 0;
            }
            else if (rb.velocity.y < 0)
            {
                anim.speed = -1;
            }
            else
            {
                anim.speed = 1;
            }

        }
        else
        {

            if (Mathf.Abs(rb.velocity.y) <= 0.1f)
            {
                if (lastTrigger != "Ground")
                {
                    anim.SetTrigger("Ground");
                    lastTrigger = "Ground";
                }
            }
            else
            {
                if (rb.velocity.y < 0)
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
            }
            
        }
        
        
        #endregion
    }

    private void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*dir, 10, boxLayer, 0);

        //if(hit.collider != null)
        //{
        //    print(hit.collider.gameObject.name);
        //}
        //Debug.DrawRay(transform.position, Vector2.right * dir*5, Color.red);

    }
    public void ChangeToJumpUp()
    {
        anim.SetTrigger("JumpUp");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            print(collision.gameObject.transform.position.y);
            if (anim.GetBool("Running"))
            {
                print("2do print");
                anim.SetTrigger("Push");
            }
        }
    }

    public void ToPurple()
    {
        anim.runtimeAnimatorController = purple;
    }

    public void ToRed()
    {
        anim.runtimeAnimatorController = red;
    }

    public void ToBlue()
    {
        anim.runtimeAnimatorController = blue;
    }

    public void ToGray()
    {
        anim.runtimeAnimatorController = gray;
    }

}
