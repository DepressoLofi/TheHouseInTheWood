using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueD : MonoBehaviour, Interactable1
{
    public DialogueS dialogue; 
    public void Interact()
    {
        DialogueManager.Instance.ShowDialogue(dialogue);
    }
}

