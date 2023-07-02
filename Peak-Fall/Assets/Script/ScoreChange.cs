using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreChange : MonoBehaviour
{
    public float score = 0f; // The score value to be set in your game.

    private void LoadSceneBasedOnScore()
    {
        // Check the score and load the appropriate scene.
        if (score >= 90)
        {
            // A+, A, or A-
            SceneManager.LoadScene("SceneA");
        }
        else if (score >= 80)
        {
            // B+, B, or B-
            SceneManager.LoadScene("SceneB");
        }
        else if (score >= 70)
        {
            // C+, C, or C-
            SceneManager.LoadScene("SceneC");
        }
        else
        {
            // F or any other score
            SceneManager.LoadScene("SceneF");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log("COLLISIOOOOOOONNNNNNNNNNNNN" + collision.tag);
            score = -collision.attachedRigidbody.velocity.y;
            Debug.Log("SSCOREEEEEEEEEEEEE" + score);
            LoadSceneBasedOnScore();
        }
    }
}
