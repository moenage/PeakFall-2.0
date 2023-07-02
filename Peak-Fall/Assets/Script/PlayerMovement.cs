using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool damage = false;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(4f, 20f);

    private bool isWallSliding;
    private float wallSlidingSpeed = 1.5f;


    bool jumping = false;
    bool controlSpeed = false;
    float timeRecord;

    [SerializeField] TrailRenderer trail;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private void Start()
    {
        trail.enabled = false;
    }



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        wallSlide();
        WallJump();

        //if (jumping && timeRecord < Time.time)
        //    StartCoroutine(addGravity());

        if (!isWallJumping)
            Flip();


        if (rb.velocity.y < -100 && trail.enabled == false)
            trail.enabled = true;
        else if (rb.velocity.y > -100 && trail.enabled == true)
            trail.enabled = false;


        if (!controlSpeed && rb.velocity.y < -120)
        {
            rb.gravityScale = 1;
            Physics2D.gravity = new Vector2(0, 0);
            rb.velocity = new Vector2(0, -125f);
            controlSpeed = true;
        }
        if (rb.velocity.y > -50)
        {
            rb.gravityScale = 4;
            Physics2D.gravity = new Vector2(0, -9.8f);
            controlSpeed = false;
        }

    }

        private void FixedUpdate()
        {
            if (!damage && !isWallJumping)
            {

                if (isWallSliding && ((isFacingRight && horizontal > 0) || (!isFacingRight && horizontal < 0)))
                {
                    return;
                }

                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }

        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private bool isWalled()
        {
            return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
        }

        private void wallSlide()
        {

            if (isWalled() && !IsGrounded() && horizontal != 0f)
            {
                isWallSliding = true;
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }
            else
                isWallSliding = false;
        }

        private void WallJump()
        {
            if (isWallSliding)
            {
                isWallJumping = false;
                wallJumpingDirection = -transform.localScale.x;
                wallJumpingCounter = wallJumpingTime;

                CancelInvoke(nameof(StopWallJumping));
            }
            else
            {
                wallJumpingCounter -= Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
            {
                isWallJumping = true;

            rb.AddForce(new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y), ForceMode2D.Impulse);
            //Physics2D.gravity = new Vector2(0, -30f);



            jumping = true;
            timeRecord = Time.time + 0.5f;

                wallJumpingCounter = 0f;

                if (transform.localScale.x != wallJumpingDirection)
                {
                    isFacingRight = !isFacingRight;
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }

                Invoke(nameof(StopWallJumping), wallJumpingDuration);
            }
        }

        private void StopWallJumping()
        {
            isWallJumping = false;
        }

        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        public void awayForce() {
            StartCoroutine(lessControll());
            rb.AddForce(new Vector2(-5f * transform.localScale.x, 4f), ForceMode2D.Impulse);
        }

        IEnumerator lessControll() {
            damage = true;
            yield return new WaitForSeconds(0.7f);
            damage = false;
        }

        IEnumerator addGravity()
        {
            jumping = false;
            Physics2D.gravity = new Vector2(0, -66f);
            yield return new WaitForSeconds(1f);
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
}
