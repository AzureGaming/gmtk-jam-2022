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
        EnemySpawner.OnDone += CompleteWave;
        EnemySpawner.OnAllDone += CompleteAllWaves;
    }

    private void OnDisable()
    {
        Enemy.OnScore -= HandleHit;
        EnemySpawner.OnDone -= CompleteWave;
        EnemySpawner.OnAllDone -= CompleteAllWaves;
    }

    private void Start()
    {
        FindObjectOfType<EnemySpawner>().StartNewWave();
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

    void CompleteWave()
    {
        screenManager.ShowWave();
        StartCoroutine(WaveBreak());
    }

    void CompleteAllWaves()
    {
        screenManager.Victory();
    }

    IEnumerator WaveBreak()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<EnemySpawner>().StartNewWave();
    }
}
