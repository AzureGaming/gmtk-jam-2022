using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public delegate void Done();
    public static Done OnDone;
    public delegate void AllDone();
    public static AllDone OnAllDone;


    [SerializeField] GameObject[] enemyPrefabs;
    float minBoundX;
    float maxBoundX;
    float yTarget;
    float elapsedTimer;
    float timer;
    float waveTime;
    public int currentWave = 0;
    int waveDifficulty = 0;
    List<GameObject> loadedPrefabs;
    bool spawning;
    bool completionCheck;

    private void Awake()
    {
        loadedPrefabs = new List<GameObject>();
    }

    void Start()
    {
        minBoundX = CameraExtensions.OrthographicBounds(Camera.main).min.x;
        maxBoundX = CameraExtensions.OrthographicBounds(Camera.main).max.x;
        yTarget = CameraExtensions.OrthographicBounds(Camera.main).max.y;
    }

    void Update()
    {
        if (spawning)
        {
            elapsedTimer += Time.deltaTime;
            waveTime += Time.deltaTime;

            SetWaveDifficulty();

            if (elapsedTimer >= timer)
            {
                SpawnEnemy();
                ResetTimer();
            }
        }

        if (!completionCheck)
        {
            CompleteWave();
        }
    }

    public void StartNewWave()
    {
        currentWave++;
        waveTime = 0;
        waveDifficulty = 1;
        completionCheck = false;
        spawning = true;

        if (currentWave == 1)
        {
            Wave1();
        }
        else if (currentWave == 2)
        {
            Wave2();
        }
        else if (currentWave == 3)
        {
            Wave3();
        }
    }

    void CompleteWave()
    {
        if (waveTime >= 60f)
        {
            spawning = false;
        }
        if (FindObjectsOfType<Enemy>().Length == 0 && !spawning)
        {
            if (currentWave == 3)
            {
                OnAllDone?.Invoke();
                completionCheck = true;
            }
            else
            {
                OnDone?.Invoke();
                completionCheck = true;
            }
        }
    }

    void SpawnEnemy()
    {
        Vector2 enemyPos = new Vector2(Random.Range(minBoundX, maxBoundX), yTarget);
        Instantiate(loadedPrefabs[Random.Range(0, loadedPrefabs.Count)], enemyPos, Quaternion.identity);
    }

    void Wave1()
    {
        loadedPrefabs.Clear();
        loadedPrefabs.Add(enemyPrefabs[0]);
    }

    void Wave2()
    {
        loadedPrefabs.Clear();
        loadedPrefabs.Add(enemyPrefabs[0]);
        loadedPrefabs.Add(enemyPrefabs[1]);
    }

    void Wave3()
    {
        loadedPrefabs.Clear();
        loadedPrefabs.Add(enemyPrefabs[0]);
        loadedPrefabs.Add(enemyPrefabs[1]);
        loadedPrefabs.Add(enemyPrefabs[2]);
    }

    void SetWaveDifficulty()
    {
        if (waveTime > 20f && waveDifficulty == 1)
        {
            waveDifficulty = 2;
        }

        if (waveTime > 40f && waveDifficulty == 2)
        {
            waveDifficulty = 3;
        }
    }

    void ResetTimer()
    {
        elapsedTimer = 0f;

        if (currentWave == 1)
        {
            if (waveDifficulty == 1)
            {
                timer = Random.Range(2f, 3f);
            }
            else if (waveDifficulty == 2)
            {
                timer = Random.Range(1f, 2f);
            }
            else if (waveDifficulty == 3)
            {
                timer = Random.Range(0.5f, 1f);
            }
        }
    }
}
