using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health health;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = health.max;
        slider.minValue = 0;
    }

    void Update()
    {
        slider.value = health.health;
    }
}
