//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IObserver
{
    public Slider healthSlider; 

    public void OnHealthChanged(int newHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.value = newHealth;
        }
    }
}
