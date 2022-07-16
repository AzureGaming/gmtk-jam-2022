using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager;
    [SerializeField] Health health;

    private void OnEnable()
    {
        Enemy.OnScore += HandleHit;
    }

    private void OnDisable()
    {
        Enemy.OnScore -= HandleHit;
    }

    void HandleHit()
    {
        health.health -= 5;
        if (health.health <= 0)
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        screenManager.GameOver();
    }
}
