using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneTransition : MonoBehaviour
{
    public string sceneName;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}