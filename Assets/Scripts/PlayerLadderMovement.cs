using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 15f;
    private Transform ladder;
    [SerializeField]private bool isLadder;
    [SerializeField]private bool isClimbing;

    private Rigidbody2D rb;

    public bool IsLadder { get => isLadder; set => isLadder = value; }
    public bool IsClimbing { get => isClimbing; set => isClimbing = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(IsLadder && Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(ladder.transform.position.x, transform.position.y, transform.position.z);
            IsClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            float amount = Mathf.Abs(rb.velocity.x);
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);


            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            //print("climbing");
        }
        else
        {
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Ladder"))
        {
            ladder = collision.transform;
            print("ladder");
            IsLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            
            IsLadder = false;
            IsClimbing = false;
        }
    }
}
