using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] GameObject[] dicePrefabs;

    public GameObject GetRandomDiePrefab()
    {
        int randomIdx = Random.Range(0, dicePrefabs.Length);
        return dicePrefabs[randomIdx];
    }
}
