using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 16f;
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJumpSound();
        }

        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private bool IsGrounded()
    {
        // Implement your ground detection logic here
        // For example, you can use raycasting or collision detection
        // Return true if the player is grounded, false otherwise
        return false;
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}