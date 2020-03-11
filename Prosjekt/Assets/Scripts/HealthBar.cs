using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Text hpText;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }

    public void setText(string newText)
    {
        hpText.text = newText;
    }
}
