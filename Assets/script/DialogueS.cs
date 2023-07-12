using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueS 
{
    [SerializeField] List<string> lines;

    public List<string> Lines
    {
        get { return lines; }
    }

}
