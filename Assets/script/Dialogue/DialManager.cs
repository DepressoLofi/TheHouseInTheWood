using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.01f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameTag;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false; 
    private Coroutine displayLineCoroutine;
    private character_movement playerMovement;

    public static DialManager Instance;
    private const string SPEAKER_TAG = "speaker";


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Found more than one dial manager in the scene");
        }

        Instance = this;
    }

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if(!dialogueIsPlaying) {
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
        playerMovement.SetCanMove(false);

        ContinueStory();

    }

    private IEnumerator ExitDialogueMode()
    {
        playerMovement.SetCanMove(true);
        dialoguePanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        dialogueIsPlaying = false;


    }

    private void ContinueStory()
    {
      
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }

    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        canContinueToNextLine = false;

        foreach(char letter in line.ToCharArray())
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

            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameTag.text = tagValue;
                    break;
            }
        }
    }
}
