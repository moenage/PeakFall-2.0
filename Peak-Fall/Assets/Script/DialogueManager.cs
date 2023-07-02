using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float typingSpeed = 0.1f;
    public string dialogueText;
    
    private Text dialogueTextComponent;
    private bool isTyping = false;

    void Start()
    {
        dialogueTextComponent = GetComponent<Text>();
        dialogueTextComponent.text = "";
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        isTyping = true;
        foreach (char letter in dialogueText)
        {
            dialogueTextComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void Update()
    {
        if (isTyping)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(ShowDialogue());
                dialogueTextComponent.text = dialogueText;
                isTyping = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 点击后，将对话框隐藏或销毁
                Destroy(gameObject);
            }
        }
    }
}