using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;

    public void OnMouseDown()
    {
        Debug.Log("i");
        SceneManager.LoadScene(sceneName);
    }
}