using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave : MonoBehaviour
{
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        text.text = $"Wave {FindObjectOfType<EnemySpawner>().currentWave + 1} starting...";
    }
}
