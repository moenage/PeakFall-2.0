using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSceneTransition : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("once");
        SceneManager.LoadScene(sceneName);
    }
}