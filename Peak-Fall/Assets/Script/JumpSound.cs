using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioClip jumpSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayJumpSound();
        }
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}