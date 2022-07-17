using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject wave;

    private void Start()
    {
        gameOver.SetActive(false);
        wave.SetActive(false);
        victory.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void ShowWave()
    {
        wave.SetActive(true);
    }

    public void Victory()
    {
        victory.SetActive(true);
    }
}
