using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [Header("Movement Parameter")]
    [SerializeField] private float speed = 8f;
    

    [Header("jump Parameter")]
    [SerializeField] private float jumpForce = 6.3f;
    [SerializeField] private float jumpHoldForce = 1.9f;
    [SerializeField] private float jumpHoldDuration = 0.1f;

    float jumpTime;

    [Header("state")]
    [SerializeField] private bool onGround;
    [SerializeField] private bool isJump;

    //jump Varaible
    bool jumpPressed;
    bool jumpHold;

    [Header("enviroment check")]
    public LayerMask groundLayer;

    float xVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHold = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
        GroundMovement();
        Jump();
    }

    void PhysicsCheck()
    {
        if (coll.IsTouchingLayers(groundLayer))
            onGround = true;
        else
            onGround = false;
    }

    void Jump()
    {
        if (jumpPressed && onGround && !isJump)
        {
            onGround = false;
            isJump = true;

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void GroundMovement()
    {
        xVelocity = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        filpDirection();
    }

    void filpDirection()
    {
        if (xVelocity < 0)
            transform.localScale = new Vector2(-1, 1);
        else if (xVelocity > 0)
            transform.localScale = new Vector2(1, 1);
    }
}
