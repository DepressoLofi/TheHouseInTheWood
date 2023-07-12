using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] int lettersPerSecond;

    private DialogueS dialogue;
    private List<string> dialogueLines;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool isDialogueActive = false;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialogue(DialogueS dialogue)
    {
        if (!isDialogueActive)
        {
            this.dialogue = dialogue;
            dialogueLines = dialogue.Lines;
            currentLineIndex = 0;
            dialogueBox.SetActive(true);
            StartCoroutine(TypeDialogueS(dialogueLines[currentLineIndex]));
            isDialogueActive = true;
        }
        else
        {
            NextDialogueLine();
        }
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
        isDialogueActive = false;
    }

    public void NextDialogueLine()
    {
        if (isTyping)
        {
            StopCoroutine("TypeDialogueS");
            dialogueText.text = dialogueLines[currentLineIndex];
            isTyping = false;
        }
        else
        {
            currentLineIndex++;

            if (currentLineIndex < dialogueLines.Count)
            {
                StartCoroutine(TypeDialogueS(dialogueLines[currentLineIndex]));
            }
            else
            {
                HideDialogue();
            }
        }
    }

    private IEnumerator TypeDialogueS(string line)
    {
        dialogueText.text = string.Empty;
        isTyping = true;
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1F / lettersPerSecond);
        }
        isTyping = false;
    }
}
