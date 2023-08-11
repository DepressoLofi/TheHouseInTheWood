using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameTag;

    private float typingSpeed = 0.01f;


    private Coroutine displayLineCoroutine;

    private bool canContinueToNextLine = false;
    public bool dialogueIsPlaying { get; private set; }

    private Story currentStory;

    public event Action DialogueEnded;

    public static DialogueSystem Instance;
    private const string SPEAKER_TAG = "speaker";


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

    }

    
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;

        dialoguePanel.SetActive(true);
        

        ContinueStory();

    }


    private IEnumerator ExitDialogueMode()
    {
       
        dialoguePanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        dialogueIsPlaying = false;


    }

    private void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
            DialogueEnded?.Invoke();
        }

    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameTag.text = tagValue;
                    break;
            }
        }
    }
}
