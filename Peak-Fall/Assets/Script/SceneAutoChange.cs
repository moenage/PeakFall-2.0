using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoChange : MonoBehaviour
{
    public string nextSceneName;
    public float delayTime = 3f;

    void Start()
    {
        Invoke("LoadNextScene", delayTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}