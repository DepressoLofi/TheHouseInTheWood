using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mouseCharacter; // Assign the "mouse" character GameObject here in the Inspector.

    // Call this method from your Timeline at the appropriate frame where the "mouse" character should be hidden.
    public void HideMouseCharacter()
    {
        mouseCharacter.SetActive(false);
    }
}
