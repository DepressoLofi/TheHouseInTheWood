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
    private int currentLineIndex = 0;
    private bool isTyping = false;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialogue(DialogueS dialogue)
    {
        this.dialogue = dialogue;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogueS(dialogue.Lines[0]));
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }

    public void NextDialogueLine()
    {
        if (isTyping)
        {
            // If the text is still typing, finish typing instantly
            StopCoroutine("TypeDialogueS");
            dialogueText.text = dialogue.Lines[currentLineIndex];
            isTyping = false;
        }
        else
        {
            currentLineIndex++;

            if (currentLineIndex < dialogue.Lines.Count)
            {
                StartCoroutine(TypeDialogueS(dialogue.Lines[currentLineIndex]));
            }
            else
            {
                HideDialogue();
            }
        }
    }

    private IEnumerator TypeDialogueS(string line)
    {
        dialogueText.text = "";
        isTyping = true;
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1F / lettersPerSecond);
        }
        isTyping = false;
    }
}
