using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string nextSceneName;

    private void OnBecameInvisible()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}