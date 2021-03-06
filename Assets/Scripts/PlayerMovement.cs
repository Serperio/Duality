using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float moveInput;
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    [SerializeField] private float velPower;

    [SerializeField] private float frictionAmount;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCutMultiplier;
    [SerializeField] private float jumpCoyoteTime;
    [SerializeField] private float jumpBufferTime;

    [SerializeField] private float fallGravityMultiplier;

    [SerializeField] private bool isJumping;
    [SerializeField] private bool jumpInputReleased;

    [SerializeField] private float lastGroundedTime;
    [SerializeField] private float lastJumpTime;

    [Header("Checks")]
    [SerializeField] private bool grounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private PlayerLadderMovement plm;
    private Rigidbody2D rb;

    [Header("Reset")]
    [SerializeField] private float maxTime;
    [SerializeField] private float timeToReset;

    
    public bool Grounded { get => grounded; set => grounded = value; }

    void Start()
    {
        timeToReset = 0;
        maxTime = 3;
        rb = GetComponent<Rigidbody2D>();
        plm = GetComponent<PlayerLadderMovement>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            timeToReset += Time.deltaTime;

        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y <= 0)
        {
            OnJump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            OnJumpUp();
        }
        
    }


    private void FixedUpdate()
    {
        #region Movement
        if (!plm.IsClimbing)
        {
            float targetSpeed = moveInput * moveSpeed;
            float speedDif = targetSpeed - rb.velocity.x;

            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

            rb.AddForce(movement * Vector2.right);
        }
        #endregion

        #region Friction
        if(lastGroundedTime > 0 && Mathf.Abs(moveInput) < 0.01f)
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
        #endregion

        #region Grounded
        if (Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer))
        {
            Grounded = true;
            isJumping = false;
            if(rb.velocity.y < 0)plm.IsClimbing = false;
            lastGroundedTime = jumpCoyoteTime;
        }
        else { Grounded = false; }


        #endregion


        #region Jump
        if (lastGroundedTime > 0 && lastJumpTime > 0 && !isJumping && !plm.IsLadder)
        {
            Jump();
        }
        #region Timer
        lastGroundedTime -= Time.deltaTime;
        lastJumpTime -= Time.deltaTime;
        #endregion

        #endregion

        #region Jump Gravity
        if (!plm.IsLadder)
        {
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = 1.1f * fallGravityMultiplier;
            }
            else
            {
                rb.gravityScale = 1.1f;
            }
        }

        #endregion

        #region Falling
        if(transform.position.y <= -30)
        {
            LevelManager.instance.ResetLevel();
        }
        #endregion

        #region Reset
        if(timeToReset >= maxTime)
        {
            timeToReset = 0;
            LevelManager.instance.ResetLevel();
        }
        #endregion


    }
    private void Jump()
    {
        if (AudioManager.Instance.gameObject != null)
        {
            print("audio");
            AudioManager.Instance.Play(2);
        }
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        lastGroundedTime = 0;
        lastJumpTime = 0;
        isJumping = true;
        jumpInputReleased = false;
    }
    private void OnJump()
    {
        print("works?");
        lastJumpTime = jumpBufferTime;
    }

    private void OnJumpUp()
    {
        print("release");
        if (rb.velocity.y > 0 && isJumping)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }
        jumpInputReleased = true;
        lastJumpTime = 0;
    }
}

