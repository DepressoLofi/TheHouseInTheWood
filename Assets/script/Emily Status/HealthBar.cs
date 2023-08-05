using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI healthText;
    public void SetHealth(int health)
    {
        slider.value = health;
        healthText.text = health.ToString() + " / 25";
    }

}
