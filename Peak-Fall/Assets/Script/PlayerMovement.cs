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
    [SerializeField] private float jumpForce = 5.3f;
    [SerializeField] private float jumpHeldForce = 1.8f;
    [SerializeField] private float jumpHeldDuration = 0.1f;

    float jumpTime;

    [Header("state")]
    [SerializeField] private bool onGround;
    [SerializeField] private bool isJump;
    [SerializeField] private bool damage;

    //jump Varaible
   [SerializeField] bool jumpPressed;
    [SerializeField]bool jumpHeld;

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
        jumpHeld = Input.GetButton("Jump");
        
    }

    public void help() {
        Debug.Log(";;");
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
        if (jumpHeld && onGround && !isJump)
        {
            onGround = false;
            isJump = true;
            jumpTime = Time.time + jumpHeldDuration;

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


        else if (isJump)
        {
            if (jumpHeld)
                rb.AddForce(new Vector2(0, jumpHeldForce), ForceMode2D.Impulse);
            if (jumpTime < Time.time)
                isJump = false;
        }

    }

    void GroundMovement()
    {
        if (!damage)
        {
            xVelocity = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        }
            
        filpDirection();

    }

    void filpDirection()
    {
        if (xVelocity < 0)
            transform.localScale = new Vector2(-1, 1);
        else if (xVelocity > 0)
            transform.localScale = new Vector2(1, 1);
    }

    public void awayForce()
    {
        StartCoroutine(lessControll());
        rb.AddForce(new Vector2(-5f * transform.localScale.x, 4f), ForceMode2D.Impulse);
    }

    IEnumerator lessControll()
    {
        damage = true;
        yield return new WaitForSeconds(0.7f);
        damage = false;
    }
}
