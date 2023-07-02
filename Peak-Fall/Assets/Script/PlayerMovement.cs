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
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    private bool isWallSliding;
    private float wallSlidingSpeed = 1.5f;

    private bool jumpPressed = false;
    private bool jumpHeld = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;



    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");

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

        if (!isWallJumping)
            Flip();
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
                rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
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
}
