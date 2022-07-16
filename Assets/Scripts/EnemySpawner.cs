using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    float minBoundX;
    float maxBoundX;
    float yTarget;
    float timer;

    void Start()
    {
        minBoundX = CameraExtensions.OrthographicBounds(Camera.main).min.x;
        maxBoundX = CameraExtensions.OrthographicBounds(Camera.main).max.x;
        yTarget = CameraExtensions.OrthographicBounds(Camera.main).max.y;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
            }
        }

        if (timer == 0)
        {
            Vector2 enemyPos = new Vector2(Random.Range(minBoundX, maxBoundX), yTarget);
            Instantiate(GetRandomPrefab(), enemyPos, Quaternion.identity);
            timer = Random.Range(0f, 1f);
        }
    }

    GameObject GetRandomPrefab()
    {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
    }
}
