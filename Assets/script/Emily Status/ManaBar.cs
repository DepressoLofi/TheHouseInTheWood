using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI manaText;
    public void SetMana(int mana)
    {
        slider.value = mana;
        manaText.text = mana.ToString() + " / 20";
    }
}
