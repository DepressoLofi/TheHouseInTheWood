using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimelineSignalReceiver : MonoBehaviour
{
    public GameObject mouseCharacter; 

    public void HideMouseCharacter()
    {
        mouseCharacter.SetActive(false);
    }
}
