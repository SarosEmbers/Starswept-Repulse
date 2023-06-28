using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameManager GM;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        slider.value = GameManager.playerHealth;
    }
}
