using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreChange : MonoBehaviour
{
    public int score = 0; // The score value to be set in your game.

    private void Start()
    {
        // You can set the score here or get it from another script or source.
        // For example, you might have a script that updates the score value based on player performance.
        // For simplicity, I'll just set it to 100 for demonstration purposes.
        score = 100;

        // Call the function to load the scene based on the score.
        LoadSceneBasedOnScore();
    }

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
}
