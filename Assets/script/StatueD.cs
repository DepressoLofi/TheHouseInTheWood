using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueD : MonoBehaviour, Interactable1
{
    public DialogueS dialogue; // Change the access modifier to public

    public void Interact()
    {
        DialogueManager.Instance.ShowDialogue(dialogue);
    }
}

