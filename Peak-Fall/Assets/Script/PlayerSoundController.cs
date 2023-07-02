using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip collisionSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play the collision sound
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Play the collision sound
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    public void PlayJumpSound()
    {
        // Play the jump sound
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}