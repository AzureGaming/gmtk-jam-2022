using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
