using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnClick : MonoBehaviour
{
    public Text textToDisplay;

    void Start()
    {
        textToDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            textToDisplay.gameObject.SetActive(true);
        }
    }
}